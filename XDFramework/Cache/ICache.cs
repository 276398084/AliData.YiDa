using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XD.Framework.Cache
{
    /// <summary>
    /// 系统缓存类操作统一走此接口
    /// </summary>
    public interface ICache
    {
        object GetApplicationCache(string key);

        void SetApplicationCache(string key, object obj);

        void RemoveApplicationCache(string key);

        void ReSetApplicationCache(string key, object obj);

        object GetSessionCache(string key);

        void SetSessionCache(string key, object obj);

        void RemoveSessionCache(string key);
    }
}
