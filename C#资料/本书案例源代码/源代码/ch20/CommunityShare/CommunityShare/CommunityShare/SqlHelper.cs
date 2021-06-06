using System;
using System.Data;
using System.Data.SqlClient;


/// <summary>
///SqlHelper介绍
/// </summary>
public abstract class SqlHelper
{
    //数据库连接的相关参数
    public static string Conn = "Data Source=.;Initial Catalog=community_share;User ID=sa;Password=";

    /// <summary>
    /// 准备数据库操作的命令
    /// </summary>
    /// <param name="cmd">sql命令</param>
    /// <param name="conn">数据库连接</param>
    /// <param name="trans">数据库事务</param>
    /// <param name="cmdType">命令类型</param>
    /// <param name="cmdTxt">命令语句</param>
    /// <param name="cmdParms">命令中涉及的参数</param>
    private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdTxt, SqlParameter[] cmdParams)
    {

        if (conn.State != ConnectionState.Open)
            conn.Open();

        cmd.Connection = conn;
        cmd.CommandText = cmdTxt;

        if (trans != null)
            cmd.Transaction = trans;

        cmd.CommandType = cmdType;

        if (cmdParams != null)
        {
            foreach (SqlParameter parm in cmdParams)
                cmd.Parameters.Add(parm);
        }
    }

    /// <summary>
    /// 建立数据库连接，执行更新数据库的命令
    /// </summary>
    /// <param name="connStr">数据库连接的语句</param>
    /// <param name="cmdType">命令类型</param>
    /// <param name="cmdTxt">sql命令语句</param>
    /// <param name="cmdParams">命令所涉及的参数</param>
    /// <returns>执行命令所影响的行数</returns>
    public static int ExecuteUpdateQuery(string connStr, CommandType cmdType, string cmdText, params SqlParameter[] cmdParams)
    {

        SqlCommand cmd = new SqlCommand();

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParams);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }
    }

    /// <summary>
    /// 建立数据库连接，执行往数据库存入记录的命令
    /// </summary>
    /// <param name="connStr">数据库连接的语句</param>
    /// <param name="cmdType">命令类型</param>
    /// <param name="cmdTxt">sql命令语句</param>
    /// <param name="cmdParams">命令所涉及的参数</param>
    /// <returns>执行命令所影响的行数</returns>
    public static int ExecuteInsertQuery(string connStr, CommandType cmdType, string cmdText, params SqlParameter[] cmdParams)
    {
        SqlCommand cmd = new SqlCommand();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParams);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }
    }

    /// <summary>
    /// 返回数据表
    /// </summary>
    /// <param name="connStr">数据库连接的语句</param>
    /// <param name="cmdType">命令类型</param>
    /// <param name="cmdTxt">sql命令语句</param>
    /// <param name="cmdParams">执行命令所用参数的集合</param>
    /// <returns></returns>
    public static DataSet GetDataSet(string connStr, CommandType cmdType, string cmdTxt, params SqlParameter[] cmdParams)
    {
        //创建一个SqlCommand对象
        SqlCommand cmd = new SqlCommand();
        //创建一个SqlConnection对象
        SqlConnection conn = new SqlConnection(connStr);

        //抓取执行sql命令过程中出现的异常，如果异常出现，则关闭连接
        try
        {
            //调用 PrepareCommand 方法，对 SqlCommand 对象设置参数
            PrepareCommand(cmd, conn, null, cmdType, cmdTxt, cmdParams);
            //调用 SqlCommand  的 ExecuteReader 方法
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataSet ds = new DataSet();

            adapter.Fill(ds);
            //清除参数
            cmd.Parameters.Clear();
            conn.Close();
            return ds;
        }
        catch (Exception e)
        {
            throw e;
        }
    }

}