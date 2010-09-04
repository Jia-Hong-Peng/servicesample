
using System;
using System.IO;
using System.Web;
using System.Web.SessionState;
using System.Text;

namespace CYU.ServiceSample {

public class Template {

	//private string TemplateFileName;
	private string _html;
	private string _path;

//***********************************************************************************	
//
//***********************************************************************************	
	public Template(string filename, string path){
		
		//Åª¥X ¼Ëª©ÀÉ
		string filepath = path + filename;
		this._html = ReadFile(filepath);
		this._path = path;
	}
	
//***********************************************************************************	
//
//***********************************************************************************	
	//public void Replace(string tag, string s){
	//	_html = _html.Replace(tag, s);
	//}
	
//***********************************************************************************	
//
//***********************************************************************************	
	public string Content{
		get {
			return _html;
		}
		
	}


//***********************************************************************************	
//
//***********************************************************************************	
	public string ReadFile(string filename)  {
		string content= "";
		
		StreamReader sr = new StreamReader(filename, Encoding.Default);
		content = sr.ReadToEnd();
		sr.Close();
		
		return content.Trim();
				
	}
//***********************************************************************************	
//
//***********************************************************************************	


}  // end of class

}  // end of namespace





