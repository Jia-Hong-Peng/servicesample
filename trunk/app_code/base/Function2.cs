
using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace CYU.ServiceSample {

public class Function4: MemberPage {

	public override string displayOutput(){
		
		string output = p.name +  " �z�n�I" ;
		output += "<br>function1 �ܰ������z�A�ȡI " ;
		
		return output;
		
	} // end of displayOutput
	
	
}  // end of class

}  // end of namespace




