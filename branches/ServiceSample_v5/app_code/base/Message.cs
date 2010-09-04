
using System;
using System.Data.SqlClient;
using System.Web.UI;
using CYU;

namespace CYU.ServiceSample {

public class Message: BasePage {

	static Template _template;
    static string _templateFile = "message.html";
	
    //***********************************************************************************	
    // �z�L private ���غc�l�A�� Message �L�k�����
    //***********************************************************************************	
    private Message(){	}


    //***********************************************************************************	
    // ���� �R�A�I�s�A�ǤJ message, topage �A�������ͱ���X�� MessagePage ���e�A�^�ǵ��I�s��
    //***********************************************************************************	
    public static string MessagePage(string message, string topage)
    {
        if (_template == null) _template = new Template(_templateFile, SystemConstant.TemplatePath);

        string output = _template.Content;

        output = output.Replace("__errorMessage__", message);
        output = output.Replace("__topage__", topage);

        return output;
    }

    
    //***********************************************************************************	
    // ���� �R�A�I�s�A�ǤJ message, topage �A�������ͱ���X�� MessagePage ���e�A�^�ǵ��I�s��
    //***********************************************************************************	
    public static string MessagePage(string message, string topage, Page page)
    {
        if (_template == null) _template = new Template(_templateFile, SystemConstant.TemplatePath);

        string output = _template.Content;

        //�q page ���o �����귽�d�� �p�U�G
        //string path = page.Server .MapPath ("\\");

        output = output.Replace("__errorMessage__", message);
        output = output.Replace("__topage__", topage);
        

        return output;
    }


//***********************************************************************************	
//
//***********************************************************************************	

    /* �������ؤ覡�A�]���ӳ·ФF�A����K�ϥ�
    public override void Page_Load(object sender,EventArgs e){
		
		//�o�@�q �i�� �����C���QŪ���� ���୫�s��s
        Response.Expires = 0;
        Response.AppendHeader("pragma","no-cache");
        Response.Cache.SetNoStore();
        
        string output = _template.Content;

	 	string errorMessage = "�L���~�T���I";
	 	if (Session["errorMessage"] != null) errorMessage = (string)Session["errorMessage"];
	 	string topage = "service.aspx";
	 	if (Session["topage"] != null) topage = (string)Session["topage"];
		output = output.Replace("__errorMessage__" , errorMessage  );
		output = output.Replace("__topage__" , topage  );

		Response.Write(output);

	}
    */

}  // end of class

}  // end of namespace




