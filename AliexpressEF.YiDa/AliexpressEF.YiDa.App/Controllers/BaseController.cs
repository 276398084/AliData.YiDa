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

       
    }
}
