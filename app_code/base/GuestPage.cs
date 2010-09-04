
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace CYU.ServiceSample {

public class GuestPage: BasePage {

	// �N ���t�Τ� �Ҧ� ���� ���n������ �g�b�o��
	public override void Page_Load(object sender,EventArgs e){

		// ���o db �s�u
		try{
			connection = DBOperation.getConnection();
			connection.Open();
		} 
		catch(Exception ex){
			Session["errorMessage"] = "��Ʈw�s�u�L�k�إߡA�гs���t�κ��@�̡I";
			Session["topage"] = "blank.aspx";
			Response.Redirect("service.aspx?page=Message");
						
		}
				
		// �򥻤W�A�M���� login.aspx �M loginverify.aspx �M�@�ǯS������(�N�O �����ˬd�O�_�w login ���U����)
		Guest_Page(sender, e);

		if (connection != null) connection.Close();
		
	} // end of Page_Load
	
	
	public virtual void Guest_Page(object sender,EventArgs e){

		//�ꪺ�A�� �t�ζ}�o�� �мg�Ϊ�

	} // end of BeforePageLoad
	
}  // end of class

}  // end of namespace




