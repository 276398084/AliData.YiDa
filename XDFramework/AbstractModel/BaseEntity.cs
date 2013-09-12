﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XD.Framework.AbstractModel
{
    /// <summary>
    /// 数据实体基类
    /// </summary>
    public abstract class BaseEntity : OITObject
    {
        public BaseEntity()
        {

            this.CreateTime = DateTime.Now;
        }
        /// <summary>
        /// 主键
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// 并发控制标识
        /// </summary>
        public virtual Int32 Version { get; private set; }

        /// <summary>
        /// 数据创建时间
        /// <remarks>归档用，不可与业务时间混用</remarks>
        /// </summary>
        public virtual DateTime CreateTime { get; private set; }

        public virtual void SetId(int id)
        {
            this.Id = id;
        }

        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(this, obj))
            {
                return true;
            }
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Entity return false.
            BaseEntity entity = obj as BaseEntity;
            if ((System.Object)entity == null)
            {
                return false;
            }

            if (Id == 0)
            {
                return false;
            }
            //if (Id == null || Id == string.Empty || entity.Id == null || entity.Id == string.Empty)
            //{
            //    return false;
            //}

            // Return true if the Id match:
            return Id == entity.Id;
        }

        public static bool operator ==(BaseEntity a, BaseEntity b)
        {
            // If both are null or both are same instance, return true.
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            if (a.Id == 0)
                return false;
            //if (Id == null || Id == string.Empty || entity.Id == null || entity.Id == string.Empty)
            //{
            //    return false;
            //}

            // Return true if the Id match:
            return a.Id == b.Id;
        }

        public override int GetHashCode()
        {
            return Id == null ? base.GetHashCode() : Id.GetHashCode();
        }

        public static bool operator !=(BaseEntity a, BaseEntity b)
        {
            return !(a == b);
        }
    }
}
