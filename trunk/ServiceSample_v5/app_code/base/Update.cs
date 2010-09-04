
using System;
using System.Data;
using System.Data.Common;
using System.Web.UI;

namespace CYU.ServiceSample {

public class Update: MemberPage {
	
	//本頁 示範 如何從 資料庫 中抓出資料	
	public override void Member_Page(object sender,EventArgs e){
		
		if (checkDataValid()){

			string sql = "update sampleTable set title='@title', auther = '@auther', publisher = '@publisher', bookyear = '@bookyear', price ='@price' where bookid='@bookid'  ";
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

            Response.Write(Message.MessagePage("資料已正確更新！！！", "Query.aspx"));
            return;

		}
		else {
            Response.Write(Message.MessagePage("資料有誤，無法更新！！！", "Query.aspx"));
            return;
		}

	} // end of InitPage
	
	private bool checkDataValid(){
		return true;    //檢查資料之正確性可放在這裡。
	}

}  // end of class

}  // end of namespace




