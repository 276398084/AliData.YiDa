using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web;
using System.IO;
using Newtonsoft.Json;

namespace XD.Framework.Presentation
{
    /// <summary>
    /// 系统定义的MVC json返回类型
    /// </summary>
    public class OITFJsonResult : ActionResult
    {
        public OITFJsonResult()
        {
            ContentType = "application/json";
        }
        public string[] ExceptMemberName { get; set; }
        public Object Data { get; set; }
        public string ContentType { get; set; }
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            HttpResponseBase response = context.HttpContext.Response;
            response.ContentType = ContentType;

            //如果是字符串直接输出
            if (Data is string)
            {
                response.Write(Data.ToString());
                return;
            }



            StringWriter sw = new StringWriter();
            JsonSerializer serializer = JsonSerializer.Create(
                new JsonSerializerSettings
                {
                    Converters = new JsonConverter[] { new Newtonsoft.Json.Converters.JavaScriptDateTimeConverter() },
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new NHibernateContractResolver(ExceptMemberName)
                }
                );

            using (JsonWriter jsonWriter = new JsonTextWriter(sw))
            {
                
                jsonWriter.Formatting = Formatting.Indented;
                serializer.Serialize(jsonWriter, Data);
            }
            response.Write(sw.ToString());
        }
    }
}
