
using System;
using System.Data;
using System.Data.Common;
using System.Web.UI;

namespace CYU.ServiceSample {

public class Logout : GuestPage
{


	//PageLoad 會檢查是否 己登入，故 在此需 在 pageload 之前 做 ，故需 覆寫 BeforePageLoad
	public override void Guest_Page(object sender,EventArgs e){

        //清空 session
        //Session["User"] = null;
        Session.Clear();

        Response.Redirect("Login.aspx");


	} // end of Guest_Page

	

}  // end of class

}  // end of namespace




