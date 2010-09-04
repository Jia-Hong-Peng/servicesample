
using System;
using System.Data;
using System.Data.Common;
using System.Web.UI;

namespace CYU.ServiceSample {

public class LoginVerify: GuestPage {


	//PageLoad 會檢查是否 己登入，故 在此需 在 pageload 之前 做 ，故需 覆寫 BeforePageLoad
	public override void Guest_Page(object sender,EventArgs e){

        //清空 session
        //Session["User"] = null;
        Session.Clear();

		if (check()) {

            //Response.Write("登入成功");
            //return;

            setSession();

			connection.Close();  // redirect 前 要關 connection
			
			//用 重導向的方法，缺點是 在網址列上 會看到 ?page=Default
            //Response.Redirect("service.aspx?page=Default");
            Response.Redirect("Default.aspx");
            //Server.Transfer("service.aspx?page=Default");


			// 另一種方式，不顯示 page ，不建議使用
			// 要導向到哪一個 page，就修改 Default，語法如下：
			// <page name> p = new <page name>();
			// p.RedirectToThisPage(Page, sender, e);

			//Default p = new Default();                 
			//p.RedirectToThisPage(Page, sender, e);
		}
		else {
			connection.Close();  // redirect 前 要關 connection

			//"驗證錯誤，請重新輸入帳號密碼！";
            Response.Write(Message.MessagePage("驗證失敗，請重新登入！！！！", "Login.aspx"));
            return;
        }
			
	} // end of Guest_Page

	
	private bool check()  {
        //return true;

        string id = RequstAvoidSQLInjection["id"].Trim();   //處理 SQL Injection
        string password = RequstAvoidSQLInjection["password"].Trim();
		
		//執行命令
        //使用 join user_info 以確保 users 及 user_info 中均有資料
        string strSQL = "select a.uid, a.password from Users a join user_info b on a.uid=b.uid where a.uid = '@id' and a.password = '@password' ";
		strSQL = strSQL.Replace("@id" , id);
		strSQL = strSQL.Replace("@password" , password);
		
	    DbDataAdapter adapter = DBOperation .getDataAdapter(strSQL, connection);
		
		DataSet ds = new DataSet();    
		adapter.Fill(ds, "User");

        if (ds.Tables["User"].Rows.Count >= 1)
        {
            //再驗一次
            //會分大小寫
            if (ds.Tables["User"].Rows[0]["password"].ToString().Equals(password) && ds.Tables["User"].Rows[0]["uid"].ToString().Equals(id))
                return true;
            else return false;
        }
        else return false;	
				
	}
		
	public void setSession( ){
        User p = new User(Request["id"].Trim().Replace("'", "''"), Request.UserHostAddress, connection);
		Session["User"] = p;
	}

}  // end of class

}  // end of namespace




