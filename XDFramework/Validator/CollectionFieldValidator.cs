using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XD.Framework.Exceptions;

namespace XD.Framework.Validator
{
    /// <summary>
    /// 适用于集合类型的验证
    /// </summary>
    public static class CollectionFieldValidator
    {
        /// <summary>
        /// 验证不包含
        /// </summary>
        /// <typeparam name="TInnerValue"></typeparam>
        /// <param name="field"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static CollectionField<TInnerValue> NotBeExist<TInnerValue>(this CollectionField<TInnerValue> field, Func<TInnerValue, bool> predicate)
        {
            if (field.ShouldValidate)
                if(field.Value.Any(predicate))
                    throw new ValidationException(field.DisplayName + ":不允许重复！");

            return field;
        }

        /// <summary>
        /// 验证不允许为空
        /// </summary>
        /// <typeparam name="TInnerValue"></typeparam>
        /// <param name="field"></param>
        /// <param name="customMsg">用户自定义错误信息</param>
        /// <returns></returns>
        public static CollectionField<TInnerValue> NotBeNullOrEmpty<TInnerValue>(this CollectionField<TInnerValue> field, string customMsg = "")
        {
            if (field.ShouldValidate)
                if (field.Value == null || field.Value.Count <= 0)
                    throw new ValidationException(string.IsNullOrEmpty(customMsg) ? 
                        string.Format("{0}: 不允许为空！", field.DisplayName) : customMsg);

            return field;
        }

        /// <summary>
        /// 验证必须为空
        /// </summary>
        /// <typeparam name="TInnerValue"></typeparam>
        /// <param name="field"></param>
        /// <param name="customMsg">用户自定义错误信息</param>
        /// <returns></returns>
        public static CollectionField<TInnerValue> BeEmpty<TInnerValue>(this CollectionField<TInnerValue> field, string customMsg)
        {
            if (field.ShouldValidate)
                if (field.Value.Count > 0)
                    throw new ValidationException(customMsg);

            return field;
        }

        /// <summary>
        /// 验证不包含重复的项
        /// </summary>
        /// <typeparam name="TInnerValue"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="field"></param>
        /// <param name="GetPropertyValue">要验证唯一性的属性值</param>
        /// <param name="uniquePropertyDisplayName">要验证唯一性的属性的显示名称</param>
        /// <returns></returns>
        public static CollectionField<TInnerValue> ContainUniqueItem<TInnerValue, TProperty>(this CollectionField<TInnerValue> field,
            Func<TInnerValue, TProperty> GetPropertyValue, string uniquePropertyDisplayName)
        {
            if (field.ShouldValidate)
            {
                ISet<TProperty> values = new HashSet<TProperty>();
                foreach (TInnerValue item in field.Value)
                {
                    TProperty value = GetPropertyValue(item);
                    if (values.Contains(value))
                    {
                        throw new ValidationException(string.Format("{0}：不允许包含重复的{1}！", field.DisplayName,
                            uniquePropertyDisplayName));
                    }
                    else
                    {
                        values.Add(value);
                    }
                }
            }

            return field;
        }

        /// <summary>
        /// 验证必须包含相同的项
        /// </summary>
        /// <typeparam name="TInnerValue"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="field"></param>
        /// <param name="GetPropertyValue"></param>
        /// <param name="uniquePropertyDisplayName"></param>
        /// <returns></returns>
        public static CollectionField<TInnerValue> ContainSameItem<TInnerValue, TProperty>(this CollectionField<TInnerValue> field,
            Func<TInnerValue, TProperty> GetPropertyValue, string uniquePropertyDisplayName)
        {
            if (field.ShouldValidate)
            {
                ISet<TProperty> values = new HashSet<TProperty>();
                foreach (TInnerValue item in field.Value)
                {
                    TProperty value = GetPropertyValue(item);
                    values.Add(value);
                    if(values.Count > 1)
                        throw new ValidationException(string.Format("{0}：必须包含相同的{1}！", field.DisplayName,
                            uniquePropertyDisplayName));
                }
            }

            return field;
        }

        /// <summary>
        /// 验证集合中必须包含 itemValue
        /// </summary>
        /// <typeparam name="TInnerValue"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="field"></param>
        /// <param name="GetPropertyValue"></param>
        /// <param name="itemValue"></param>
        /// <param name="customMsg"></param>
        /// <returns></returns>
        public static CollectionField<TInnerValue> ContainItem<TInnerValue, TProperty>(this CollectionField<TInnerValue> field,
            Func<TInnerValue, TProperty> GetPropertyValue, TProperty itemValue, string customMsg = "")
        {
            if (field.ShouldValidate)
            {
                foreach (TInnerValue item in field.Value)
                {
                    TProperty value = GetPropertyValue(item);
                    if(value.Equals(itemValue))
                        return field;
                }
            }

            throw new ValidationException(string.IsNullOrEmpty(customMsg) ? 
                string.Format("{0}：必须包含{1}！", field.DisplayName, itemValue.ToString()) : customMsg);
        }
    }
}
