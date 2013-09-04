using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace XD.Framework.Cache
{
    /// <summary>
    /// Session帮助类，Loader方法把一个对象的生命周期维护到一个Session中 
    /// </summary>
    public class SessionCacheUtil
    {
        //比如这是存储层返回PO的一个方法
        private string getXg(string param1, int param2, DateTime param3)
        {
            return "弦哥";
        }
        //Loader的使用方法
        private void example()
        {

            var po = Loader<string>
                ("SessionKey",//Session的Key
                () => getXg("string", 0, DateTime.Now));  //Lambda 表达式指定委托方法带上参数到一个匿名方法
        }
        /// <summary>
        /// 把一个对象的生命周期维护到一个Session中 
        /// <remarks>使用方法常见本类中exmaple方法</remarks>
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="key">Session的Key</param>
        /// <param name="func">Lambda 表达式定义参数的匿名委托方法</param>
        /// <returns>从Session中获取对象</returns>
        public static T Loader<T>(string key, Func<T> func)
        {
            if (GetSessionCache(key) == null)
            {
                T t = func();
                SetSessionCache(key, t);
            }
            return (T)GetSessionCache(key);
        }
        //从Session获取对象
        public static object GetSessionCache(string key)
        {
            return HttpContext.Current.Session[key];
        }
        //保存对象到Session
        public static void SetSessionCache(string key, object obj)
        {
            HttpContext.Current.Session.Add(key, obj);
        }
        //从Session中移除对象
        public static void RemoveSessionCache(string key)
        {
            HttpContext.Current.Session.Remove(key);
        }
    }
    //static class CacheDemo
    //{
    //    private static IDictionary<string, string> _cache = new Dictionary<string, string>();

    //    public static string CacheLoad(string key, Func<string> func)
    //    {
    //        if (_cache.ContainsKey(key))
    //        {
    //            Console.WriteLine("从 Cache 里取值");
    //            return _cache[key];
    //        }
    //        else
    //        {
    //            Console.WriteLine("从 func 里取值");
    //            string value = func();
    //            _cache.Add(key, value);
    //            return value;
    //        }
    //    }
    //}
    //class Program
    //{

    //    static string foo1(string key, string otherParam1)
    //    {
    //        return "景春雷";
    //    }

    //    static string foo2(string key, string otherParam1, string otherParam2)
    //    {
    //        return "章弦";
    //    }

    //    static void Main(string[] args)
    //    {
    //        string v1 = CacheDemo.CacheLoad("Key1", () => foo1("Key1", "aaa"));
    //        string v2 = CacheDemo.CacheLoad("Key1", () => foo2("Key1", "aaa", "bbb"));
    //        Console.WriteLine(v1);
    //        Console.WriteLine(v2);
    //    }
    //}

}


