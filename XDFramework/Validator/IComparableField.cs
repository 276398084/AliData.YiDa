using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XD.Framework.Validator
{
    /// <summary>
    /// 可比较大小的字段
    /// </summary>
    /// <typeparam name="TField"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public interface IComparableField<in TValue>
    {
        int CompareTo(TValue other);
    }
}
