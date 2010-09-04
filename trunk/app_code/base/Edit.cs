
using System;
using System.Data;
using System.Data.Common;
using System.Web.UI;

namespace CYU.ServiceSample {

public class Edit: MemberPage {
	
	static Template _template;
    static string _templateFile = "edit.html";
	
//***********************************************************************************	
//
//***********************************************************************************	
    public Edit()
    {
        if (_template == null || SystemConstant.TemplateReloading)
        {
            _template = new Template(_templateFile, SystemConstant.TemplatePath);

        }
	}

//***********************************************************************************	
//
//***********************************************************************************	
	//���� �ܽd �p��q ��Ʈw ����X���	
	public override void Member_Page(object sender,EventArgs e){
		
    string output = _template.Content;

		//�L bookid ��
		if (Request["bookid"] == null){
			output = output.Replace("__bookid__" , "" );
			output = output.Replace("__title__" , "" );
			output = output.Replace("__auther__" , "" );
			output = output.Replace("__publisher__" , "" );
			output = output.Replace("__year__" , "" );
			output = output.Replace("__price__" , "" );
			
		}
		else {  //�� bookid �ɡA��d��
			string strSQL = "select * from sampleTable where bookid='@bookid' ";
			strSQL = strSQL.Replace("@bookid" , Request["bookid"]);

            DbDataAdapter adapter = DBOperation.getDataAdapter(strSQL, connection);
			
			DataSet ds = new DataSet();    
			adapter.Fill(ds, "t");  
			
			output = output.Replace("__bookid__", (string)ds.Tables["t"].Rows[0]["bookid"]);
			output = output.Replace("__title__", (string)ds.Tables["t"].Rows[0]["title"]);
			output = output.Replace("__auther__", (string)ds.Tables["t"].Rows[0]["auther"]);
			output = output.Replace("__publisher__", (string)ds.Tables["t"].Rows[0]["publisher"]);
			output = output.Replace("__year__", (string)ds.Tables["t"].Rows[0]["bookyear"]);
			output = output.Replace("__price__", ""+ ds.Tables["t"].Rows[0]["price"]);              // �`�N�Aprice �����A�O int�A�ҥH �� "" + int ���覡�h�ഫ���r�� (�o�O ��ƪ� ���w�q)
		}
		
		Response.Write(output);

	} // end of InitPage
	


}  // end of class

}  // end of namespace




