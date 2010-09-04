
using System;
using System.Data;
using System.Data.Common;
using System.Web.UI;

namespace CYU.ServiceSample {

public class LoginVerify: GuestPage {


	//PageLoad �|�ˬd�O�_ �v�n�J�A�G �b���� �b pageload ���e �� �A�G�� �мg BeforePageLoad
	public override void Guest_Page(object sender,EventArgs e){

        //�M�� session
        //Session["User"] = null;
        Session.Clear();

		if (check()) {

            //Response.Write("�n�J���\");
            //return;

            setSession();

			connection.Close();  // redirect �e �n�� connection
			
			//�� ���ɦV����k�A���I�O �b���}�C�W �|�ݨ� ?page=Default
            //Response.Redirect("service.aspx?page=Default");
            Response.Redirect("Default.aspx");
            //Server.Transfer("service.aspx?page=Default");


			// �t�@�ؤ覡�A����� page �A����ĳ�ϥ�
			// �n�ɦV����@�� page�A�N�ק� Default�A�y�k�p�U�G
			// <page name> p = new <page name>();
			// p.RedirectToThisPage(Page, sender, e);

			//Default p = new Default();                 
			//p.RedirectToThisPage(Page, sender, e);
		}
		else {
			connection.Close();  // redirect �e �n�� connection

			//"���ҿ��~�A�Э��s��J�b���K�X�I";
            Response.Write(Message.MessagePage("���ҥ��ѡA�Э��s�n�J�I�I�I�I", "Login.aspx"));
            return;
        }
			
	} // end of Guest_Page

	
	private bool check()  {
        //return true;

        string id = RequstAvoidSQLInjection["id"].Trim();   //�B�z SQL Injection
        string password = RequstAvoidSQLInjection["password"].Trim();
		
		//����R�O
        //�ϥ� join user_info �H�T�O users �� user_info ���������
        string strSQL = "select a.uid, a.password from Users a join user_info b on a.uid=b.uid where a.uid = '@id' and a.password = '@password' ";
		strSQL = strSQL.Replace("@id" , id);
		strSQL = strSQL.Replace("@password" , password);
		
	    DbDataAdapter adapter = DBOperation .getDataAdapter(strSQL, connection);
		
		DataSet ds = new DataSet();    
		adapter.Fill(ds, "User");

        if (ds.Tables["User"].Rows.Count >= 1)
        {
            //�A��@��
            //�|���j�p�g
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




