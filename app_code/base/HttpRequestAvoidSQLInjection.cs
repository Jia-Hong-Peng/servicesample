using System;
using System.Web;
using System.Web.UI;

/// <summary>
/// HttpRequestAvoidSQLInjection 的摘要描述
/// </summary>
public class HttpRequestAvoidSQLInjection
{
    HttpRequest _request;

	public HttpRequestAvoidSQLInjection(HttpRequest request)
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
        _request = request;

	}


    public string this[string key] 
    {
        get
        {
            string s = (string)_request[key];
            s = s.Replace("'", "''");
            return s;
        }             
    
    }

}
