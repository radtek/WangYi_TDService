//===============================================================================
// This file is based on the Microsoft Data Access Application Block for .NET
// For more information please go to 
// http://msdn.microsoft.com/library/en-us/dnbda/html/daab-rm.asp
//modify by kingson . kingson_chen@hotmail.com . 2007.04.13
//===============================================================================

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace TDService.Data
{
    /// <summary>
    /// SqlHelper类提供很高的数据访问性能, 
    /// 使用SqlClient类的通用定义.
    /// </summary>

    public abstract class SqlHelper
    {

        //定义数据库连接串

        /// <summary>
        /// 
        /// </summary>
        public static readonly string ConnectionStringLocalTransaction = "Data Source=" + TDService.StaticForm.ini.IniReadValue("Server", "ServerName") + ";Initial Catalog=" + TDService.StaticForm.ini.IniReadValue("Server", "ServerDataBase") + ";User ID=" + TDService.StaticForm.ini.IniReadValue("Server", "ServerLoginName") + ";Password=" + TDService.StaticForm.ini.IniReadValue("Server", "ServerPwd");
        public static readonly string ConnectionStringGT = "Data Source=" + TDService.StaticForm.ini.IniReadValue("GTServer", "GTServerName") + ";Initial Catalog=" + TDService.StaticForm.ini.IniReadValue("GTServer", "GTServerDataBase") + ";User ID=" + TDService.StaticForm.ini.IniReadValue("GTServer", "GTServerLoginName") + ";Password=" + TDService.StaticForm.ini.IniReadValue("GTServer", "GTServerPwd");


        // 存贮Cache缓存的Hashtable集合

        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());



        /// <summary>

        /// 使用连接字符串，执行一个SqlCommand命令（没有记录返回）

        /// 使用提供的参数集.

        /// </summary>

        /// <remarks>

        /// 示例:  

        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));

        /// </remarks>

        /// <param name="connectionString">一个有效的SqlConnection连接串</param>

        /// <param name="commandType">命令类型CommandType(stored procedure, text, etc.)</param>

        /// <param name="commandText">存贮过程名称或是一个T-SQL语句串</param>

        /// <param name="commandParameters">执行命令的参数集</param>

        /// <returns>受此命令影响的行数</returns>

        public static int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);

                int val = cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();

                return val;

            }

        }

        /// <returns>受此命令影响的行数</returns>

        public static int ExecuteNonQuery(string connectionString,string sql)
        {

            SqlCommand cmd = new SqlCommand();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    int val = cmd.ExecuteNonQuery();

                    cmd.Dispose();

                    return val;
                }
                catch
                {
                    return 404;
                }
                finally
                {
                    conn.Close();
                }

            }

        }
        ////////////////////////////////////////////////////ADD 20090319 START
        /// <summary>
        /// 返回服务器时间
        /// </summary>
        /// <param name="connectionString">链接数据库字符串</param>
        /// <returns>返回服务器时间</returns>
        public static string Executegetsqltime(string connectionString)
        {

            SqlCommand cmd = new SqlCommand();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = "select getdate()";
                    string val = cmd.ExecuteScalar().ToString();

                    cmd.Dispose();

                    return val;
                }
                catch
                {
                    return "err";
                }

            }

        }
        ////////////////////////////////////////////////////ADD 20090319 END


        /// <summary>

        /// 在一个存在的连接上执行数据库的命令操作

        /// 使用提供的参数集.

        /// </summary>

        /// <remarks>

        /// e.g.:  

        ///  int result = ExecuteNonQuery(connection, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));

        /// </remarks>

        /// <param name="conn">一个存在的数据库连接对象</param>

        /// <param name="commandType">命令类型CommandType (stored procedure, text, etc.)</param>

        /// <param name="commandText">存贮过程名称或是一个T-SQL语句串</param>

        /// <param name="commandParameters">执行命令的参数集</param>

        /// <returns>受此命令影响的行数</returns>

        public static int ExecuteNonQuery(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {



            SqlCommand cmd = new SqlCommand();



            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);

            int val = cmd.ExecuteNonQuery();

            cmd.Parameters.Clear();

            return val;

        }



        /// <summary>

        /// 在一个事务的连接上执行数据库的命令操作

        /// 使用提供的参数集.

        /// </summary>

        /// <remarks>

        /// e.g.:  

        ///  int result = ExecuteNonQuery(trans, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));

        /// </remarks>

        /// <param name="trans">一个存在的事务</param>

        /// <param name="commandType">命令类型CommandType (stored procedure, text, etc.)</param>

        /// <param name="commandText">存贮过程名称或是一个T-SQL语句串</param>

        /// <param name="commandParameters">执行命令的参数集</param>

        /// <returns>受此命令影响的行数</returns>

        public static int ExecuteNonQuery(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();

            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);

            int val = cmd.ExecuteNonQuery();

            cmd.Parameters.Clear();

            return val;

        }



        /// <summary>

        /// 在一个连接串上执行一个命令，返回一个SqlDataReader对象

        /// 使用提供的参数.

        /// </summary>

        /// <remarks>

        /// e.g.:  

        ///  SqlDataReader r = ExecuteReader(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));

        /// </remarks>

        /// <param name="connectionString">一个有效的SqlConnection连接串</param>

        /// <param name="commandType">命令类型CommandType(stored procedure, text, etc.)</param>

        /// <param name="commandText">存贮过程名称或是一个T-SQL语句串</param>

        /// <param name="commandParameters">执行命令的参数集</param>

        /// <returns>一个结果集对象SqlDataReader</returns>

        public static SqlDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();

            SqlConnection conn = new SqlConnection(connectionString);



            // 如果不存在要查询的对象，则发生异常

            // 连接要关闭

            // CommandBehavior.CloseConnection在异常时不发生作用

            try
            {

                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);

                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                cmd.Parameters.Clear();

                return rdr;

            }

            catch
            {

                conn.Close();

                throw;

            }
            finally
            {
                conn.Close();
            }


        }



        /// <summary>

        /// 在一个连接串上执行一个命令，返回表中第一行，第一列的值

        /// 使用提供的参数.

        /// </summary>

        /// <remarks>

        /// e.g.:  

        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));

        /// </remarks>

        /// <param name="connectionString">一个有效的SqlConnection连接串</param>

        /// <param name="commandType">命令类型CommandType(stored procedure, text, etc.)</param>

        /// <param name="commandText">存贮过程名称或是一个T-SQL语句串</param>

        /// <param name="commandParameters">执行命令的参数集</param>        /// <returns>返回的对象，在使用时记得类型转换</returns>

        public static object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);

                    object val = cmd.ExecuteScalar();

                    cmd.Parameters.Clear();

                    return val;
                }
                catch
                {
                    return null;
                }
                finally
                {
                    connection.Close();
                }

            }

        }



        /// <summary>

        /// 在一个连接上执行一个命令，返回表中第一行，第一列的值

        /// 使用提供的参数.

        /// </summary>

        /// <remarks>

        /// e.g.:  

        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));

        /// </remarks>

        /// <param name="connectionString">一个有效的SqlConnection连接</param>

        /// <param name="commandType">命令类型CommandType(stored procedure, text, etc.)</param>

        /// <param name="commandText">存贮过程名称或是一个T-SQL语句串</param>

        /// <param name="commandParameters">执行命令的参数集</param>        

        /// <returns>返回的对象，在使用时记得类型转换</returns>

        public static object ExecuteScalar(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();

            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);

            object val = cmd.ExecuteScalar();

            cmd.Parameters.Clear();

            return val;

        }

        /// <summary>

        /// 

        /// </summary>

        /// <param name="connectionString">数据库连接字符串</param>

        /// <param name="cmdType">命令类型CommandType(stored procedure, text, etc.)</param>

        /// <param name="cmdText">存贮过程名称或是一个T-SQL语句串</param>

        /// <param name="commandParameters">执行命令的参数集</param>

        /// <returns>返回 DataSet 对象</returns>
        public static DataSet ExecuteDataSet(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                DataSet ds = new DataSet();
                SqlDataAdapter sqladapter = new SqlDataAdapter(cmd);
                sqladapter.Fill(ds);
                return ds;
            }
            catch
            {
                return null;
            }
            finally
            {
                connection.Close();
            }

        }
        /// <returns>返回 DataSet 对象</returns>
        public static DataSet ExecuteDataSet(string connectionString,string sql)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                cmd.Connection = connection;
                cmd.CommandText = sql;
                DataSet ds = new DataSet();
                SqlDataAdapter sqladapter = new SqlDataAdapter(cmd);
                sqladapter.Fill(ds);
                connection.Close();
                return ds;
            }
            catch
            {
                return null;
            }
            finally
            {
                connection.Close();
            }

        }
        /// <summary>

        /// 在缓存中添加参数数组

        /// </summary>

        /// <param name="cacheKey">参数的Key</param>

        /// <param name="cmdParms">参数数组</param>

        public static void CacheParameters(string cacheKey, params SqlParameter[] commandParameters)
        {

            parmCache[cacheKey] = commandParameters;

        }



        /// <summary>

        /// 提取缓存的参数数组

        /// </summary>

        /// <param name="cacheKey">查找缓存的key</param>

        /// <returns>返回被缓存的参数数组</returns>

        public static SqlParameter[] GetCachedParameters(string cacheKey)
        {

            SqlParameter[] cachedParms = (SqlParameter[])parmCache[cacheKey];



            if (cachedParms == null)

                return null;



            SqlParameter[] clonedParms = new SqlParameter[cachedParms.Length];



            for (int i = 0, j = cachedParms.Length; i < j; i++)

                clonedParms[i] = (SqlParameter)((ICloneable)cachedParms[i]).Clone();



            return clonedParms;

        }



        /// <summary>

        /// 提供一个SqlCommand对象的设置

        /// </summary>

        /// <param name="cmd">SqlCommand对象</param>

        /// <param name="conn">SqlConnection 对象</param>

        /// <param name="trans">SqlTransaction 对象</param>

        /// <param name="cmdType">CommandType 如存贮过程，T-SQL</param>

        /// <param name="cmdText">存贮过程名或查询串</param>

        /// <param name="cmdParms">命令中用到的参数集</param>

        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {

            if (conn.State != ConnectionState.Open)
            {
                try
                {
                    conn.Open();
                }
                catch
                {
 
                }
            }

            try
            {
                cmd.Connection = conn;

                cmd.CommandText = cmdText;



                if (trans != null)

                    cmd.Transaction = trans;


                cmd.CommandType = cmdType;



                if (cmdParms != null)
                {

                    foreach (SqlParameter parm in cmdParms)

                        cmd.Parameters.Add(parm);

                }
            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }

        }

        /// <summary>
        /// 帮定ComboBox
        /// </summary>
        /// <param name="ddlControl">DropDownList控件ID</param>
        /// <param name="strTableName">表名</param>
        /// <param name="strText">显示的文本字段</param>
        /// <param name="strValue">值字段</param>
        /// <param name="strWhere">查询条件，不包含Where</param>
        /// <param name="strOrder">排序字段</param>
        /// <param name="strInitializeText">初始化文本</param>
        /// <param name="strInitializeValue">初始化值</param>
        public static void ComboxBind(System.Windows.Forms.ComboBox cbxControl, string strTableName, string strText, string strValue, string strWhere, string strOrder, string strInitializeText, string strInitializeValue)
        {
            string strSql = "SELECT * FROM " + strTableName + " Where " + strWhere;
            if (strOrder != "")
            {
                strSql += " Order By " + strOrder;
            }
            DataTable dt = new DataTable();
            dt = ExecuteDataSet(TDService.Data.SqlHelper.ConnectionStringLocalTransaction,CommandType.Text,strSql,null).Tables[0];

            DataRow dr = dt.NewRow();
            dr[strText] = strInitializeText;
            dr[strValue] = strInitializeValue;

            dt.Rows.InsertAt(dr, 0);

            cbxControl.DataSource = dt;
            cbxControl.DisplayMember = strText;
            cbxControl.ValueMember = strValue;
        }

        /// <summary>
        /// 帮定ComboBox
        /// </summary>
        /// <param name="ddlControl">DropDownList控件ID</param>
        /// <param name="strTableName">表名</param>
        /// <param name="strText">显示的文本字段</param>
        /// <param name="strValue">值字段</param>
        /// <param name="strWhere">查询条件，不包含Where</param>
        /// <param name="strOrder">排序字段</param>
        /// <param name="strInitializeText">初始化文本</param>
        /// <param name="strInitializeValue">初始化值</param>
        public static void ComboxBindGT(System.Windows.Forms.ComboBox cbxControl, string strTableName, string strText, string strValue, string strWhere, string strOrder, string strInitializeText, string strInitializeValue)
        {
            string strSql = "SELECT * FROM " + strTableName + " Where " + strWhere;
            if (strOrder != "")
            {
                strSql += " Order By " + strOrder;
            }
            DataTable dt = new DataTable();
            dt = ExecuteDataSet(TDService.Data.SqlHelper.ConnectionStringGT, CommandType.Text, strSql, null).Tables[0];

            DataRow dr = dt.NewRow();
            dr[strText] = strInitializeText;
            dr[strValue] = strInitializeValue;

            dt.Rows.InsertAt(dr, 0);

            cbxControl.DataSource = dt;
            cbxControl.DisplayMember = strText;
            cbxControl.ValueMember = strValue;
        }

        /// <summary>
        /// 帮定ComboBox
        /// </summary>
        /// <param name="ddlControl">DropDownList控件ID</param>
        /// <param name="strTableName">表名</param>
        /// <param name="strText">显示的文本字段</param>
        /// <param name="strValue">值字段</param>
        /// <param name="strWhere">查询条件，不包含Where</param>
        /// <param name="strOrder">排序字段</param>
        /// <param name="strInitializeText">初始化文本--默认的第一个选项（显示）</param>
        /// <param name="strInitializeValue">初始化值--默认的第一个选项的对应值（隐藏）</param>
        public static void ComboxBind(System.Windows.Forms.ToolStripComboBox cbxControl, string strTableName, string strText, string strValue, string strWhere, string strOrder, string strInitializeText, string strInitializeValue)
        {
            string strSql = "SELECT * FROM " + strTableName + " Where " + strWhere;
            if (strOrder != "")
            {
                strSql += " Order By " + strOrder;
            }
            DataTable dt = new DataTable();
            dt = ExecuteDataSet(TDService.Data.SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql, null).Tables[0];

            DataRow dr = dt.NewRow();
            dr[strText] = strInitializeText;
            dr[strValue] = strInitializeValue;

            dt.Rows.InsertAt(dr, 0);

            cbxControl.ComboBox.DataSource = dt;
            cbxControl.ComboBox.DisplayMember = strText;
            cbxControl.ComboBox.ValueMember = strValue;
        }

        /// <summary>
        /// 帮定ComboBox
        /// </summary>
        /// <param name="ddlControl">DropDownList控件ID</param>
        /// <param name="strTableName">表名</param>
        /// <param name="strText">显示的文本字段</param>
        /// <param name="strValue">值字段</param>
        /// <param name="strWhere">查询条件，不包含Where</param>
        /// <param name="strOrder">排序字段</param>
        /// <param name="strInitializeText">初始化文本</param>
        /// <param name="strInitializeValue">初始化值</param>
        public static void ComboxBindGT(System.Windows.Forms.ToolStripComboBox cbxControl, string strTableName, string strText, string strValue, string strWhere, string strOrder, string strInitializeText, string strInitializeValue)
        {
            string strSql = "SELECT * FROM " + strTableName + " Where " + strWhere;
            if (strOrder != "")
            {
                strSql += " Order By " + strOrder;
            }
            DataTable dt = new DataTable();
            dt = ExecuteDataSet(TDService.Data.SqlHelper.ConnectionStringGT, CommandType.Text, strSql, null).Tables[0];

            DataRow dr = dt.NewRow();
            dr[strText] = strInitializeText;
            dr[strValue] = strInitializeValue;

            dt.Rows.InsertAt(dr, 0);

            cbxControl.ComboBox.DataSource = dt;
            cbxControl.ComboBox.DisplayMember = strText;
            cbxControl.ComboBox.ValueMember = strValue;
        }

        /// <summary>
        /// 帮定ComboBox
        /// </summary>
        /// <param name="ddlControl">DropDownList控件ID</param>
        /// <param name="strTableName">表名</param>
        /// <param name="strText">显示的文本字段</param>
        /// <param name="strValue">值字段</param>
        /// <param name="strWhere">查询条件，不包含Where</param>
        /// <param name="strOrder">排序字段</param>

        public static void ComboxBind(System.Windows.Forms.ComboBox cbxControl, string strTableName, string strText, string strValue, string strWhere, string strOrder)
        {
            string strSql = "SELECT * FROM " + strTableName + " Where " + strWhere + " Order By " + strOrder;
            DataTable dt = new DataTable();

            dt = ExecuteDataSet(TDService.Data.SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql, null).Tables[0];
            if (dt.Rows.Count > 0)
            {
                cbxControl.DataSource = dt;
                cbxControl.DisplayMember = strText;
                cbxControl.ValueMember = strValue;
            }
            else
            {
                cbxControl.DataSource = null;
            }
        }

        /// <summary>
        /// 帮定ComboBox 枚举值的调用
        /// </summary>
        /// <param name="ddlControl">DropDownList控件ID</param>
        /// <param name="strTableName">表名</param>

        public static void ComboxBind(System.Windows.Forms.ComboBox cbxControl, string strWhere)
        {
            string strSql = "select  EnumValue ,EnumValueName from  dbo.T_EnumValue where EnumType='" + strWhere + "' Order By  EnumValue ";
            DataTable dt = new DataTable();
            dt = ExecuteDataSet(TDService.Data.SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql, null).Tables[0];
            cbxControl.DataSource = dt;
            cbxControl.DisplayMember = "EnumValueName";
            cbxControl.ValueMember = "EnumValue";

        }

        /// <summary>
        /// 帮定ComboBox 枚举值的调用
        /// </summary>
        /// <param name="ddlControl">DropDownList控件ID</param>
        /// <param name="strTableName">表名</param>

        public static void ComboxBind(System.Windows.Forms.ComboBox cbxControl, string strWhere, string strInitializeText, string strInitializeValue)
        {
            string strSql = "select  EnumValue ,EnumValueName from  dbo.T_EnumValue where EnumType='" + strWhere + "' Order By  EnumValue ";
            DataTable dt = new DataTable();
            dt = ExecuteDataSet(TDService.Data.SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql, null).Tables[0];


            DataRow dr = dt.NewRow();
            dr["EnumValueName"] = strInitializeText;
            dr["EnumValue"] = strInitializeValue;

            dt.Rows.InsertAt(dr, 0);


            cbxControl.DataSource = dt;
            cbxControl.DisplayMember = "EnumValueName";
            cbxControl.ValueMember = "EnumValue";

        }

    }

}

