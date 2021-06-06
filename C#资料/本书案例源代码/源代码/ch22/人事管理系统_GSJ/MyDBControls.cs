using System;
using System.Collections.Generic;
using System.Text;
//导入命名空间

using System.Data;
using System.Data.SqlClient;

namespace 人事管理系统_GSJ
{
    class MyDBControls
    {
       #region 模块级变量
        private static string server = ".";

        public static string Server//服务器
        {
            get { return MyDBControls.server; }
            set { MyDBControls.server = value; }
        }

        private static string uid="sa";

        public static string Uid//登录名
        {
            get { return MyDBControls.uid; }
            set { MyDBControls.uid = value; }
        }
        private static string pwd="";

        public static string Pwd//密码
        {
            get { return MyDBControls.pwd; }
            set { MyDBControls.pwd = value; }
        }
      
       public static SqlConnection M_scn_myConn;//数据库连接

       #endregion
        public static void GetConn() //连接数据库
        {
            try
            {
                string M_str_connStr = "server="+Server+";database=db_PWMS_GSJ;uid="+Uid+";pwd="+Pwd; //连接字符串
                M_scn_myConn = new SqlConnection(M_str_connStr);
                M_scn_myConn.Open();
            }
            catch //处理异常
            {
            }
        }
        public static void CloseConn() //关闭连接
        {
            if (M_scn_myConn.State == ConnectionState.Open)
            {
                M_scn_myConn.Close();
                M_scn_myConn.Dispose();
            }
        }
        public static SqlCommand CreateCommand(string commStr)//根据字符串产生SQL命令
        {
            SqlCommand P_scm = new SqlCommand(commStr, M_scn_myConn);
            return P_scm;
        }
        public static int ExecNonQuery(string commStr) //执行命令返回受影响行数
        {
            return CreateCommand(commStr).ExecuteNonQuery();
        }
        public static object ExecSca(string commStr) //返回结果集的第一行第一列
        {
                return CreateCommand(commStr).ExecuteScalar();
        }
        public static SqlDataReader GetDataReader(string commStr) //返回DataReader
        {
                return CreateCommand(commStr).ExecuteReader();
        }
        public static DataSet GetDataSet(string commStr)//返回DataSet
        {
            SqlDataAdapter P_sda = new SqlDataAdapter(commStr, M_scn_myConn);
            DataSet P_ds = new DataSet();
            P_sda.Fill(P_ds);
            return P_ds;
        }
        /// <summary>
        /// 执行带图片的插入操作的sql语句   
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="bytes">图片转后的数组</param>
        /// <returns>受影响行数</returns>
        public static int SaveImage(string sql,object bytes)//存图像 参数1 sql语句 参数2 图像转换的数组
        {
            SqlCommand scm = new SqlCommand();//声明sql语句
            scm.CommandText = sql;
            scm.CommandType = CommandType.Text;
            scm.Connection = M_scn_myConn;
            SqlParameter imgsp = new SqlParameter("@imgBytes", SqlDbType.Image);//设置参数的值
            imgsp.Value = (byte[])bytes;
            scm.Parameters.Add(imgsp);
            return scm.ExecuteNonQuery();//执行

        }
        /// <summary>
        /// 还原数据库
        /// </summary>
        /// <param name="filePath">文件路径</param>
        public static void RestoreDB(string filePath)
        {
            CloseConn();//试图关闭原来的连接
            string reSql = "restore database db_PWMS_GSJ from disk ='" + filePath + "' with replace"; //还原语句
            string reSql2 = "select spid from master..sysprocesses where dbid=db_id('db_pwms_GSJ')"; //强制关闭原来连接的语句
            SqlConnection reScon = new SqlConnection("server=.;database=master;uid=" + Uid + ";pwd=" + Pwd);//新建连接
            try
            {
                reScon.Open();//打开连接

                SqlCommand reScm1 = new SqlCommand(reSql2, reScon);//执行查询找出与要还原数据库有关的所有连接
                SqlDataAdapter reSDA = new SqlDataAdapter(reScm1);
                DataSet reDS = new DataSet();
                reSDA.Fill(reDS);   //临时存储查询结果
                for (int i = 0; i < reDS.Tables[0].Rows.Count; i++)//逐一关闭这些连接
                {
                    string killSql = "kill " + reDS.Tables[0].Rows[i][0].ToString();
                    SqlCommand killScm = new SqlCommand(killSql, reScon);
                    killScm.ExecuteNonQuery();
                }
                SqlCommand reScm2 = new SqlCommand(reSql, reScon);//执行还原
                reScm2.ExecuteNonQuery();
                reScon.Close();//关闭本次连接
            }
            catch //处理异常
            {

               
            }
        }
        
    }
}
