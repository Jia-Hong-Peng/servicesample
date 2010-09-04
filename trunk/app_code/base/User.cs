
using System;
using System.Data;
using System.Data.Common;
using System.Web.UI;

namespace CYU.ServiceSample {

public class User {
	
	public string id;
	public string name;
	public string ip;
	//public string[] functions={"default_aspx", "function1_aspx"};    //�o�̦C�X �C�� User �i�ϥΪ������A�榡���G<page name>_aspx
	
	public User(string id, string ip, DbConnection connection){

		string strSQL = "select a.uid, b.username from Users a join user_info b on a.uid=b.uid where a.uid = '@id'  ";
		strSQL = strSQL.Replace("@id" , id);

        DbDataAdapter adapter = DBOperation.getDataAdapter(strSQL, connection);
		
		DataSet ds = new DataSet();    
		adapter.Fill(ds, "Users");

        //sample5 �令 �q��Ʈw������� id ����(�]�N�O���]�@�� id)
        this.id = (string)(ds.Tables["Users"].Rows[0]["uid"]);               
        this.name = (string)(ds.Tables["Users"].Rows[0]["username"]);
		this.ip = ip;
		
	}
	
	public bool checkRight(string fucntionName, DbConnection connection){
		
		if (fucntionName.Equals("Default") ) return true;  //���d�� �t�� �w�] Default �O �Ҧ� �n�J�̳����v��
		
		string strSQL = "exec checkRight '@id', '@fucntionName'  ";
		strSQL = strSQL.Replace("@id" , this.id);
		strSQL = strSQL.Replace("@fucntionName" , fucntionName);

        DbDataAdapter adapter = DBOperation.getDataAdapter(strSQL, connection);
		
		DataSet ds = new DataSet();    
		adapter.Fill(ds, "Functions");  
		
		int functionCount = ds.Tables["Functions"].Rows.Count;
		
		if (ds.Tables["Functions"].Rows.Count >=1) return true;
		else return false;
				
	}


}  // end of class

}  // end of namespace




