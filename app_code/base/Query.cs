
using System;
using System.Data;
using System.Data.Common;
using System.Web.UI;

namespace CYU.ServiceSample {

public class Query: MemberPage {
	
	static Template _template;
	static Template _loopSample;
    static string _templateFile = "query.html";
    static string _loopSampleFile = "queryOneBook.html";
	
//***********************************************************************************	
//
//***********************************************************************************	
    public Query()
    {
        if (_template == null || SystemConstant.TemplateReloading)
        {
            _template = new Template(_templateFile, SystemConstant.TemplatePath);
            _loopSample = new Template(_loopSampleFile, SystemConstant.TemplatePath);

        }
	}

//***********************************************************************************	
//
//***********************************************************************************	
	//���� �ܽd �p��q ��Ʈw ����X���	
	//�� �ܽd ��� �h�������ܪ��覡
	public override void Member_Page(object sender,EventArgs e){
		
		//����R�O
		string strSQL = "select * from sampleTable ";
		//strSQL = strSQL.Replace("@id" , id);

        DbDataAdapter adapter = DBOperation.getDataAdapter(strSQL, connection);
		
		DataSet ds = new DataSet();    
		adapter.Fill(ds, "t");  
		
		//Ū�J�㭶��html
		string output = _template.Content;

		//�H�U �ܽd ��� �h�������ܪ��覡
		//Ū�J �浧 �����html�˪�
		string loopSample = _loopSample.Content;

		string books = "";
		
		//�Q�� for �j�� �� �浧���˪� �s�� ��ܦh���O�� �Ϊ�html 
		for (int i=0; i<ds.Tables["t"].Rows.Count; i++){
			string s = loopSample;
			s = s.Replace("__bookid__", (string)ds.Tables["t"].Rows[i]["bookid"]);
			s = s.Replace("__title__", (string)ds.Tables["t"].Rows[i]["title"]);
			s = s.Replace("__auther__", (string)ds.Tables["t"].Rows[i]["auther"]);
			s = s.Replace("__publisher__", (string)ds.Tables["t"].Rows[i]["publisher"]);
			s = s.Replace("__year__", (string)ds.Tables["t"].Rows[i]["bookyear"]);
			s = s.Replace("__price__", ""+ ds.Tables["t"].Rows[i]["price"]);          // �`�N�Aprice �����A�O int�A�ҥH �� "" + int ���覡�h�ഫ���r�� (�o�O ��ƪ� ���w�q)
			
			books += s;
			
		}
	 	
	 	//�z�L tag �N �W���o�쪺 �h�����html �פJ �㭶��html ���C
		output = output.Replace("__books__" , books );
		
		Response.Write(output);

	} // end of InitPage
//***********************************************************************************	
//
//***********************************************************************************	
	


}  // end of class

}  // end of namespace




