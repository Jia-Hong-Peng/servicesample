
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
		
		//�N�Ҧ� ������ �ݭn reload template �����g�b�o��
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
		
		string message = "�����d���w��s�G\\n" + pagenames
											+ "�I�@�U�^�t�έ���\\n"
											//+ "�������O�W�G" + this.GetType().Name 
											;
		Session["errorMessage"] = message;
		Session["topage"] = "service.aspx?page=Default";
		Response.Redirect("service.aspx?page=Message");

		Response.Redirect("service.aspx?page=Default");
         * 
         * */

        Response.Write("�o�����O �L�@�ΡI");

	} // end of InitPage
	


}  // end of class

}  // end of namespace




