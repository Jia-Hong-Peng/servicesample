
using System;
using System.Data;
using System.Data.Common;
using System.Web.UI;

namespace CYU.ServiceSample {

public class Update: MemberPage {
	
	//���� �ܽd �p��q ��Ʈw ����X���	
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

            Response.Write(Message.MessagePage("��Ƥw���T��s�I�I�I", "Query.aspx"));
            return;

		}
		else {
            Response.Write(Message.MessagePage("��Ʀ��~�A�L�k��s�I�I�I", "Query.aspx"));
            return;
		}

	} // end of InitPage
	
	private bool checkDataValid(){
		return true;    //�ˬd��Ƥ����T�ʥi��b�o�̡C
	}

}  // end of class

}  // end of namespace




