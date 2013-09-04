using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XD.Framework.Exceptions;
using XD.Framework.Util;
using XD.Framework.Extensions;

namespace XD.Framework.Validator
{
    /// <summary>
    /// 适用于枚举的验证
    /// </summary>
    public static class EnumFieldValidator
    {
        /// <summary>
        /// 验证不允许在 enums 范围内
        /// </summary>
        /// <param name="field"></param>
        /// <param name="enums"></param>
        /// <returns></returns>
        public static EnumField NotIn(this EnumField field, params Enum[] enums)
        {
            if (field.ShouldValidate)
                if (enums.Any(t => t.Equals(field.Value)))
                    throw new ValidationException(string.Format("{0}：不允许是{1}！", field.DisplayName, enums.Montage(t => EnumDescription.GetFieldText(t), "、")));

            return field;
        }

        /// <summary>
        /// 验证必须在 enums 范围内
        /// </summary>
        /// <param name="field"></param>
        /// <param name="enums"></param>
        /// <returns></returns>
        public static EnumField In(this EnumField field, params Enum[] enums)
        {
            if (field.ShouldValidate)
                if (enums.Any(t => t.Equals(field.Value)) == false)
                    throw new ValidationException(string.Format("{0}：必须是{1}{2}！", field.DisplayName, enums.Montage(t => EnumDescription.GetFieldText(t), "、"),
                        (enums.Count()>=2? "之一" : string.Empty)));

            return field;
        }

        /// <summary>
        /// 验证必须等于
        /// </summary>
        /// <param name="field"></param>
        /// <param name="other"></param>
        /// <param name="customMsg"></param>
        /// <returns></returns>
        public static EnumField BeEqualTo(this EnumField field, Enum other, string customMsg="")
        {
            if (field.ShouldValidate)
                if (field.Value.Equals(other)==false)
                    throw new ValidationException(string.IsNullOrEmpty(customMsg)?
                        string.Format("{0}：必须是{1}！", field.DisplayName, other.ToString()) : customMsg);

            return field;
        }

        /// <summary>
        /// 验证不允许等于
        /// </summary>
        /// <param name="field"></param>
        /// <param name="other"></param>
        /// <param name="customMsg"></param>
        /// <returns></returns>
        public static EnumField NotBeEqualTo(this EnumField field, Enum other, string customMsg = "")
        {
            if (field.ShouldValidate)
                if (field.Value.Equals(other) == true)
                    throw new ValidationException(string.IsNullOrEmpty(customMsg) ?
                        string.Format("{0}：不允许是{1}！", field.DisplayName, other.ToString()) : customMsg);

            return field;
        }
    }
}
