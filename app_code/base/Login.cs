
using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Data;
using CYU;


namespace CYU.ServiceSample {

public class Login: GuestPage {

	static Template _template;
    static string _templateFile = "login.html";
	
//***********************************************************************************	
//
//***********************************************************************************	
    public Login()
    {
        if (_template == null || SystemConstant.TemplateReloading)
        {
            _template = new Template(_templateFile, SystemConstant.TemplatePath);

        }
	}

//***********************************************************************************	
//
//***********************************************************************************	
	public override void Guest_Page(object sender,EventArgs e){
		
		// �غc�l �Ĥ@�ӰѼƬ� �ɦW�A�ĤG�ӰѼ� �ǹL�h�D�n�O�n���o�ɮׯu���m
		// �غc�l �� �|�۰� �N�� __StylePath__ �A�ЯS�O�`�N�A�Y�n�ܧ�A�аO�o Template.cs ���{���X�n��
        string output = _template.Content;

		Response.Write(output);
		
	}
//***********************************************************************************	
//
//***********************************************************************************	


}  // end of class

}  // end of namespace




