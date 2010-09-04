using System;
using System.Data;
using System.Data.Common;

using System.Data.SqlClient;    // �̩ҨϥΪ� ��Ʈw�t�� �A�ЯS�O�`�N�A�ϥΫe �нT�{ �Ӹ�Ʈw�t�Τ��{���w �O�_�w�w��
using System.Data.SQLite;
using MySql.Data.MySqlClient;


namespace CYU.ServiceSample{

	
/// <summary>
/// �����O �D�n�@�� �౵ �U�ظ�Ʈw�t�Τ� �{���w
/// �D�n���T�� ��k�G getConnection, getCommand, getDataAdapter
/// �ϥήɡA�Ш� �ҨϥΪ���Ʈw�t�� ��� �䤺����@�A�H�α���ڪ���Ʈw�A�ý� �A�� using namespace
/// </summary>
public class DBOperation
{

    /// <summary>
    /// DB �D��
    /// </summary>
    public static readonly string dbServer = "localhost";

    /// <summary>
    /// DB �b��
    /// </summary>
    public static readonly string dbAccount = "root";

    /// <summary>
    /// DB �K�X
    /// </summary>
    public static readonly string dbPassword = "123123123";

    /// <summary>
    /// DB �W��
    /// </summary>
    public static readonly string dbName = "ServiceSample";

    
    /// <summary>
    /// ���o ��Ʈw �s�u
    /// </summary>
    /// <returns></returns>
    public static DbConnection getConnection()
    {

        //�إ� �s�u�r��
        string strDbCon = String.Format("Data Source={0};User Id={1}; Password={2}; Database={3}; pooling=false", dbServer, dbAccount, dbPassword, dbName);

        return new SqlConnection(strDbCon); // for ms-sql
        //return new SQLiteConnection("Data Source=" + ServerPath + "SQLiteDB\\ServiceSampleSQLite.sqlite");
    }


	
    /// <summary>
    /// ���o ��Ʈw �R�O�A�H�@�� sql �y�k�����
    /// </summary>
    /// <param name="sqlText"></param>
    /// <param name="conn"></param>
    /// <returns></returns>
    public static DbCommand getCommand(string sqlText, DbConnection conn)
    {
        return new SqlCommand(sqlText, (SqlConnection)conn);
        //return new SQLiteCommand(sqlText, (SqlConnection)conn);

    }

    /// <summary>
    /// ���o ��Ʈw �R�O�A�H�@�� sql �y�k�����
    /// </summary>
    /// <param name="sqlText"></param>
    /// <param name="conn"></param>
    /// <returns></returns>
    public static DbDataAdapter getDataAdapter(string sqlText, DbConnection conn)
    {
        return new SqlDataAdapter(sqlText, (SqlConnection)conn);
        //return new SQLiteDataAdapter(sqlText, (SqlConnection)conn);

    }

} // end of class


} // end of namespace

