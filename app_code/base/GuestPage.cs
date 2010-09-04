
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace CYU.ServiceSample {

public class GuestPage: BasePage {

	// 將 本系統中 所有 網頁 都要做的事 寫在這裡
	public override void Page_Load(object sender,EventArgs e){

		// 取得 db 連線
		try{
			connection = DBOperation.getConnection();
			connection.Open();
		} 
		catch(Exception ex){
			Session["errorMessage"] = "資料庫連線無法建立，請連絡系統維護者！";
			Session["topage"] = "blank.aspx";
			Response.Redirect("service.aspx?page=Message");
						
		}
				
		// 基本上，專門給 login.aspx 和 loginverify.aspx 和一些特殊的頁面(就是 不用檢查是否已 login 的各頁面)
		Guest_Page(sender, e);

		if (connection != null) connection.Close();
		
	} // end of Page_Load
	
	
	public virtual void Guest_Page(object sender,EventArgs e){

		//虛的，給 系統開發者 覆寫用的

	} // end of BeforePageLoad
	
}  // end of class

}  // end of namespace




