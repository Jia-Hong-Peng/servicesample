
using System;
using System.Web;
using System.Web.UI;
using CYU;
using System.Threading;


namespace CYU.ServiceSample {

public class Service: Page {

//***********************************************************************************	
//
//***********************************************************************************	
	public virtual void Page_Load(object sender,EventArgs e){

        // 給定 Template 的路徑
        if (SystemConstant.TemplatePath == null)
        {
            SystemConstant.TemplatePath = Server.MapPath(".") + "\\template\\style2\\";
        }
        
        //這一段 可使 網頁每次被讀取時 均能重新更新
        Response.Expires = 0;
        Response.AppendHeader("pragma","no-cache");
        Response.Cache.SetNoStore();

		string accessPage = Request["page"];
		if (accessPage == null) accessPage = "Login";

        goPage(sender, e, accessPage);

	} // end of Page_Load
//***********************************************************************************	
//
//***********************************************************************************	
    private void goPage(Object source, EventArgs e, String pageName)
    {
        try
        {

            //底下 這種方式的 關鍵 語法
            //利用 Type.GetType() 和 Activator.CreateInstance 兩個方式，直接利用 動態取得的 類別名 來建立該類別的物件
            //請注意，當 namespace 修改時，記得同時要修改 Type.GetType("CYU.ServiceSample." + accessPage, true) 中的 "CYU.ServiceSample." 
            Type theType = Type.GetType("CYU.ServiceSample." + pageName, true);
            BasePage p = (BasePage)Activator.CreateInstance(theType);    //建立 theType 的一個物件

            p.initPage(Page);
            p.Page_Load(source, e);

        }
        catch (TypeLoadException ex)   //此處只攔截 TypeLoadException
        {
            Response.Write("<font color=red>網址錯誤，欲存取的頁面不存在!!</font><br>輸入的頁面名為：" + pageName);
            Response.Write("<br/>若您操作無誤，且持續出現本訊息，請快照本頁面，並聯繫系統維護者處理。<br/><br/>");
            Response.Write("<br/>Url=" + Request.Url);
            Response.Write("<br/>UserHostAddress=" + Request.UserHostAddress);
            Response.Write("<br/>UserHostName=" + Request.UserHostName);
            Response.Write("<br/>DateTime=" + DateTime.Now.ToString());

            if (Request.IsLocal)
            {
                Response.Write("<br>更多訊息：<br>" + ex.ToString());
            }
        }
        catch (ThreadAbortException ex)
        {
            //不處理   //這部份 通常是 因為 redirect 造成
        }
        catch (Exception ex)    //此處攔截 其他的 Exception
        {

            Response.Write("頁面處理發生異常!!<br>輸入的頁面名為：" + pageName);
            Response.Write("<br>page=" + Request["page"]);

            if (Request.IsLocal)
            {

                Response.Write("<br>更多訊息：<br>" + ex.ToString());

            }
            //throw ex;
        }

    }
    //***********************************************************************************	
    //
    //***********************************************************************************	

}  // end of class

}  // end of namespace




