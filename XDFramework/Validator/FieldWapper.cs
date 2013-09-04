using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XD.Framework.Validator
{
    /// <summary>
    /// 封装字段的值和显示名称等信息
    /// </summary>
    /// <typeparam name="TSubClass"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public abstract class FieldWapper<TSubClass, TValue> where TSubClass : class
    {
        private TValue _value; // 字段值
        protected string _displayName; // 字段的显示名称
        protected bool _shouldValidate; // 是否进行验证。如果此属性设置为false，针对此FieldWapper的所有验证都将失效。

        public FieldWapper(TValue v, bool shouldValidate)
        {
            _value = v;
            _displayName = string.Empty;
            _shouldValidate = shouldValidate;
        }
        /// <summary>
        /// 字段值
        /// </summary>
        public TValue Value { get { return _value; } }
        /// <summary>
        /// 字段的显示名称
        /// </summary>
        public string DisplayName { get { return _displayName; } }
        /// <summary>
        /// 是否进行验证。
        /// </summary>
        public bool ShouldValidate { get { return _shouldValidate; } }
        /// <summary>
        /// 设置字段的显示名称
        /// </summary>
        public TSubClass UseDisplayName(string displayName)
        {
            _displayName = displayName;
            return this as TSubClass;
        }
    }
}
