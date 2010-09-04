
using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace CYU.ServiceSample {

public class Default: MemberPage {
	
	static Template _template;
    static string _templateFile = "default.html";
	
//***********************************************************************************	
//
//***********************************************************************************	
	public Default(){
        if (_template == null || SystemConstant.TemplateReloading)
        {
            _template = new Template(_templateFile, SystemConstant.TemplatePath);

        }
	}
	
//***********************************************************************************	
//
//***********************************************************************************	
	public override void Member_Page(object sender,EventArgs e){
		
		//這裡，Replace 為 Template 中的方法，不過，只是很單純的做字串取代的動作
      string output = _template.Content;

		output = output.Replace("__username__" , p.name );

		Response.Write(output);

	} // end of InitPage
	


}  // end of class

}  // end of namespace




