
using System;
using System.Data;
using System.Data.Common;
using System.Web.UI;

namespace CYU.ServiceSample {

public class Logout : GuestPage
{


	//PageLoad �|�ˬd�O�_ �v�n�J�A�G �b���� �b pageload ���e �� �A�G�� �мg BeforePageLoad
	public override void Guest_Page(object sender,EventArgs e){

        //�M�� session
        //Session["User"] = null;
        Session.Clear();

        Response.Redirect("Login.aspx");


	} // end of Guest_Page

	

}  // end of class

}  // end of namespace




