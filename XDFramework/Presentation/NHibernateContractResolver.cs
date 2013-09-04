using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Serialization;
using System.Reflection;
using NHibernate.Proxy;
using Newtonsoft.Json;

namespace XD.Framework.Presentation
{
    /// <summary>
    /// 避免循环引用而定义的Json解析规则
    /// </summary>
    public class NHibernateContractResolver : DefaultContractResolver
    {
        private string[] exceptMemberName;

        private static readonly MemberInfo[] NHibernateProxyInterfaceMembers = typeof(INHibernateProxy).GetMembers();

        public NHibernateContractResolver(string[] exceptMemberName)
        {
            this.exceptMemberName = exceptMemberName;
        }
        protected override List<MemberInfo> GetSerializableMembers(Type objectType)
        {
            var members = new List<PropertyInfo>(objectType.GetProperties());
            members.RemoveAll(memberInfo =>
                // (IsMemberNames(memberInfo))||
                (IsMemberPartOfNHibernateProxyInterface(memberInfo)) ||
                (IsMemberDynamicProxyMixin(memberInfo)) ||
                (IsMemberMarkedWithIgnoreAttribute(memberInfo, objectType)) ||
                (IsInheritedISet(memberInfo)) ||
                (IsInheritedEntity(memberInfo))
                );

            var actualMemberInfos = new List<MemberInfo>();
            foreach (var memberInfo in members)
            {
                var infos = memberInfo.DeclaringType.BaseType.GetMember(memberInfo.Name);
                actualMemberInfos.Add(infos.Length == 0 ? memberInfo : infos[0]);
                //Debug.WriteLine(memberInfo.Name);
            }
            return actualMemberInfos;
        }
        private static bool IsMemberDynamicProxyMixin(PropertyInfo memberInfo)
        {
            return memberInfo.Name == "__interceptors";
        }

        private static bool IsMemberPartOfNHibernateProxyInterface(PropertyInfo memberInfo)
        {
            return Array.Exists(NHibernateProxyInterfaceMembers, mi => memberInfo.Name == mi.Name);
        }

        private static bool IsMemberMarkedWithIgnoreAttribute(PropertyInfo memberInfo, Type objectType)
        {
            var infos = typeof(INHibernateProxy).IsAssignableFrom(objectType) ?
                objectType.BaseType.GetMember(memberInfo.Name) :
                objectType.GetMember(memberInfo.Name);
            return infos[0].GetCustomAttributes(typeof(JsonIgnoreAttribute), true).Length > 0;
        }

        private bool IsExceptMember(PropertyInfo memberInfo)
        {
            if (exceptMemberName == null)
                return false;
            return Array.Exists(exceptMemberName, i => memberInfo.Name == i);
        }

        private bool IsInheritedISet(PropertyInfo memberInfo)
        {
            return (memberInfo.PropertyType.Name == "ISet`1" && !IsExceptMember(memberInfo));
        }

        private bool IsInheritedEntity(PropertyInfo memberInfo)
        {
            return (FindBaseType(memberInfo.PropertyType).Name == "BaseEntity" && !IsExceptMember(memberInfo));
        }
        private static Type FindBaseType(Type type)
        {
            if (!type.IsClass)
                return type;
            if (type.Name == "BaseEntity" || type.Name == "Object")
            {
                return type;
            }
            return FindBaseType(type.BaseType);
        }
    }
}
