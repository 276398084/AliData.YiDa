using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XD.Framework.Cache
{
    public class ThreadCache : ICache
    {
        private static IDictionary<string, object> applicationCache; // 应用程序级缓存字典
        private static object applicationCacheLocker = new object(); // 应用程序级缓字典存并发冲突锁对象
        #region ICache 成员
        /// <summary>
        /// 应用程序级缓存字典
        /// </summary>
        private static IDictionary<string, object> ApplicationCache
        {
            get
            {
                if (applicationCache == null)
                {
                    lock (applicationCacheLocker)
                    {
                        if (applicationCache == null) // double check
                        {
                            applicationCache = new Dictionary<string, object>();
                        }
                    }
                }

                return applicationCache;
            }
        }

        public object GetApplicationCache(string key)
        {
            if (ApplicationCache.ContainsKey(key))
                return ApplicationCache[key];
            else
                return null;
        }

        public void SetApplicationCache(string key, object obj)
        {
            lock (applicationCacheLocker)
            {
                ApplicationCache[key] = obj;
            }
        }

        public void RemoveApplicationCache(string key)
        {
            lock (applicationCacheLocker)
            {
                if (ApplicationCache.ContainsKey(key))
                    ApplicationCache.Remove(key);
            }
        }

        public void ReSetApplicationCache(string key, object obj)
        {
            lock (applicationCacheLocker)
            {
                ApplicationCache[key] = obj;
            }
        }

        public object GetSessionCache(string key)
        {
            throw new NotImplementedException();
        }

        public void SetSessionCache(string key, object obj)
        {
            throw new NotImplementedException();
        }

        public void RemoveSessionCache(string key)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
