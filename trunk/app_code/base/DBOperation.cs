using System;
using System.Data;
using System.Data.Common;

using System.Data.SqlClient;    // 依所使用的 資料庫系統 ，請特別注意，使用前 請確認 該資料庫系統之程式庫 是否已安裝
using System.Data.SQLite;
using MySql.Data.MySqlClient;


namespace CYU.ServiceSample{

	
/// <summary>
/// 本類別 主要作為 轉接 各種資料庫系統之 程式庫
/// 主要有三個 方法： getConnection, getCommand, getDataAdapter
/// 使用時，請依 所使用的資料庫系統 更改 其內的實作，以銜接實際的資料庫，並請 適當的 using namespace
/// </summary>
public class DBOperation
{

    /// <summary>
    /// DB 主機
    /// </summary>
    public static readonly string dbServer = "localhost";

    /// <summary>
    /// DB 帳號
    /// </summary>
    public static readonly string dbAccount = "root";

    /// <summary>
    /// DB 密碼
    /// </summary>
    public static readonly string dbPassword = "123123123";

    /// <summary>
    /// DB 名稱
    /// </summary>
    public static readonly string dbName = "ServiceSample";

    
    /// <summary>
    /// 取得 資料庫 連線
    /// </summary>
    /// <returns></returns>
    public static DbConnection getConnection()
    {

        //建立 連線字串
        string strDbCon = String.Format("Data Source={0};User Id={1}; Password={2}; Database={3}; pooling=false", dbServer, dbAccount, dbPassword, dbName);

        return new SqlConnection(strDbCon); // for ms-sql
        //return new SQLiteConnection("Data Source=" + ServerPath + "SQLiteDB\\ServiceSampleSQLite.sqlite");
    }


	
    /// <summary>
    /// 取得 資料庫 命令，以作為 sql 語法執行用
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
    /// 取得 資料庫 命令，以作為 sql 語法執行用
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

