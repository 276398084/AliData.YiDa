using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XD.Framework.AbstractModel;

namespace XD.Framework.Validator
{
    /// <summary>
    /// 创建具体Field的工厂
    /// </summary>
    public static class FieldWapperFactory
    {
        public static StringField Should(this string v)
        {
            return new StringField(v);
        }

        public static Int32Field Should(this int v)
        {
            return new Int32Field(v);
        }

        public static Int64Field Should(this long v)
        {
            return new Int64Field(v);
        }

        /// <summary>
        /// 注意：使用bool类型验证时，UseDisplayName()的参数为属性为真时要显示的文字。
        /// 例：entity.Item.IsGroup.Should().UseDisplayName("是组套项").BeFalse()，验证
        /// 失败时将显示错误信息“不允许是组套项！”
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static BooleanField Should(this bool v)
        {
            return new BooleanField(v);
        }

        public static DecimalField Should(this decimal v)
        {
            return new DecimalField(v);
        }

        public static DateTimeField Should(this DateTime v)
        {
            return new DateTimeField(v);
        }

        public static NullableField<TInnerValue> Should<TInnerValue>(this Nullable<TInnerValue> v) where TInnerValue : struct
        {
            return new NullableField<TInnerValue>(v);
        }

        public static Int32Field WhenHasValueShould(this NullableField<int> field)
        {
            if (field.Value.HasValue)
                return new Int32Field(field.Value.Value, true).UseDisplayName(field.DisplayName);
            else
                return new Int32Field(int.MinValue, false).UseDisplayName(field.DisplayName);
        }

        public static DecimalField WhenHasValueShould(this NullableField<decimal> field)
        {
            if (field.Value.HasValue)
                return new DecimalField(field.Value.Value, true).UseDisplayName(field.DisplayName);
            else
                return new DecimalField(decimal.MinValue, false).UseDisplayName(field.DisplayName);
        }

        public static DateTimeField WhenHasValueShould(this NullableField<DateTime> field)
        {
            if (field.Value.HasValue)
                return new DateTimeField(field.Value.Value, true).UseDisplayName(field.DisplayName);
            else
                return new DateTimeField(DateTime.MinValue, false).UseDisplayName(field.DisplayName);
        }

        public static StringField WhenNotNullOrEmptyShould(this StringField field)
        {
            if (!string.IsNullOrEmpty(field.Value))
                return new StringField(field.Value, true).UseDisplayName(field.DisplayName);
            else
                return new StringField(field.Value, false).UseDisplayName(field.DisplayName);
        }

        public static EntityField Should(this BaseEntity v)
        {
            return new EntityField(v);
        }

        public static EnumField Should(this Enum v)
        {
            return new EnumField(v);
        }

        public static CollectionField<TInnerValue> Should<TInnerValue>(this ICollection<TInnerValue> v)
        {
            return new CollectionField<TInnerValue>(v);
        }
    }
}
