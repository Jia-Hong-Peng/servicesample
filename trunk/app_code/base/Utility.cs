using System;
using System.IO;
using System.Text;


namespace CYU.ServiceSample{

public class Utility{

	public static string ReadFile(string filename)  {
		string content= "";
		
		StreamReader sr = new StreamReader(filename, Encoding.Default);
		content = sr.ReadToEnd();
		sr.Close();
		
		return content.Trim();
				
	}
	
	
	
} // end of class


} // end of namespace
