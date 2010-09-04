
using System;
using System.Data;
using System.Data.Common;
using System.Web.UI;

namespace CYU.ServiceSample {

public class MemberPage: BasePage {

	//�� CheckLogin ����A�� Session �����X�A��K�Ҧ� �~�� MemberPage �������ϥ� 
	protected User p;

	// �N ���t�Τ� �Ҧ� ���� ���n������ �g�b�o��
	public override void Page_Load(object sender,EventArgs e){

		//�o�@�q �i�� �����C���QŪ���� ���୫�s��s
        Response.Expires = 0;
        Response.AppendHeader("pragma","no-cache");
        Response.Cache.SetNoStore();

		// ���o db �s�u
		try{
            connection = DBOperation.getConnection();
			connection.Open();
		} 
		catch(Exception ex){

            //Response.Write(Message.MessagePage("��Ʈw�s�u�L�k�إߡA�гs���t�κ��@�̡I", "blank.aspx", Page));   // 
            Response.Write(Message.MessagePage("��Ʈw�s�u�L�k�إߡA�гs���t�κ��@�̡I", "blank.aspx"));
            return;
		}
		
		//�ˬd�O�_�O ���\�� IP
		if (!CheckIP()){
			connection.Close();
            Response.Write(Message .MessagePage ("�z���q����}�L�ϥΥ��A�Ȥ��v��!!!", "blank.aspx"));
            return;

        }
		
		// 1. �ˬd �O�_ �w�n�J
		if (!CheckLogin()) {
			
			connection.Close();
            Response.Write(Message.MessagePage("�|���n�J!\\n�εn�J�w�O�ɡI!", "Login.aspx"));
            return;
		}		

		//�w�n�J �~ ��o�� Session["User"]
		p = (User) Session["User"];
				
		// 2. �ˬd User �O�_ �㦳 ���楻�������v�� 
		string thisPageName = this.GetType().Name;     //this.GetType().Name ��X�ӷ|���O login_aspx
		
		if (!p.checkRight(thisPageName, connection )){

			connection.Close();

			string message = "�z�L�v���ϥΥ���!!!\\n"
												+ "�Ц^�t�έ���\\n"
												//+ "�������O�W�G" + this.GetType().Name 
												;

            Response.Write(Message.MessagePage(message, "Default.aspx"));
            return;
        }
			
		Member_Page(sender, e);    //���C�@�� �u�� �n�����ơA�g�b�o��

		if (connection != null) connection.Close();
		
	} // end of Page_Load
	
	
	// �C�� ����l��� �令 �� InitPage()
	// �Y �쥻�O�n�мg Page_Load ���A�令 �мg InitPage
	public virtual void Member_Page(object sender, EventArgs e){
		
		//�ꪺ�A�� �t�ζ}�o�� �мg�Ϊ�
		string output = displayOutput();
		Response.Write(output);
		
	} // end of InitPage

	//�t�ζ}�o�� �i���ݨD �мg InitPage() �� displayOutput() ��Ӥ�k�A[�򥻤W�A�P���мg��ӬO�L�N����]
	//�t���b��AInitPage()���O�����ϥ� Response.Write �Ӳ��ͺ������e
	//���O displayOutput �h�O ���N �������e �g��@�Ӧr�ꤤ�A�A�^�ǵ� InitPage() �h��ܡA	
	//�ϥ� displayOutput() �O����·Ъ��A���O �^�Ǫ����G �o�i����ܡA�o�I�}�o�� �i��ֿn�����g���ϥΤ��C
	public virtual string displayOutput(){
		
		return "";
		
	} // end of InitPage
	
	
	//��� �ˬd IP �� ��� 
	private bool CheckIP(){
		return true;  //�Ȥ��ˬd�ɡA�i�[�W����
		
		string ip = Request.UserHostAddress;
		
		//����R�O
		string strSQL = "select * from AuthenticateIP where ip = '@ip' and isOpen= 'y' and getdate() between startdate and enddate ";
		strSQL = strSQL.Replace("@ip" , ip);

        DbDataAdapter adapter = DBOperation.getDataAdapter(strSQL, connection);
		
		DataSet ds = new DataSet();    
		adapter.Fill(ds, "IP");  
		
		if (ds.Tables["IP"].Rows.Count >= 1) return true;	
		else return false;	
		
	} // end of CheckIP
	
	
	//��� �ˬd�n�J�� ��� 
	private bool CheckLogin(){
		
		//return false;
		
		if (Session["User"] != null) {
			return true;
		}
		else return false;
		
	} // end of CheckLogin
	
}  // end of class

}  // end of namespace




