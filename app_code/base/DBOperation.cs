using System.Data;
using System.Data.Common;

using System.Data.SqlClient;    // 依所使用的 資料庫系統 ，請特別注意，使用前 請確認 該資料庫系統之程式庫 是否已安裝
//using System.Data.SQLite;


namespace CYU.ServiceSample{

//***********************************************************************************	
// 本類別 主要作為 轉接 各種資料庫系統之 程式庫
    // 主要有三個 方法： getConnection, getCommand, getDataAdapter
// 使用時，請依 所使用的資料庫系統 更改 其內的實作，以銜接實際的資料庫，並請 適當的 using <namespace>
//***********************************************************************************	
public class DBOperation
{

    //***********************************************************************************	
    // 設定所使用的 DB 名稱
    //***********************************************************************************	
    public static readonly string DBName = "ServiceSample";


    //***********************************************************************************	
    // 取得 資料庫 連線
    //***********************************************************************************	
    public static DbConnection getConnection()
    {
		
		//建立 連線
        string strDbCon = "Data Source=CYU-515-VM\\SQLEXPRESS;User ID=db_course;Password=123;Initial Catalog=" + DBName;

        return new SqlConnection(strDbCon); // for ms-sql
        //return new SQLiteConnection("Data Source=" + ServerPath + "SQLiteDB\\ServiceSampleSQLite.sqlite");
    }


    //***********************************************************************************	
    // 取得 資料庫 命令，以作為 sql 語法執行用
    //***********************************************************************************	
    public static DbCommand getCommand(string sqlText, DbConnection conn)
    {
        return new SqlCommand(sqlText, (SqlConnection)conn);
        //return new SQLiteCommand(sqlText, (SqlConnection)conn);

    }

    //***********************************************************************************	
    // 取得 資料庫 命令，以作為 sql 語法執行用
    //***********************************************************************************	
    public static DbDataAdapter getDataAdapter(string sqlText, DbConnection conn)
    {
        return new SqlDataAdapter(sqlText, (SqlConnection)conn);
        //return new SQLiteDataAdapter(sqlText, (SqlConnection)conn);

    }

} // end of class


} // end of namespace

