using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace XD.Framework.Cache
{
    public class WebCache : ICache
    {
        #region ICache 成员

        public object GetApplicationCache(string key)
        {
            return HttpContext.Current.Application[key];
        }

        public void SetApplicationCache(string key, object obj)
        {
            HttpContext.Current.Application.Add(key, obj);
        }

        public void RemoveApplicationCache(string key)
        {
            HttpContext.Current.Application.Remove(key);
        }

        public void ReSetApplicationCache(string key, object obj)
        {
            RemoveApplicationCache(key);
            SetApplicationCache(key, obj);
        }

        public object GetSessionCache(string key)
        {
            return HttpContext.Current.Session[key];
        }

        public void SetSessionCache(string key, object obj)
        {
            HttpContext.Current.Session.Add(key, obj);
        }

        public void RemoveSessionCache(string key)
        {
            HttpContext.Current.Session.Remove(key);
        }

        #endregion
    }
}
