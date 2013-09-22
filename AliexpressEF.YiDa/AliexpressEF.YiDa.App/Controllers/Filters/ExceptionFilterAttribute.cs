using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using XD.Framework.Exceptions;

namespace AliexpressEF.YiDa.Controllers.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class ExceptionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Exception == null)
                return;
            var excResult = new ContentResult();
            string msgTmp;
            if (filterContext.Exception is ValidationException)//如果是验证类异常 ，就不出详细异常信息了
                msgTmp = @"ShowErrorMsg('验证错误', '{0}')";
            else
                msgTmp = @"ShowErrorMsg('系统错误', '<b>异常消息: {0}</br><b>触发Action: {1}</br><b>异常类型:  </b>{2}')";
            excResult.Content = String.Format(msgTmp,
                    filterContext.Exception.GetBaseException().Message,
                    filterContext.ActionDescriptor.ActionName,
                    filterContext.Exception.GetBaseException().GetType().ToString());
            filterContext.Result = excResult;
            filterContext.ExceptionHandled = true;
        }
    }
}
