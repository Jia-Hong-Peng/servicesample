
using System;
using System.Data;
using System.Data.Common;
using System.Web.UI;

namespace CYU.ServiceSample {

public class MemberPage: BasePage {

	//於 CheckLogin 之後，自 Session 中取出，方便所有 繼承 MemberPage 的網頁使用 
	protected User p;

	// 將 本系統中 所有 網頁 都要做的事 寫在這裡
	public override void Page_Load(object sender,EventArgs e){

		//這一段 可使 網頁每次被讀取時 均能重新更新
        Response.Expires = 0;
        Response.AppendHeader("pragma","no-cache");
        Response.Cache.SetNoStore();

		// 取得 db 連線
		try{
            connection = DBOperation.getConnection();
			connection.Open();
		} 
		catch(Exception ex){

            //Response.Write(Message.MessagePage("資料庫連線無法建立，請連絡系統維護者！", "blank.aspx", Page));   // 
            Response.Write(Message.MessagePage("資料庫連線無法建立，請連絡系統維護者！", "blank.aspx"));
            return;
		}
		
		//檢查是否是 允許的 IP
		if (!CheckIP()){
			connection.Close();
            Response.Write(Message .MessagePage ("您的電腦位址無使用本服務之權限!!!", "blank.aspx"));
            return;

        }
		
		// 1. 檢查 是否 已登入
		if (!CheckLogin()) {
			
			connection.Close();
            Response.Write(Message.MessagePage("尚未登入!\\n或登入已逾時！!", "Login.aspx"));
            return;
		}		

		//已登入 才 抓得到 Session["User"]
		p = (User) Session["User"];
				
		// 2. 檢查 User 是否 具有 執行本頁面之權限 
		string thisPageName = this.GetType().Name;     //this.GetType().Name 抓出來會像是 login_aspx
		
		if (!p.checkRight(thisPageName, connection )){

			connection.Close();

			string message = "您無權限使用本頁!!!\\n"
												+ "請回系統首頁\\n"
												//+ "頁面類別名：" + this.GetType().Name 
												;

            Response.Write(Message.MessagePage(message, "Default.aspx"));
            return;
        }
			
		Member_Page(sender, e);    //給每一頁 真正 要做的事，寫在這裡

		if (connection != null) connection.Close();
		
	} // end of Page_Load
	
	
	// 每頁 的初始顯示 改成 用 InitPage()
	// 即 原本是要覆寫 Page_Load 的，改成 覆寫 InitPage
	public virtual void Member_Page(object sender, EventArgs e){
		
		//虛的，給 系統開發者 覆寫用的
		string output = displayOutput();
		Response.Write(output);
		
	} // end of InitPage

	//系統開發者 可視需求 覆寫 InitPage() 或 displayOutput() 兩個方法，[基本上，同時覆寫兩個是無意異的]
	//差異在於，InitPage()中是直接使用 Response.Write 來產生網頁內容
	//但是 displayOutput 則是 先將 網頁內容 寫到一個字串中，再回傳給 InitPage() 去顯示，	
	//使用 displayOutput() 是比較麻煩的，但是 回傳的結果 卻可跨頁顯示，這點開發者 可於累積足夠經驗後使用之。
	public virtual string displayOutput(){
		
		return "";
		
	} // end of InitPage
	
	
	//實際 檢查 IP 的 函數 
	private bool CheckIP(){
		return true;  //暫不檢查時，可加上此行
		
		string ip = Request.UserHostAddress;
		
		//執行命令
		string strSQL = "select * from AuthenticateIP where ip = '@ip' and isOpen= 'y' and getdate() between startdate and enddate ";
		strSQL = strSQL.Replace("@ip" , ip);

        DbDataAdapter adapter = DBOperation.getDataAdapter(strSQL, connection);
		
		DataSet ds = new DataSet();    
		adapter.Fill(ds, "IP");  
		
		if (ds.Tables["IP"].Rows.Count >= 1) return true;	
		else return false;	
		
	} // end of CheckIP
	
	
	//實際 檢查登入的 函數 
	private bool CheckLogin(){
		
		//return false;
		
		if (Session["User"] != null) {
			return true;
		}
		else return false;
		
	} // end of CheckLogin
	
}  // end of class

}  // end of namespace




