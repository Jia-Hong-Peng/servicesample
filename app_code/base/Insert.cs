
using System;
using System.Data;
using System.Data.Common;
using System.Web.UI;

namespace CYU.ServiceSample {

public class Insert: MemberPage {
	
	//本頁 示範 如何從 資料庫 中抓出資料	
	public override void Member_Page(object sender,EventArgs e){
		
		if (checkDataValid()){

			string sql = "insert into sampleTable values('@bookid', '@title', '@auther', '@publisher', '@bookyear', '@price' )  ";
            sql = sql.Replace("@bookid", RequstAvoidSQLInjection["bookid"]);
            sql = sql.Replace("@title", RequstAvoidSQLInjection["title"]);
            sql = sql.Replace("@auther", RequstAvoidSQLInjection["auther"]);
            sql = sql.Replace("@publisher", RequstAvoidSQLInjection["publisher"]);
            sql = sql.Replace("@bookyear", RequstAvoidSQLInjection["bookyear"]);
            sql = sql.Replace("@price", RequstAvoidSQLInjection["price"]);
	
			//throw new Exception(sql);

            DbCommand command = DBOperation.getCommand(sql, connection);
	        command.ExecuteScalar();
	    
			connection.Close();
	
			Session["errorMessage"] = "資料已正確新增！！！";
			Session["topage"] = "service.aspx?page=Query";
			Response.Redirect("service.aspx?page=Message");
		}
		else {
			Session["errorMessage"] = "資料有誤，無法新增！！！";
			Session["topage"] = "service.aspx?page=Query";
			Response.Redirect("service.aspx?page=Message");
		}

	} // end of InitPage
	
	private bool checkDataValid(){
		return true;    //檢查資料之正確性可放在這裡。
	}

}  // end of class

}  // end of namespace




