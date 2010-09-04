using System.Data;
using System.Data.Common;

using System.Data.SqlClient;    // �̩ҨϥΪ� ��Ʈw�t�� �A�ЯS�O�`�N�A�ϥΫe �нT�{ �Ӹ�Ʈw�t�Τ��{���w �O�_�w�w��
//using System.Data.SQLite;


namespace CYU.ServiceSample{

//***********************************************************************************	
// �����O �D�n�@�� �౵ �U�ظ�Ʈw�t�Τ� �{���w
    // �D�n���T�� ��k�G getConnection, getCommand, getDataAdapter
// �ϥήɡA�Ш� �ҨϥΪ���Ʈw�t�� ��� �䤺����@�A�H�α���ڪ���Ʈw�A�ý� �A�� using <namespace>
//***********************************************************************************	
public class DBOperation
{

    //***********************************************************************************	
    // �]�w�ҨϥΪ� DB �W��
    //***********************************************************************************	
    public static readonly string DBName = "ServiceSample";


    //***********************************************************************************	
    // ���o ��Ʈw �s�u
    //***********************************************************************************	
    public static DbConnection getConnection()
    {
		
		//�إ� �s�u
        string strDbCon = "Data Source=CYU-515-VM\\SQLEXPRESS;User ID=db_course;Password=123;Initial Catalog=" + DBName;

        return new SqlConnection(strDbCon); // for ms-sql
        //return new SQLiteConnection("Data Source=" + ServerPath + "SQLiteDB\\ServiceSampleSQLite.sqlite");
    }


    //***********************************************************************************	
    // ���o ��Ʈw �R�O�A�H�@�� sql �y�k�����
    //***********************************************************************************	
    public static DbCommand getCommand(string sqlText, DbConnection conn)
    {
        return new SqlCommand(sqlText, (SqlConnection)conn);
        //return new SQLiteCommand(sqlText, (SqlConnection)conn);

    }

    //***********************************************************************************	
    // ���o ��Ʈw �R�O�A�H�@�� sql �y�k�����
    //***********************************************************************************	
    public static DbDataAdapter getDataAdapter(string sqlText, DbConnection conn)
    {
        return new SqlDataAdapter(sqlText, (SqlConnection)conn);
        //return new SQLiteDataAdapter(sqlText, (SqlConnection)conn);

    }

} // end of class


} // end of namespace

