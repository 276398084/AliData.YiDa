using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using XD.Framework.Exceptions;

namespace XD.Framework.Validator
{
    /// <summary>
    /// 适用于字符串的验证
    /// </summary>
    public static class StringFieldValidator
    {
        /// <summary>
        /// 验证不允许为空或空字符串
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public static StringField NotBeNullOrEmpty(this StringField field)
        {
            if (field.ShouldValidate)
                if (string.IsNullOrEmpty(field.Value))
                    throw new ValidationException(string.Concat(field.DisplayName, "：不允许为空！"));

            return field;
        }

        /// <summary>
        /// 验证必须为空或空字符串
        /// </summary>
        /// <param name="field"></param>
        /// <param name="customMsg">自定义错误信息</param>
        /// <returns></returns>
        public static StringField BeNullOrEmpty(this StringField field, string customMsg)
        {
            if (field.ShouldValidate)
                if (string.IsNullOrEmpty(field.Value) == false)
                    throw new ValidationException(string.IsNullOrEmpty(customMsg) ?
                        string.Concat(field.DisplayName, "：必须为空！") : customMsg);

            return field;
        }

        /// <summary>
        ///  验证值不允许重复
        /// </summary>
        /// <param name="field"></param>
        /// <param name="fieldName">属性名</param>
        /// <param name="id">实体Id</param>
        /// <param name="isFieldExist">判断值是否存在的方法的委托</param>
        /// <param name="T">实体类型</param>
        /// <returns></returns>
        public static StringField NotBeExist(this StringField field, string fieldName, string id, Type T,
            Func<string, string, string, Type, bool> isFieldExist)
        {
            if (field.ShouldValidate)
                if (isFieldExist(fieldName, field.Value, id, T))
                    throw new ValidationException(field.DisplayName + ":不允许重复");

            return field;
        }
        /// <summary>
        ///  验证值不允许重复
        /// </summary>
        /// <param name="field"></param>
        /// <param name="fieldName">属性名</param>
        /// <param name="id">实体Id</param>
        /// <param name="isFieldExist">判断值是否存在的方法的委托</param>
        /// <returns></returns>
        public static StringField NotBeExist(this StringField field, string fieldName, string id,
            Func<string, string, string, bool> isFieldExist)
        {
            if (field.ShouldValidate)
                if (isFieldExist(fieldName, field.Value, id))
                    throw new ValidationException(field.DisplayName + ":不允许重复");

            return field;
        }
        /// <summary>
        /// 验证值不允许在一定范围内重复
        /// </summary>
        /// <param name="field"></param>
        /// <param name="fieldName">属性名</param>
        /// <param name="id">实体Id</param>
        /// <param name="scopeFieldId">限定查找范围的属性名</param>
        /// <param name="isFieldExist">判断值是否存在的方法的委托</param>
        /// <param name="T">对象的类型</param>
        /// <returns></returns>
        public static StringField NotBeExistInScope(this StringField field, string fieldName, string id, string scopeFieldId, Type T,
            Func<string, string, string, string, Type, bool> isFieldExist)
        {
            if (field.ShouldValidate)
                if (isFieldExist(fieldName, field.Value, id, scopeFieldId, T))
                    throw new ValidationException(field.DisplayName + ":不允许重复");

            return field;
        }
        /// <summary>
        /// 验证值不允许在一定范围内重复
        /// </summary>
        /// <param name="field"></param>
        /// <param name="fieldName">属性名</param>
        /// <param name="id">实体Id</param>
        /// <param name="scopeFieldId">限定查找范围的属性名</param>
        /// <param name="isFieldExist">判断值是否存在的方法的委托</param>
        /// <returns></returns>
        public static StringField NotBeExistInScope(this StringField field, string fieldName, string id, string scopeFieldId,
            Func<string, string, string, string, bool> isFieldExist)
        {
            if (field.ShouldValidate)
                if (isFieldExist(fieldName, field.Value, id, scopeFieldId))
                    throw new ValidationException(field.DisplayName + ":不允许重复");

            return field;
        }
        /// <summary>
        /// 验证实体不含有子项
        /// </summary>
        /// <param name="field"></param>
        /// <param name="isSubItemExist">判断实体是否含有子项的方法的委托</param>
        /// <returns></returns>
        public static StringField NotHasSubItems(this StringField field, Func<string, bool> isSubItemExist)
        {
            if (field.ShouldValidate)
                if (isSubItemExist(field.Value))
                    throw new ValidationException("所选项下面存在子项!");

            return field;
        }

        /// <summary>
        /// 验证实体不含有子节点
        /// </summary>
        /// <param name="field"></param>
        /// <param name="isSubItemExist">判断实体是否含有子项的方法的委托</param>
        /// <returns></returns>
        public static StringField NotHasChildNodes(this StringField field, Func<string, bool> isSubItemExist)
        {
            if (field.ShouldValidate)
                if (isSubItemExist(field.Value))
                    throw new ValidationException("所选项下面存在子项!");

            return field;
        }

        /// <summary>
        /// 验证必须等于
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public static StringField BeEqualTo(this StringField field, string v)
        {
            if (field.ShouldValidate)
                if (field.Value != v)
                    throw new ValidationException(string.Format("{0}：必须等于 {1}！", field.DisplayName, v));

            return field;
        }

        /// <summary>
        /// 验证必须等于
        /// </summary>
        /// <param name="field"></param>
        /// <param name="v"></param>
        /// <param name="customMsg">自定义错误信息</param>
        /// <returns></returns>
        public static StringField BeEqualTo(this StringField field, string v, string customMsg)
        {
            if (field.ShouldValidate)
                if (field.Value != v)
                    throw new ValidationException(customMsg);

            return field;
        }

        /// <summary>
        /// 验证不允许等于
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public static StringField NotBeEqualTo(this StringField field, string v)
        {
            if (field.ShouldValidate)
                if (field.Value == v)
                    throw new ValidationException(string.Format("{0}：不允许等于 {1}！", field.DisplayName, v));

            return field;
        }

        /// <summary>
        /// 验证不允许等于
        /// </summary>
        /// <param name="field"></param>
        /// <param name="v"></param>
        /// <param name="customMsg">自定义错误信息</param>
        /// <returns></returns>
        public static StringField NotBeEqualTo(this StringField field, string v, string customMsg)
        {
            if (field.ShouldValidate)
                if (field.Value == v)
                    throw new ValidationException(customMsg);

            return field;
        }

        public static StringField BeMatch(this StringField field, string regex, string customMsg = "")
        {
            if (field.ShouldValidate)
                if (new Regex(regex).IsMatch(field.Value) == false)
                    throw new ValidationException(string.IsNullOrEmpty(customMsg) ?
                        "无效的" + field.DisplayName : customMsg);

            return field;
        }
    }
}
