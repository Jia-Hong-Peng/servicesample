
using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace CYU.ServiceSample {

public class ReloadTemplate: MemberPage {
	
//***********************************************************************************	
//
//***********************************************************************************	
	public override void Member_Page(object sender,EventArgs e){

		
        /*
		string pagenames="";
		
		//將所有 本網站 需要 reload template 的全寫在這裡
		Login.ReloadTamplate();
		pagenames += "Login\\n";
		Edit.ReloadTamplate();
		pagenames += "Edit\\n";
		Default.ReloadTamplate();
		pagenames += "Default\\n";
		
		Message.ReloadTamplate();
		pagenames += "Message\\n";
		Query.ReloadTamplate();
		pagenames += "Query\\n";
		
		string message = "網頁範本已更新：\\n" + pagenames
											+ "點一下回系統首頁\\n"
											//+ "頁面類別名：" + this.GetType().Name 
											;
		Session["errorMessage"] = message;
		Session["topage"] = "service.aspx?page=Default";
		Response.Redirect("service.aspx?page=Message");

		Response.Redirect("service.aspx?page=Default");
         * 
         * */

        Response.Write("這個類別 無作用！");

	} // end of InitPage
	


}  // end of class

}  // end of namespace




