
using System;
using System.Data;
using System.Data.Common;
using System.Web.UI;

namespace CYU.ServiceSample {

public class User {
	
	public string id;
	public string name;
	public string ip;
	//public string[] functions={"default_aspx", "function1_aspx"};    //這裡列出 每個 User 可使用的頁面，格式為：<page name>_aspx
	
	public User(string id, string ip, DbConnection connection){

		string strSQL = "select a.uid, b.username from Users a join user_info b on a.uid=b.uid where a.uid = '@id'  ";
		strSQL = strSQL.Replace("@id" , id);

        DbDataAdapter adapter = DBOperation.getDataAdapter(strSQL, connection);
		
		DataSet ds = new DataSet();    
		adapter.Fill(ds, "Users");

        //sample5 改成 從資料庫中抓取的 id 為準(也就是重設一次 id)
        this.id = (string)(ds.Tables["Users"].Rows[0]["uid"]);               
        this.name = (string)(ds.Tables["Users"].Rows[0]["username"]);
		this.ip = ip;
		
	}
	
	public bool checkRight(string fucntionName, DbConnection connection){
		
		if (fucntionName.Equals("Default") ) return true;  //本範例 系統 預設 Default 是 所有 登入者都有權限
		
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




