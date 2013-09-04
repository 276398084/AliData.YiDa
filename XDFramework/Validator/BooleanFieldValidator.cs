using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XD.Framework.Exceptions;

namespace XD.Framework.Validator
{
    /// <summary>
    /// 适用于 Boolean 类型的验证
    /// </summary>
    public static class BooleanFieldValidator
    {
        /// <summary>
        /// 验证必须为真
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public static BooleanField BeTrue(this BooleanField field, string customMsg = "")
        {
            if (field.ShouldValidate)
                if (field.Value == false)
                    throw new ValidationException((string.IsNullOrEmpty(customMsg) ?
                        string.Concat("必须", field.DisplayName, "！") : customMsg));

            return field;
        }

        /// <summary>
        /// 验证必须为假
        /// </summary>
        /// <param name="field"></param>
        /// <param name="customMsg"></param>
        /// <returns></returns>
        public static BooleanField BeFalse(this BooleanField field, string customMsg = "")
        {
            if (field.ShouldValidate)
                if (field.Value == true)
                    throw new ValidationException((string.IsNullOrEmpty(customMsg) ?
                        string.Concat("不允许", field.DisplayName, "！") : customMsg));

            return field;
        }
    }
}
