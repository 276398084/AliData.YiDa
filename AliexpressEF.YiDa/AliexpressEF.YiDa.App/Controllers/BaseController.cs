using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XD.Framework.AbstractModel;
using XD.Framework.Presentation;
using XD.Framework.Util;
using XD.Framework.Extensions;
using XD.Framework.Exceptions;
using NHibernate;
using XD.Framework.Presentation.ExtDataModel;
using XD.Framework.Repository;
using AliexpressEF.YiDa.Domain;

namespace AliexpressEF.YiDa.Controllers
{
    [Authorize(Order = 0)]
    public class BaseController : System.Web.Mvc.Controller
    {
        public BaseController()
        {


        }

        private AliUserType currentUser;

        public AliUserType CurrentUser
        {
            get
            {
                if (currentUser == null)
                {
                    currentUser = GetCurrentAccount();
                }
                return currentUser;
            }
        }

        /// <summary>
        /// 获取当前登陆人的账户信息
        /// </summary>
        /// <returns>账户信息</returns>
        private AliUserType GetCurrentAccount()
        {

            if (Session["aliUser"] != null)
            {
                AliUserType user = (AliUserType)Session["aliUser"];
                return user;
            }
            return null;
            //return new UserType { Id = 0, Realname = "邵锡栋" };
        }

        List<string> ExFilterField = new List<string>();



        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            List<string> ExFilterField = new List<string>();
            ExFilterField.Add("LOGIN");
            ExFilterField.Add("REG");
            ExFilterField.Add("LOGOFF");
            bool iscon = false;
            var controller = filterContext.RouteData.Values["controller"].ToString().ToString();
            var action = filterContext.RouteData.Values["action"].ToString().ToUpper();
            if (ExFilterField.Contains(action))
            {
                return;
            }
            if (filterContext.HttpContext.Session["aliUser"] == null)
            {
                filterContext.HttpContext.Response.Write(" <script type='text/javascript'> window.top.location='/AliUser/Login/'; </script>");
                filterContext.Result = new EmptyResult();
                return;
            }
        }



        /// <summary>
        /// ISession
        /// </summary>
        public ISession NSession { get { return NhbHelper.GetCurrentSession(); } }

        //获取所有列表
        public virtual IList<T> GetAll<T>() where T : BaseEntity
        {
            return NSession.CreateCriteria<T>()
                        .List<T>();
        }

        //保存数据
        public virtual void Save<T>(T entity)
        {
            try
            {
                NSession.Save(entity);
                if (!NSession.Transaction.IsActive)// 不是在事务里，就刷新到数据库
                    NSession.Flush();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("保存数据失败...", ex);
            }
        }

        //更新数据
        public virtual void Update<T>(T entity)
        {
            try
            {
                NSession.Update(entity);
                if (!NSession.Transaction.IsActive)// 不是在事务里，就刷新到数据库
                    NSession.Flush();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("更新数据失败...", ex);
            }
        }

        //保存或更新数据
        public virtual void SaveOrUpdate<T>(T entity)
        {
            try
            {
                NSession.SaveOrUpdate(entity);
                if (!NSession.Transaction.IsActive)// 不是在事务里，就刷新到数据库
                    NSession.Flush();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("保存或更新数据失败...", ex);
            }
        }

        //物理删除数据
        public virtual void Delete<T>(T entity)
        {
            try
            {
                NSession.Delete(entity);
                if (!NSession.Transaction.IsActive)// 不是在事务里，就刷新到数据库
                    NSession.Flush();
            }
            catch (System.Exception ex)
            {
                throw new RepositoryException("删除数据失败...", ex);
            }
        }
        //物理删除数据
        public virtual void Delete<T>(object id)
        {
            try
            {
                var entity = Get<T>(id);
                NSession.Delete(entity);
                if (!NSession.Transaction.IsActive)// 不是在事务里，就刷新到数据库
                    NSession.Flush();
            }
            catch (System.Exception ex)
            {
                throw new RepositoryException("删除数据失败...", ex);
            }
        }
        //获取数据（如果为空抛异常）
        public T Get<T>(object id)
        {
            try
            {
                T entity = NSession.Get<T>(id);
                if (entity == null)
                    throw new NullException("返回数据为空...");
                else
                    return entity;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("获取数据失败...", ex);
            }
        }

        //获取数据 ，不会访问数据库（如果为空抛异常）
        public T Load<T>(string id)
        {
            try
            {
                T entity = NSession.Load<T>(id);
                if (entity == null)
                    throw new NullException("返回数据为空...");
                else
                    return entity;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("获取数据失败...", ex);
            }
        }

        //判断字段的值是否在一定范围内已存在 如果是插入id赋值-1或者new Guid,如果是修改id赋值 要修改项的值
        public bool IsFieldExist<T>(string fieldName, string fieldValue, string id, string where)
        {
            if (!string.IsNullOrEmpty(where))
                where = @" and " + where;
            var query = NSession.CreateQuery(
                string.Format(@"select count(*) from {0} as o where o.{1}='{2}' and o.Id<>'{3}'" + where,
                typeof(T).Name,
                fieldName,
                fieldValue, id));
            return query.UniqueResult<long>() > 0;
        }

        //简单查询
        public List<T> GetList<T>(string fieldName, string fieldValue, string where)
        {
            if (!string.IsNullOrEmpty(where))
                where = @" and " + where;
            var query = NSession.CreateQuery(
                string.Format(@"from {0} as o where o.{1}='{2}' " + where,
                typeof(T).Name,
                fieldName,
                fieldValue));
            return query.List<T>().ToList<T>();
        }

        //判断字段的值是否存在 如果是插入id赋值-1或者new Guid,如果是修改id赋值 要修改项的值
        public bool IsFieldExist<T>(string fieldName, string fieldValue, string id)
        {
            return IsFieldExist<T>(fieldName, fieldValue, id, null);
        }



        private NHibernate.Criterion.ICriterion GetComparison(string comparison, string field, object value)
        {
            NHibernate.Criterion.ICriterion res;
            switch (comparison)
            {
                case "lt":
                    res = NHibernate.Criterion.Restrictions.Lt(field, value);
                    break;
                case "gt":
                    res = NHibernate.Criterion.Restrictions.Gt(field, value);
                    break;
                case "eq":
                    res = NHibernate.Criterion.Restrictions.Eq(field, value);
                    break;
                case "elt":
                    res = NHibernate.Criterion.Restrictions.Le(field, value);
                    break;
                case "egt":
                    res = NHibernate.Criterion.Restrictions.Ge(field, value);
                    break;
                default:
                    res = null;
                    break;
            }
            return res;
        }

        public IList<T> PaggingList<T>(int start, int limit, string sort, string filter, out long total) where T : BaseEntity
        {
            var q = NSession.QueryOver<T>();

            //字段动态过滤
            if (string.IsNullOrEmpty(filter) == false)
            {
                var filterArray = Newtonsoft.Json.JsonConvert.DeserializeObject<ExtDataFilter[]>(filter);

                var stringList = from f in filterArray where f.type == "string" select f;
                foreach (var fs in stringList)
                {
                    q = q.Where(NHibernate.Criterion.Restrictions.Like(fs.field, "%" + fs.value + "%"));
                }

                var booleanList = from f in filterArray where f.type == "boolean" select f;
                foreach (var fb in booleanList)
                {
                    q = q.Where(NHibernate.Criterion.Restrictions.Eq(fb.field, Boolean.Parse(fb.value)));
                }

                var numericList = from f in filterArray where f.type == "numeric" select f;
                foreach (var fn in numericList)
                {
                    q = q.Where(GetComparison(fn.comparison, fn.field, int.Parse(fn.value)));
                }

                var floatList = from f in filterArray where f.type == "float" select f;
                foreach (var ff in floatList)
                {
                    q = q.Where(GetComparison(ff.comparison, ff.field, decimal.Parse(ff.value)));
                }


                var dateList = from f in filterArray where f.type == "date" select f;
                foreach (var fd in dateList)
                {
                    q = q.Where(GetComparison(fd.comparison, fd.field, DateTime.Parse(fd.value)));
                }
                //type=list  :["1","2"]
                var listList = from f in filterArray where f.type == "list" select f;
                foreach (var fl in listList)
                {
                    var linq = from v in fl.value.Split(',') select v.ToInt32();
                    q = q.Where(NHibernate.Criterion.Restrictions.In(fl.field, linq.ToArray()));
                }
            }

            //总数
            total = q.RowCountInt64();

            //排序
            if (string.IsNullOrEmpty(sort) == false)
            {
                var sortArray = Newtonsoft.Json.JsonConvert.DeserializeObject<ExtSortModel[]>(sort);
                foreach (var s in sortArray)
                {
                    if (s.direction == "ASC")
                        q = q.OrderBy(NHibernate.Criterion.Projections.Property(s.property)).Asc;
                    else
                        q = q.OrderBy(NHibernate.Criterion.Projections.Property(s.property)).Desc;
                }
            }

            return q.Skip(start).Take(limit).List();//分页
        }

        public IList<T> SortList<T>(string sort, string filter, out long total) where T : BaseEntity
        {
            var q = NSession.QueryOver<T>();

            //字段动态过滤
            if (string.IsNullOrEmpty(filter) == false)
            {
                var filterArray = Newtonsoft.Json.JsonConvert.DeserializeObject<ExtDataFilter[]>(filter);

                var stringList = from f in filterArray where f.type == "string" select f;
                foreach (var fs in stringList)
                {
                    q = q.Where(NHibernate.Criterion.Restrictions.Like(fs.field, "%" + fs.value + "%"));
                }

                var booleanList = from f in filterArray where f.type == "boolean" select f;
                foreach (var fb in booleanList)
                {
                    q = q.Where(NHibernate.Criterion.Restrictions.Eq(fb.field, Boolean.Parse(fb.value)));
                }

                var numericList = from f in filterArray where f.type == "numeric" select f;
                foreach (var fn in numericList)
                {
                    q = q.Where(GetComparison(fn.comparison, fn.field, int.Parse(fn.value)));
                }

                var dateList = from f in filterArray where f.type == "date" select f;
                foreach (var fd in dateList)
                {
                    q = q.Where(GetComparison(fd.comparison, fd.field, DateTime.Parse(fd.value)));
                }

                var listList = from f in filterArray where f.type == "list" select f;
                foreach (var fl in listList)
                {
                    var linq = from v in fl.value.Split(',') select v.ToInt32();

                    q = q.Where(NHibernate.Criterion.Restrictions.In(fl.field, linq.ToArray()));
                }
            }
            //总数
            total = q.RowCountInt64();
            //排序
            if (string.IsNullOrEmpty(sort) == false)
            {
                var sortArray = Newtonsoft.Json.JsonConvert.DeserializeObject<ExtSortModel[]>(sort);
                foreach (var s in sortArray)
                {
                    if (s.direction == "ASC")
                        q = q.OrderBy(NHibernate.Criterion.Projections.Property(s.property)).Asc;
                    else
                        q = q.OrderBy(NHibernate.Criterion.Projections.Property(s.property)).Desc;
                }
            }

            return q.List();
        }


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
