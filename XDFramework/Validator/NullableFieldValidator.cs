using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XD.Framework.Exceptions;

namespace XD.Framework.Validator
{
    /// <summary>
    /// 适用于可空值对象的验证
    /// </summary>
    public static class NullableFieldValidator
    {
        /// <summary>
        /// 验证不允许为空
        /// </summary>
        /// <typeparam name="TInnerValue"></typeparam>
        /// <param name="field"></param>
        /// <param name="customMsg">自定义错误信息，为空时忽略</param>
        /// <returns></returns>
        public static NullableField<TInnerValue> NotBeNull<TInnerValue>(this NullableField<TInnerValue> field,
            string customMsg = "") where TInnerValue : struct
        {
            if (field.ShouldValidate)
                if (!field.Value.HasValue)
                    throw new ValidationException(string.IsNullOrEmpty(customMsg) ?
                        string.Format("{0}：不允许为空!", field.DisplayName) : customMsg);

            return field;
        }
    }
}
