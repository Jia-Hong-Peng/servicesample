
using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace CYU.ServiceSample {

public class Function1: MemberPage {
	
	public override void Member_Page(object sender,EventArgs e){
		
		Response.Write(p.name +  " �z�n�I......." );
		Response.Write("<br>function1 �ܰ������z�A�ȡI " );
		
	} // end of InitPage
	


}  // end of class

}  // end of namespace




