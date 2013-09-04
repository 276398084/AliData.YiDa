using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XD.Framework.AbstractModel;
using XD.Framework.Presentation;
using XD.Framework.Util;
using XD.Framework.Extensions;

namespace AliexpressEF.YiDa.Controllers
{
    [Authorize(Order = 0)]
    public class BaseController : System.Web.Mvc.Controller
    {
        /// <summary>
        /// 序列化对象
        /// </summary>
        /// <param name="data">要序列化的对象</param>
        /// <param name="exceptMemberName">显示排除对象的成员</param>
        /// <returns></returns>
        public OITFJsonResult JsonSerialization(object data, string[] exceptMemberName)
        {
            OITFJsonResult result = new OITFJsonResult();
            result.Data = data;
            result.ExceptMemberName = exceptMemberName;
            return result;
        }
        /// <summary>
        /// 序列化对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public OITFJsonResult JsonSerialization(object data)
        {
            return JsonSerialization(data, null);
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public T JsonDeserialize<T>(string json)
        {
            if (string.IsNullOrEmpty(json))
                return default(T);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
        }

        #region RequestUtil
        public string id()
        {
            return Request["Id"];
        }
        public string query()
        {
            if (String.IsNullOrEmpty(Request["query"]))
                return "";
            else
                return Request["query"];
        }

        #region isFieldExits
        public string fieldName()
        {
            return Request["fieldName"];
        }
        public string fieldValue()
        {
            return Request[Request["fieldName"]];
        }
        #endregion

        #region ExtGridParameter
        public string filter()
        {
            if (String.IsNullOrEmpty(Request["filter"]))
                return "";
            else
                return Request["filter"];
        }
        public int start()
        {
            return this.Request["start"].ToInt32();
        }
        public int limit()
        {
            return this.Request["limit"].ToInt32();
        }
        public string sort()
        {
            if (String.IsNullOrEmpty(Request["sort"]))
                return "";
            else
                return Request["sort"];
        }
        public string dir()
        {
            return this.Request["dir"];
        }

        #endregion

        /// <summary>
        /// 自动设置对象的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public void SetEntityValue<T>(T entity)
        {
            SetEntityValue<T>(entity, null);
        }

        /// <summary>
        /// 延迟加载类型是实体的属性
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assign"></param>
        /// <param name="load"></param>
        /// <param name="id"></param>
        public void LoadEntity<T>(Action<T> assign, Func<string, T> load, object id) where T : BaseEntity
        {
            // id 为 null 表示用户没有进行任何修改，所以不做任何操作
            if (id == null)
                return;

            // id 为空字符串表示用户把属性改成了空值，所以要把属性赋值为null
            string idStr = id.ToString();
            if (idStr == string.Empty)
            {
                assign(null);
                return;
            }

            // 延迟加载属性
            assign(load(idStr));
        }
        /// <summary>
        /// 自动设置对象的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="ignoredPropertyNames">要忽略的属性名列表(为空时此属性不生效)</param>
        public void SetEntityValue<T>(T entity, string[] ignoredPropertyNames)
        {
            var type = typeof(T);
            IDictionary<string, string> ignoredPropertyNameDict = ignoredPropertyNames == null ? null
                : ignoredPropertyNames.ToDictionary<string, string>(t => t);
            foreach (var p in type.GetProperties())
            {
                // 如果属性为 Id、Version、 CreateTime 以及客户在 ignoredPropertyNames 中指定要忽略的属性，不进行赋值操作
                if (p.Name == "Id")
                    continue;
                if (p.Name == "Version")
                    continue;
                if (p.Name == "CreateTime")
                    continue;
                if (ignoredPropertyNameDict != null && ignoredPropertyNameDict.ContainsKey(p.Name))
                    continue;

                var pType = p.PropertyType;
                if (pType.BaseType != null && pType.BaseType.Name == "Enum")
                {
                    if (!String.IsNullOrEmpty(Request[p.Name]))
                    {
                        p.SetValue(entity, int.Parse(Request[p.Name]), null);
                    }
                }
                switch (pType.Name)
                {
                    case "String":
                        if (Request[p.Name] != null)
                            p.SetValue(entity, Request[p.Name], null);
                        break;
                    case "Int32":
                        if (!String.IsNullOrEmpty(Request[p.Name]))
                            p.SetValue(entity, int.Parse(Request[p.Name]), null);
                        break;
                    case "Int64":
                        if (!String.IsNullOrEmpty(Request[p.Name]))
                            p.SetValue(entity, long.Parse(Request[p.Name]), null);
                        break;
                    case "Decimal":
                        if (!String.IsNullOrEmpty(Request[p.Name]))
                            p.SetValue(entity, Decimal.Parse(Request[p.Name]), null);
                        break;
                    case "Boolean":
                        if (!String.IsNullOrEmpty(Request[p.Name]))
                            p.SetValue(entity, Boolean.Parse(Request[p.Name]), null);
                        else
                            p.SetValue(entity, false, null);
                        break;
                    case "DateTime":
                        if (!String.IsNullOrEmpty(Request[p.Name]))
                            p.SetValue(entity, DateTime.Parse(Request[p.Name]), null);
                        break;
                    case "Nullable`1":
                        switch (pType.GetGenericArguments()[0].Name)
                        {
                            case "Int32":
                                if (!String.IsNullOrEmpty(Request[p.Name]))
                                    p.SetValue(entity, new Nullable<Int32>(int.Parse(Request[p.Name])), null);
                                else
                                    p.SetValue(entity, null, null);
                                break;
                            case "Int64":
                                if (!String.IsNullOrEmpty(Request[p.Name]))
                                    p.SetValue(entity, new Nullable<Int64>(long.Parse(Request[p.Name])), null);
                                else
                                    p.SetValue(entity, null, null);
                                break;
                            case "Decimal":
                                if (!String.IsNullOrEmpty(Request[p.Name]))
                                    p.SetValue(entity, new Nullable<Decimal>(Decimal.Parse(Request[p.Name])), null);
                                else
                                    p.SetValue(entity, null, null);
                                break;
                            case "Boolean":
                                if (!String.IsNullOrEmpty(Request[p.Name]))
                                    p.SetValue(entity, new Nullable<Boolean>(Boolean.Parse(Request[p.Name])), null);
                                else
                                    p.SetValue(entity, false, null);
                                break;
                            case "DateTime":
                                if (!String.IsNullOrEmpty(Request[p.Name]))
                                    p.SetValue(entity, new Nullable<DateTime>(DateTime.Parse(Request[p.Name])), null);
                                else
                                    p.SetValue(entity, null, null);
                                break;
                        }
                        break;
                }
            }
        }
        #endregion
    }
}
