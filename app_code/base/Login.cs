
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
		
		// 建構子 第一個參數為 檔名，第二個參數 傳過去主要是要取得檔案真實位置
		// 建構子 中 會自動 代換 __StylePath__ ，請特別注意，若要變更，請記得 Template.cs 的程式碼要改
        string output = _template.Content;

		Response.Write(output);
		
	}
//***********************************************************************************	
//
//***********************************************************************************	


}  // end of class

}  // end of namespace




