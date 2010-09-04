
using System;
using System.Data;
using System.Data.Common;
using System.Web.UI;

namespace CYU.ServiceSample {

public class Edit: MemberPage {
	
	static Template _template;
    static string _templateFile = "edit.html";
	
//***********************************************************************************	
//
//***********************************************************************************	
    public Edit()
    {
        if (_template == null || SystemConstant.TemplateReloading)
        {
            _template = new Template(_templateFile, SystemConstant.TemplatePath);

        }
	}

//***********************************************************************************	
//
//***********************************************************************************	
	//本頁 示範 如何從 資料庫 中抓出資料	
	public override void Member_Page(object sender,EventArgs e){
		
    string output = _template.Content;

		//無 bookid 時
		if (Request["bookid"] == null){
			output = output.Replace("__bookid__" , "" );
			output = output.Replace("__title__" , "" );
			output = output.Replace("__auther__" , "" );
			output = output.Replace("__publisher__" , "" );
			output = output.Replace("__year__" , "" );
			output = output.Replace("__price__" , "" );
			
		}
		else {  //有 bookid 時，表查詢
			string strSQL = "select * from sampleTable where bookid='@bookid' ";
			strSQL = strSQL.Replace("@bookid" , Request["bookid"]);

            DbDataAdapter adapter = DBOperation.getDataAdapter(strSQL, connection);
			
			DataSet ds = new DataSet();    
			adapter.Fill(ds, "t");  
			
			output = output.Replace("__bookid__", (string)ds.Tables["t"].Rows[0]["bookid"]);
			output = output.Replace("__title__", (string)ds.Tables["t"].Rows[0]["title"]);
			output = output.Replace("__auther__", (string)ds.Tables["t"].Rows[0]["auther"]);
			output = output.Replace("__publisher__", (string)ds.Tables["t"].Rows[0]["publisher"]);
			output = output.Replace("__year__", (string)ds.Tables["t"].Rows[0]["bookyear"]);
			output = output.Replace("__price__", ""+ ds.Tables["t"].Rows[0]["price"]);              // 注意，price 的型態是 int，所以 用 "" + int 的方式去轉換成字串 (這是 資料表 的定義)
		}
		
		Response.Write(output);

	} // end of InitPage
	


}  // end of class

}  // end of namespace




