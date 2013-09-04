using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XD.Framework.Util
{
    /// <summary>
    /// 日期相关帮助类
    /// </summary>
    public class DateTimeHelper
    {
        /// <summary>
        /// 返回所有月份列表
        /// </summary>
        /// <returns></returns>
        public static IList<KeyValuePair<string, int>> GetMonth()
        {
            var list = new List<KeyValuePair<string, int>>();
            list.Add(new KeyValuePair<string, int>("一月", 1));
            list.Add(new KeyValuePair<string, int>("二月", 2));
            list.Add(new KeyValuePair<string, int>("三月", 3));
            list.Add(new KeyValuePair<string, int>("四月", 4));
            list.Add(new KeyValuePair<string, int>("五月", 5));
            list.Add(new KeyValuePair<string, int>("六月", 6));
            list.Add(new KeyValuePair<string, int>("七月", 7));
            list.Add(new KeyValuePair<string, int>("八月", 8));
            list.Add(new KeyValuePair<string, int>("九月", 9));
            list.Add(new KeyValuePair<string, int>("十月", 10));
            list.Add(new KeyValuePair<string, int>("十一月", 11));
            list.Add(new KeyValuePair<string, int>("十二月", 12));
            return list;
        }

        /// <summary>
        /// 获取当前日期的中文星期
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string Week(DateTime date)
        {
            string[] weekdays = { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            string week = weekdays[Convert.ToInt32(date.DayOfWeek)];
            return week;
        }

        /// <summary>
        /// 返回当前月之后的月份列表
        /// </summary>
        /// <returns></returns>
        public static IList<KeyValuePair<string, int>> GetAfterMonth()
        {
            var list = GetMonth();
            var nowMonth = DateTime.Today.Month;
            var q = from l in list
                    where l.Value >= nowMonth
                    select l;
            return q.ToList();
        }

        /// <summary>
        /// 获取今年指定月份的第一天
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public static DateTime GetStartDayOfNowYear(int month)
        {
            var year = DateTime.Now.Year;
            return new DateTime(year, month, 1);
        }
        /// <summary>
        /// 获取当月的最后一天
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static DateTime LastDayOfMonth(DateTime datetime)
        {
            return datetime.AddDays(1 - datetime.Day).AddMonths(1).AddDays(-1);
        }
        /// <summary>
        /// 获取指定年月星期的第一天
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static DateTime GetStartDayOfWeeks(int year, int month, int index)
        {

            DateTime startMonth = new DateTime(year, month, 1);  //该月第一天
            int dayOfWeek = 7;
            if (Convert.ToInt32(startMonth.DayOfWeek.ToString("d")) > 0)
                dayOfWeek = Convert.ToInt32(startMonth.DayOfWeek.ToString("d"));  //该月第一天为星期几
            DateTime startWeek = startMonth.AddDays(1 - dayOfWeek);  //该月第一周开始日期
            //DateTime startDayOfWeeks = startWeek.AddDays((index - 1) * 7);  //index周的起始日期
            DateTime startDayOfWeeks = startWeek.AddDays(index * 7);  //index周的起始日期

            return startDayOfWeeks;
        }

        /// <summary>
        /// 获取日期的开始时间
        /// <remarks>例如，输入 2010-1-1 13:55:12，返回 2010-1-1 00:00:00</remarks>
        /// </summary>
        /// <param name="date"></param>
        public static DateTime GetStartTime(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
        }

        /// <summary>
        /// 获取日期的结束时间
        /// <remarks>例如，输入 2010-1-1 13:55:12，返回 2010-1-1 23:59:59</remarks>
        /// </summary>
        /// <param name="date"></param>
        public static DateTime GetEndTime(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);
        }
    }
}
