
using System;
using System.Data.SqlClient;
using System.Web.UI;
using CYU;

namespace CYU.ServiceSample {

public class Message: BasePage {

	static Template _template;
    static string _templateFile = "message.html";
	
    //***********************************************************************************	
    // 透過 private 的建構子，讓 Message 無法實體化
    //***********************************************************************************	
    private Message(){	}


    //***********************************************************************************	
    // 提供 靜態呼叫，傳入 message, topage ，直接產生欲輸出之 MessagePage 內容，回傳給呼叫者
    //***********************************************************************************	
    public static string MessagePage(string message, string topage)
    {
        if (_template == null) _template = new Template(_templateFile, SystemConstant.TemplatePath);

        string output = _template.Content;

        output = output.Replace("__errorMessage__", message);
        output = output.Replace("__topage__", topage);

        return output;
    }

    
    //***********************************************************************************	
    // 提供 靜態呼叫，傳入 message, topage ，直接產生欲輸出之 MessagePage 內容，回傳給呼叫者
    //***********************************************************************************	
    public static string MessagePage(string message, string topage, Page page)
    {
        if (_template == null) _template = new Template(_templateFile, SystemConstant.TemplatePath);

        string output = _template.Content;

        //從 page 取得 網頁資源範例 如下：
        //string path = page.Server .MapPath ("\\");

        output = output.Replace("__errorMessage__", message);
        output = output.Replace("__topage__", topage);
        

        return output;
    }


//***********************************************************************************	
//
//***********************************************************************************	

    /* 移除此種方式，因為太麻煩了，不方便使用
    public override void Page_Load(object sender,EventArgs e){
		
		//這一段 可使 網頁每次被讀取時 均能重新更新
        Response.Expires = 0;
        Response.AppendHeader("pragma","no-cache");
        Response.Cache.SetNoStore();
        
        string output = _template.Content;

	 	string errorMessage = "無錯誤訊息！";
	 	if (Session["errorMessage"] != null) errorMessage = (string)Session["errorMessage"];
	 	string topage = "service.aspx";
	 	if (Session["topage"] != null) topage = (string)Session["topage"];
		output = output.Replace("__errorMessage__" , errorMessage  );
		output = output.Replace("__topage__" , topage  );

		Response.Write(output);

	}
    */

}  // end of class

}  // end of namespace




