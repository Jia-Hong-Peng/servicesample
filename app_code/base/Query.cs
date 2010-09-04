
using System;
using System.Data;
using System.Data.Common;
using System.Web.UI;

namespace CYU.ServiceSample {

public class Query: MemberPage {
	
	static Template _template;
	static Template _loopSample;
    static string _templateFile = "query.html";
    static string _loopSampleFile = "queryOneBook.html";
	
//***********************************************************************************	
//
//***********************************************************************************	
    public Query()
    {
        if (_template == null || SystemConstant.TemplateReloading)
        {
            _template = new Template(_templateFile, SystemConstant.TemplatePath);
            _loopSample = new Template(_loopSampleFile, SystemConstant.TemplatePath);

        }
	}

//***********************************************************************************	
//
//***********************************************************************************	
	//本頁 示範 如何從 資料庫 中抓出資料	
	//並 示範 對於 多筆資料顯示的方式
	public override void Member_Page(object sender,EventArgs e){
		
		//執行命令
		string strSQL = "select * from sampleTable ";
		//strSQL = strSQL.Replace("@id" , id);

        DbDataAdapter adapter = DBOperation.getDataAdapter(strSQL, connection);
		
		DataSet ds = new DataSet();    
		adapter.Fill(ds, "t");  
		
		//讀入整頁的html
		string output = _template.Content;

		//以下 示範 對於 多筆資料顯示的方式
		//讀入 單筆 的顯示html樣版
		string loopSample = _loopSample.Content;

		string books = "";
		
		//利用 for 迴圈 及 單筆的樣版 製做 顯示多筆記錄 用的html 
		for (int i=0; i<ds.Tables["t"].Rows.Count; i++){
			string s = loopSample;
			s = s.Replace("__bookid__", (string)ds.Tables["t"].Rows[i]["bookid"]);
			s = s.Replace("__title__", (string)ds.Tables["t"].Rows[i]["title"]);
			s = s.Replace("__auther__", (string)ds.Tables["t"].Rows[i]["auther"]);
			s = s.Replace("__publisher__", (string)ds.Tables["t"].Rows[i]["publisher"]);
			s = s.Replace("__year__", (string)ds.Tables["t"].Rows[i]["bookyear"]);
			s = s.Replace("__price__", ""+ ds.Tables["t"].Rows[i]["price"]);          // 注意，price 的型態是 int，所以 用 "" + int 的方式去轉換成字串 (這是 資料表 的定義)
			
			books += s;
			
		}
	 	
	 	//透過 tag 將 上面得到的 多筆顯示html 匯入 整頁的html 中。
		output = output.Replace("__books__" , books );
		
		Response.Write(output);

	} // end of InitPage
//***********************************************************************************	
//
//***********************************************************************************	
	


}  // end of class

}  // end of namespace




