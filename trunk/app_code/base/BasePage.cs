
using System;
using System.Web;
using System.Web.UI;
using System.Web.SessionState;
using System.Data.Common;


namespace CYU.ServiceSample {

public class BasePage {

	protected Page Page;
    //protected HttpContext context;
	protected HttpResponse Response ;
	protected HttpRequest Request;
	protected HttpServerUtility Server ;
	protected HttpApplicationState Application;
	protected HttpSessionState Session;

    protected HttpRequestAvoidSQLInjection RequstAvoidSQLInjection;

	protected DbConnection connection;

    public void initPage(Page page)
    {

        this.Page = page;
        this.Response = page.Response;
        this.Request = page.Request;
        this.Server = page.Server;
        this.Application = page.Application;
        this.Session = page.Session;

        this.RequstAvoidSQLInjection = new HttpRequestAvoidSQLInjection(this.Request);

    }

	
	
	// 將 本系統中 所有 網頁 都要做的事 寫在這裡
	public virtual void Page_Load(object sender,EventArgs e){

	} // end of Page_Load
	
	
}  // end of class

}  // end of namespace




