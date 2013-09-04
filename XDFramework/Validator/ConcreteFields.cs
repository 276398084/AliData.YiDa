using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XD.Framework.AbstractModel;

namespace XD.Framework.Validator
{
    public class StringField : FieldWapper<StringField, string>
    {
        public StringField(string v) : this(v, true) { }
        public StringField(string v, bool shouldValidate) : base(v, shouldValidate) { }
    }

    public class BooleanField : FieldWapper<BooleanField, bool>
    {
        public BooleanField(bool v) : this(v, true) { }
        public BooleanField(bool v, bool shouldValidate) : base(v, shouldValidate) { }
    }

    public class Int32Field : FieldWapper<Int32Field, int>, IComparableField<int>
    {
        public Int32Field(int v) : this(v, true) { }
        public Int32Field(int v, bool shouldValidate) : base(v, shouldValidate) { }

        int IComparableField<int>.CompareTo(int other)
        {
            return Value.CompareTo(other);
        }
    }

    public class Int64Field : FieldWapper<Int64Field, long>, IComparableField<long>
    {
        public Int64Field(long v) : this(v, true) { }
        public Int64Field(long v, bool shouldValidate) : base(v, shouldValidate) { }

        int IComparableField<long>.CompareTo(long other)
        {
            return Value.CompareTo(other);
        }
    }

    public class EntityField : FieldWapper<EntityField, BaseEntity>
    {
        public EntityField(BaseEntity v) : this(v, true) { }
        public EntityField(BaseEntity v, bool shouldValidate) : base(v, shouldValidate) { }
    }

    public class DecimalField : FieldWapper<DecimalField, decimal>, IComparableField<decimal>
    {
        public DecimalField(decimal v) : this(v, true) { }
        public DecimalField(decimal v, bool shouldValidate) : base(v, shouldValidate) { }

        int IComparableField<decimal>.CompareTo(decimal other)
        {
            return Value.CompareTo(other);
        }
    }

    public class DateTimeField : FieldWapper<DateTimeField, DateTime>, IComparableField<DateTime>
    {
        public DateTimeField(DateTime v) : this(v, true) { }
        public DateTimeField(DateTime v, bool shouldValidate) : base(v, shouldValidate) { }

        int IComparableField<DateTime>.CompareTo(DateTime other)
        {
            return Value.CompareTo(other);
        }
    }

    public class NullableField<TInnerValue> : FieldWapper<NullableField<TInnerValue>, Nullable<TInnerValue>> where TInnerValue : struct
    {
        public NullableField(Nullable<TInnerValue> v) : this(v, true) { }
        public NullableField(Nullable<TInnerValue> v, bool shouldValidate) : base(v, shouldValidate) { }
    }

    public class EnumField : FieldWapper<EnumField, Enum>
    {
        public EnumField(Enum v) : this(v, true) { }
        public EnumField(Enum v, bool shouldValidate) : base(v, shouldValidate) { }
    }

    public class CollectionField<TInnerValue> : FieldWapper<CollectionField<TInnerValue>, ICollection<TInnerValue>>
    {
        public CollectionField(ICollection<TInnerValue> v) : this(v, true) { }
        public CollectionField(ICollection<TInnerValue> v, bool shouldValidate) : base(v, shouldValidate) { }
    }
}
