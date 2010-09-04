
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

        // ���w Template �����|
        if (SystemConstant.TemplatePath == null)
        {
            SystemConstant.TemplatePath = Server.MapPath(".") + "\\template\\style2\\";
        }
        
        //�o�@�q �i�� �����C���QŪ���� ���୫�s��s
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

            //���U �o�ؤ覡�� ���� �y�k
            //�Q�� Type.GetType() �M Activator.CreateInstance ��Ӥ覡�A�����Q�� �ʺA���o�� ���O�W �ӫإ߸����O������
            //�Ъ`�N�A�� namespace �ק�ɡA�O�o�P�ɭn�ק� Type.GetType("CYU.ServiceSample." + accessPage, true) ���� "CYU.ServiceSample." 
            Type theType = Type.GetType("CYU.ServiceSample." + pageName, true);
            BasePage p = (BasePage)Activator.CreateInstance(theType);    //�إ� theType ���@�Ӫ���

            p.initPage(Page);
            p.Page_Load(source, e);

        }
        catch (TypeLoadException ex)   //���B�u�d�I TypeLoadException
        {
            Response.Write("<font color=red>���}���~�A���s�����������s�b!!</font><br>��J�������W���G" + pageName);
            Response.Write("<br/>�Y�z�ާ@�L�~�A�B����X�{���T���A�Чַӥ������A���pô�t�κ��@�̳B�z�C<br/><br/>");
            Response.Write("<br/>Url=" + Request.Url);
            Response.Write("<br/>UserHostAddress=" + Request.UserHostAddress);
            Response.Write("<br/>UserHostName=" + Request.UserHostName);
            Response.Write("<br/>DateTime=" + DateTime.Now.ToString());

            if (Request.IsLocal)
            {
                Response.Write("<br>��h�T���G<br>" + ex.ToString());
            }
        }
        catch (ThreadAbortException ex)
        {
            //���B�z   //�o���� �q�`�O �]�� redirect �y��
        }
        catch (Exception ex)    //���B�d�I ��L�� Exception
        {

            Response.Write("�����B�z�o�Ͳ��`!!<br>��J�������W���G" + pageName);
            Response.Write("<br>page=" + Request["page"]);

            if (Request.IsLocal)
            {

                Response.Write("<br>��h�T���G<br>" + ex.ToString());

            }
            //throw ex;
        }

    }
    //***********************************************************************************	
    //
    //***********************************************************************************	

}  // end of class

}  // end of namespace




