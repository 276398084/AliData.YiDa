using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XD.Framework.Exceptions;

namespace XD.Framework.Validator
{
    /// <summary>
    /// 适用于可比较大小的值的验证
    /// </summary>
    public static class ComparableFieldValidator
    {
        /// <summary>
        /// 验证必须大于
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public static TField BeGreateThan<TField, TValue>(this TField field, TValue other)
            where TField : FieldWapper<TField, TValue>, IComparableField<TValue>
        {
            if (field.ShouldValidate)
                if (field.CompareTo(other) <= 0)
                    throw new ValidationException(string.Format("{0}：必须大于 {1}!", field.DisplayName, other.ToString()));

            return field;
        }

        /// <summary>
        /// 验证必须大于等于
        /// </summary>
        /// <param name="other"></param>
        /// <param name="customMsg">自定义错误信息，为空时忽略此参数而使用默认错误信息</param>
        /// <returns></returns>
        public static TField BeGreateEqualThan<TField, TValue>(this TField field, TValue other, string customMsg = null)
            where TField : FieldWapper<TField, TValue>, IComparableField<TValue>
        {
            if (field.ShouldValidate)
                if (field.CompareTo(other) < 0)
                    throw new ValidationException(string.IsNullOrEmpty(customMsg) ? 
                        string.Format("{0}：必须大于等于 {1}!", field.DisplayName, other.ToString()) : customMsg);

            return field;
        }

        /// <summary>
        /// 验证必须小于
        /// </summary>
        /// <param name="other"></param>
        /// <param name="customMsg">自定义错误信息，为空时忽略此参数而使用默认错误信息</param>
        /// <returns></returns>
        public static TField BeLessThan<TField, TValue>(this TField field, TValue other, string customMsg = null)
            where TField : FieldWapper<TField, TValue>, IComparableField<TValue>
        {
            if (field.ShouldValidate)
                if (field.CompareTo(other) >= 0)
                    throw new ValidationException(string.IsNullOrEmpty(customMsg) ? 
                        string.Format("{0}：必须小于 {1}!", field.DisplayName, other.ToString()) : customMsg);

            return field;
        }

        /// <summary>
        /// 验证必须小于等于
        /// </summary>
        /// <typeparam name="TField"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="field"></param>
        /// <param name="other"></param>
        /// <param name="customMsg">自定义错误信息，为空时忽略此参数而使用默认错误信息</param>
        /// <returns></returns>
        public static TField BeLessEqualThan<TField, TValue>(this TField field, TValue other, string customMsg=null)
            where TField : FieldWapper<TField, TValue>, IComparableField<TValue>
        {
            if (field.ShouldValidate)
                if (field.CompareTo(other) > 0)
                    throw new ValidationException(string.IsNullOrEmpty(customMsg) ? 
                        string.Format("{0}：必须小于 {1}!", field.DisplayName, other.ToString()) : customMsg);

            return field;
        }

        /// <summary>
        /// 验证必须介于 start 和 end 之间
        /// </summary>
        /// <typeparam name="TField"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="field"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static TField Between<TField, TValue>(this TField field, TValue start, TValue end)
            where TField : FieldWapper<TField, TValue>, IComparableField<TValue>
        {
            if (field.ShouldValidate)
                if (field.CompareTo(start) < 0 || field.CompareTo(end) > 0)
                    throw new ValidationException(string.Format("{0}：必须介于 {1} 和 {2} 之间！", field.DisplayName, start, end));

            return field;
        }

        /// <summary>
        /// 验证必须等于
        /// </summary>
        /// <typeparam name="TField"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="field"></param>
        /// <param name="other"></param>
        /// <param name="customMsg">自定义错误信息，为空时忽略此参数而使用默认错误信息</param>
        /// <returns></returns>
        public static TField BeEqual<TField, TValue>(this TField field, TValue other, string customMsg = null)
            where TField : FieldWapper<TField, TValue>, IComparableField<TValue>
        {
            if (field.ShouldValidate)
                if (field.CompareTo(other) != 0)
                    throw new ValidationException(string.IsNullOrEmpty(customMsg) ? 
                        string.Format("{0}：必须等于 {1}!", field.DisplayName, other.ToString()) : customMsg);

            return field;
        }

        /// <summary>
        /// 验证不允许等于
        /// </summary>
        /// <typeparam name="TField"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="field"></param>
        /// <param name="other"></param>
        /// <param name="customMsg">自定义错误信息，为空时忽略此参数而使用默认错误信息</param>
        /// <returns></returns>
        public static TField NotBeEqual<TField, TValue>(this TField field, TValue other, string customMsg = null)
            where TField : FieldWapper<TField, TValue>, IComparableField<TValue>
        {
            if (field.ShouldValidate)
                if (field.CompareTo(other) == 0)
                    throw new ValidationException(string.IsNullOrEmpty(customMsg) ?
                        string.Format("{0}：不允许等于 {1}!", field.DisplayName, other.ToString()) : customMsg);

            return field;
        }
    }
}
