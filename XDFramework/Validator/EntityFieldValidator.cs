using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XD.Framework.Exceptions;

namespace XD.Framework.Validator
{
    /// <summary>
    /// 适用于实体对象的验证
    /// </summary>
    public static class EntityFieldValidator
    {
        /// <summary>
        /// 验证不允许为空
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public static EntityField NotBeNull(this EntityField field, string customMsg="")
        {
            if (field.ShouldValidate)
                if (field.Value == null)
                    throw new ValidationException((string.IsNullOrEmpty(customMsg) ?
                        string.Concat(field.DisplayName, "：不允许为空！") : customMsg));

            return field;
        }

        ///// <summary>
        ///// 验证是否允许修改
        ///// <remarks>一般用于父锁定后不允许修改子</remarks>
        ///// </summary>
        ///// <param name="field"></param>
        ///// <returns></returns>
        //public static EntityField CanBeChange(this EntityField field, string customMsg = "")
        //{
        //    if (field.ShouldValidate)
        //        if (field.Value.BeChange == false)
        //            throw new LockException((string.IsNullOrEmpty(customMsg) ?
        //                string.Concat(field.DisplayName, "：数据已锁定，不允许修改！") : customMsg));

        //    return field;
        //}
    }
}
