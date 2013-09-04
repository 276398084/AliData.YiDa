using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XD.Framework.Exceptions;

namespace XD.Framework.Validator
{
    public static class DecimalFieldValidator
    {
        /// <summary>
        /// 验证不允许为负数
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public static DecimalField NotBeNegative(this DecimalField field)
        {
            if (field.ShouldValidate)
                if (field.Value < 0)
                    throw new ValidationException(string.Concat(field.DisplayName, "：不允许为负数！"));

            return field;
        }

        /// <summary>
        /// 验证必须为正数
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public static DecimalField BePositive(this DecimalField field)
        {
            if (field.ShouldValidate)
                if (field.Value <= 0)
                    throw new ValidationException(string.Concat(field.DisplayName, "：必须为正数！"));

            return field;
        }
    }
}
