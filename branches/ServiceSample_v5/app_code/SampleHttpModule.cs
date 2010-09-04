using System;
using System.Web;

namespace CYU.ServiceSample
{

    public class SampleHttpModule : IHttpModule
    {
        public SampleHttpModule()
        {
        }

        public string ModuleName
        {
            get { return "SampleHttpModule"; }
        }

        // In the Init function, register for HttpApplication 
        // events by adding your handlers.
        public void Init(HttpApplication application)
        {
            application.BeginRequest += (new EventHandler(this.Application_BeginRequest));
            //application.EndRequest += (new EventHandler(this.Application_EndRequest));

            //application.PostAuthorizeRequest += (new EventHandler(this.Application_BeginRequest));
        }

        private void Application_BeginRequest(Object source, EventArgs e)
        {
            // Create HttpApplication and HttpContext objects to access
            // request and response properties.
            HttpApplication application = (HttpApplication)source;
            HttpContext context = application.Context;
            
            //context.Response.Write("<h1><font color=red>HelloWorldModule: Beginning of Request</font></h1><hr>");

            //context.Response.Write("您要存取：" + context.Request.Url.ToString());

            String url = context.Request.Url.ToString();
            String[] urlParameters = url.Split(new char[]{'/'});   //tkli 20080608 依目前 url 的規定，長相都會是  ...../..../.....aspx?........
            if (urlParameters[urlParameters.Length - 1].IndexOf('.') > -1)
            {
                int index = urlParameters[urlParameters.Length - 1].IndexOf('.');
                String pageName = urlParameters[urlParameters.Length - 1].Substring(0, index);

                //if (pageName.Equals("service")) pageName = context.Request["page"];
                if (pageName.Equals("service")) return; // 此情形不用 重寫 URL
                
                if (urlParameters[urlParameters.Length - 1].Substring(index + 1).ToLower().StartsWith("aspx"))
                {
                    String pageParameter = urlParameters[urlParameters.Length - 1].Substring(index );
                    if (pageParameter.Length > 6) pageParameter = "&" + pageParameter.Substring(6);  //從第6位字元開始抓
                    else pageParameter = "";

                    if (pageName == null || (pageName.Equals ("service") && (context.Request["page"] ==null || context.Request["page"].Length == 0)))
                    {
                        context.RewritePath("service.aspx?page=Login");
                    }
                    else
                    {
                        context.RewritePath("service.aspx?page=" + pageName + pageParameter);
                    }

                }
                else
                {
                    context.Response.Write("不是執行aspx的程式!!");
                }

            }
            else {

                context.Response.Write("錯誤的URL!!");
            }

            
            //context.Response.End();

        } // end of Application_BeginRequest




        private void Application_EndRequest(Object source, EventArgs e)
        {
            HttpApplication application = (HttpApplication)source;
            HttpContext context = application.Context;
            context.Response.Write("<hr><h1><font color=red>HelloWorldModule: End of Request</font></h1>");
        }

        public void Dispose()
        {
        }
    }


}
