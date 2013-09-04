using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Transform;
using NHibernate.Criterion.Lambda;
using System.Linq.Expressions;
using NHibernate.Impl;
using NHibernate.Criterion;
using System.Reflection;

namespace XD.Framework.Extensions
{
    public static class IQueryOverExtension
    {
        /// <summary>
        /// 别名可以直接用字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="p"></param>
        /// <param name="alias"></param>
        /// <returns></returns>
        public static QueryOverProjectionBuilder<T> WithAliasString<T>(this QueryOverProjectionBuilder<T> p, string alias)
        {
            FieldInfo fi = typeof(QueryOverProjectionBuilder<T>).GetField("lastProjection", 
                BindingFlags.NonPublic | BindingFlags.SetField | BindingFlags.Instance|BindingFlags.GetField);

            IProjection lastProjection =fi.GetValue(p) as IProjection;
            fi.SetValue(p, Projections.Alias(lastProjection, alias));

            return p;
        }
        /// <summary>
        /// 投影到匿名对象集合
        /// </summary>
        /// <typeparam name="TRoot"></typeparam>
        /// <typeparam name="TSub"></typeparam>
        /// <param name="s"></param>
        /// <returns></returns>
        public static IList<dynamic> ToAnonymousList<TRoot, TSub>(this IQueryOver<TRoot, TSub> s)
        {
            return s
                .TransformUsing(Transformers.AliasToEntityMap)
                .List<dynamic>();
        }

        /// <summary>
        /// 投影到匿名单个对象
        /// </summary>
        /// <typeparam name="TRoot"></typeparam>
        /// <typeparam name="TSub"></typeparam>
        /// <param name="s"></param>
        /// <returns></returns>
        public static dynamic ToAnonymousSingle<TRoot, TSub>(this IQueryOver<TRoot, TSub> s)
        {
            return s
                .TransformUsing(Transformers.AliasToEntityMap)
                .SingleOrDefault<dynamic>();
        }

        /// <summary>
        /// 投影分页匿名对象
        /// </summary>
        /// <typeparam name="TRoot"></typeparam>
        /// <typeparam name="TSub"></typeparam>
        /// <param name="s"></param>
        /// <param name="start"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static IList<dynamic> ToAnonymousPagging<TRoot, TSub>(this IQueryOver<TRoot, TSub> s, int start, int limit)
        {
            return s
                .TransformUsing(Transformers.AliasToEntityMap)
                .Skip(start).Take(limit)
                .List<dynamic>();
        }
    }
}
