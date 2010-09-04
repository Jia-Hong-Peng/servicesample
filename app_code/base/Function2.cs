
using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace CYU.ServiceSample {

public class Function4: MemberPage {

	public override string displayOutput(){
		
		string output = p.name +  " 您好！" ;
		output += "<br>function1 很高興為您服務！ " ;
		
		return output;
		
	} // end of displayOutput
	
	
}  // end of class

}  // end of namespace




