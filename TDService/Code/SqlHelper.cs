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
    /// SqlHelper���ṩ�ܸߵ����ݷ�������, 
    /// ʹ��SqlClient���ͨ�ö���.
    /// </summary>

    public abstract class SqlHelper
    {

        //�������ݿ����Ӵ�

        /// <summary>
        /// 
        /// </summary>
        public static readonly string ConnectionStringLocalTransaction = "Data Source=" + TDService.StaticForm.ini.IniReadValue("Server", "ServerName") + ";Initial Catalog=" + TDService.StaticForm.ini.IniReadValue("Server", "ServerDataBase") + ";User ID=" + TDService.StaticForm.ini.IniReadValue("Server", "ServerLoginName") + ";Password=" + TDService.StaticForm.ini.IniReadValue("Server", "ServerPwd");
        public static readonly string ConnectionStringGT = "Data Source=" + TDService.StaticForm.ini.IniReadValue("GTServer", "GTServerName") + ";Initial Catalog=" + TDService.StaticForm.ini.IniReadValue("GTServer", "GTServerDataBase") + ";User ID=" + TDService.StaticForm.ini.IniReadValue("GTServer", "GTServerLoginName") + ";Password=" + TDService.StaticForm.ini.IniReadValue("GTServer", "GTServerPwd");


        // ����Cache�����Hashtable����

        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());



        /// <summary>

        /// ʹ�������ַ�����ִ��һ��SqlCommand���û�м�¼���أ�

        /// ʹ���ṩ�Ĳ�����.

        /// </summary>

        /// <remarks>

        /// ʾ��:  

        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));

        /// </remarks>

        /// <param name="connectionString">һ����Ч��SqlConnection���Ӵ�</param>

        /// <param name="commandType">��������CommandType(stored procedure, text, etc.)</param>

        /// <param name="commandText">�����������ƻ���һ��T-SQL��䴮</param>

        /// <param name="commandParameters">ִ������Ĳ�����</param>

        /// <returns>�ܴ�����Ӱ�������</returns>

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

        /// <returns>�ܴ�����Ӱ�������</returns>

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
        /// ���ط�����ʱ��
        /// </summary>
        /// <param name="connectionString">�������ݿ��ַ���</param>
        /// <returns>���ط�����ʱ��</returns>
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

        /// ��һ�����ڵ�������ִ�����ݿ���������

        /// ʹ���ṩ�Ĳ�����.

        /// </summary>

        /// <remarks>

        /// e.g.:  

        ///  int result = ExecuteNonQuery(connection, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));

        /// </remarks>

        /// <param name="conn">һ�����ڵ����ݿ����Ӷ���</param>

        /// <param name="commandType">��������CommandType (stored procedure, text, etc.)</param>

        /// <param name="commandText">�����������ƻ���һ��T-SQL��䴮</param>

        /// <param name="commandParameters">ִ������Ĳ�����</param>

        /// <returns>�ܴ�����Ӱ�������</returns>

        public static int ExecuteNonQuery(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {



            SqlCommand cmd = new SqlCommand();



            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);

            int val = cmd.ExecuteNonQuery();

            cmd.Parameters.Clear();

            return val;

        }



        /// <summary>

        /// ��һ�������������ִ�����ݿ���������

        /// ʹ���ṩ�Ĳ�����.

        /// </summary>

        /// <remarks>

        /// e.g.:  

        ///  int result = ExecuteNonQuery(trans, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));

        /// </remarks>

        /// <param name="trans">һ�����ڵ�����</param>

        /// <param name="commandType">��������CommandType (stored procedure, text, etc.)</param>

        /// <param name="commandText">�����������ƻ���һ��T-SQL��䴮</param>

        /// <param name="commandParameters">ִ������Ĳ�����</param>

        /// <returns>�ܴ�����Ӱ�������</returns>

        public static int ExecuteNonQuery(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();

            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);

            int val = cmd.ExecuteNonQuery();

            cmd.Parameters.Clear();

            return val;

        }



        /// <summary>

        /// ��һ�����Ӵ���ִ��һ���������һ��SqlDataReader����

        /// ʹ���ṩ�Ĳ���.

        /// </summary>

        /// <remarks>

        /// e.g.:  

        ///  SqlDataReader r = ExecuteReader(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));

        /// </remarks>

        /// <param name="connectionString">һ����Ч��SqlConnection���Ӵ�</param>

        /// <param name="commandType">��������CommandType(stored procedure, text, etc.)</param>

        /// <param name="commandText">�����������ƻ���һ��T-SQL��䴮</param>

        /// <param name="commandParameters">ִ������Ĳ�����</param>

        /// <returns>һ�����������SqlDataReader</returns>

        public static SqlDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();

            SqlConnection conn = new SqlConnection(connectionString);



            // ���������Ҫ��ѯ�Ķ��������쳣

            // ����Ҫ�ر�

            // CommandBehavior.CloseConnection���쳣ʱ����������

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

        /// ��һ�����Ӵ���ִ��һ��������ر��е�һ�У���һ�е�ֵ

        /// ʹ���ṩ�Ĳ���.

        /// </summary>

        /// <remarks>

        /// e.g.:  

        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));

        /// </remarks>

        /// <param name="connectionString">һ����Ч��SqlConnection���Ӵ�</param>

        /// <param name="commandType">��������CommandType(stored procedure, text, etc.)</param>

        /// <param name="commandText">�����������ƻ���һ��T-SQL��䴮</param>

        /// <param name="commandParameters">ִ������Ĳ�����</param>        /// <returns>���صĶ�����ʹ��ʱ�ǵ�����ת��</returns>

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

        /// ��һ��������ִ��һ��������ر��е�һ�У���һ�е�ֵ

        /// ʹ���ṩ�Ĳ���.

        /// </summary>

        /// <remarks>

        /// e.g.:  

        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));

        /// </remarks>

        /// <param name="connectionString">һ����Ч��SqlConnection����</param>

        /// <param name="commandType">��������CommandType(stored procedure, text, etc.)</param>

        /// <param name="commandText">�����������ƻ���һ��T-SQL��䴮</param>

        /// <param name="commandParameters">ִ������Ĳ�����</param>        

        /// <returns>���صĶ�����ʹ��ʱ�ǵ�����ת��</returns>

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

        /// <param name="connectionString">���ݿ������ַ���</param>

        /// <param name="cmdType">��������CommandType(stored procedure, text, etc.)</param>

        /// <param name="cmdText">�����������ƻ���һ��T-SQL��䴮</param>

        /// <param name="commandParameters">ִ������Ĳ�����</param>

        /// <returns>���� DataSet ����</returns>
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
        /// <returns>���� DataSet ����</returns>
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

        /// �ڻ�������Ӳ�������

        /// </summary>

        /// <param name="cacheKey">������Key</param>

        /// <param name="cmdParms">��������</param>

        public static void CacheParameters(string cacheKey, params SqlParameter[] commandParameters)
        {

            parmCache[cacheKey] = commandParameters;

        }



        /// <summary>

        /// ��ȡ����Ĳ�������

        /// </summary>

        /// <param name="cacheKey">���һ����key</param>

        /// <returns>���ر�����Ĳ�������</returns>

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

        /// �ṩһ��SqlCommand���������

        /// </summary>

        /// <param name="cmd">SqlCommand����</param>

        /// <param name="conn">SqlConnection ����</param>

        /// <param name="trans">SqlTransaction ����</param>

        /// <param name="cmdType">CommandType ��������̣�T-SQL</param>

        /// <param name="cmdText">�������������ѯ��</param>

        /// <param name="cmdParms">�������õ��Ĳ�����</param>

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
        /// �ﶨComboBox
        /// </summary>
        /// <param name="ddlControl">DropDownList�ؼ�ID</param>
        /// <param name="strTableName">����</param>
        /// <param name="strText">��ʾ���ı��ֶ�</param>
        /// <param name="strValue">ֵ�ֶ�</param>
        /// <param name="strWhere">��ѯ������������Where</param>
        /// <param name="strOrder">�����ֶ�</param>
        /// <param name="strInitializeText">��ʼ���ı�</param>
        /// <param name="strInitializeValue">��ʼ��ֵ</param>
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
        /// �ﶨComboBox
        /// </summary>
        /// <param name="ddlControl">DropDownList�ؼ�ID</param>
        /// <param name="strTableName">����</param>
        /// <param name="strText">��ʾ���ı��ֶ�</param>
        /// <param name="strValue">ֵ�ֶ�</param>
        /// <param name="strWhere">��ѯ������������Where</param>
        /// <param name="strOrder">�����ֶ�</param>
        /// <param name="strInitializeText">��ʼ���ı�</param>
        /// <param name="strInitializeValue">��ʼ��ֵ</param>
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
        /// �ﶨComboBox
        /// </summary>
        /// <param name="ddlControl">DropDownList�ؼ�ID</param>
        /// <param name="strTableName">����</param>
        /// <param name="strText">��ʾ���ı��ֶ�</param>
        /// <param name="strValue">ֵ�ֶ�</param>
        /// <param name="strWhere">��ѯ������������Where</param>
        /// <param name="strOrder">�����ֶ�</param>
        /// <param name="strInitializeText">��ʼ���ı�--Ĭ�ϵĵ�һ��ѡ���ʾ��</param>
        /// <param name="strInitializeValue">��ʼ��ֵ--Ĭ�ϵĵ�һ��ѡ��Ķ�Ӧֵ�����أ�</param>
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
        /// �ﶨComboBox
        /// </summary>
        /// <param name="ddlControl">DropDownList�ؼ�ID</param>
        /// <param name="strTableName">����</param>
        /// <param name="strText">��ʾ���ı��ֶ�</param>
        /// <param name="strValue">ֵ�ֶ�</param>
        /// <param name="strWhere">��ѯ������������Where</param>
        /// <param name="strOrder">�����ֶ�</param>
        /// <param name="strInitializeText">��ʼ���ı�</param>
        /// <param name="strInitializeValue">��ʼ��ֵ</param>
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
        /// �ﶨComboBox
        /// </summary>
        /// <param name="ddlControl">DropDownList�ؼ�ID</param>
        /// <param name="strTableName">����</param>
        /// <param name="strText">��ʾ���ı��ֶ�</param>
        /// <param name="strValue">ֵ�ֶ�</param>
        /// <param name="strWhere">��ѯ������������Where</param>
        /// <param name="strOrder">�����ֶ�</param>

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
        /// �ﶨComboBox ö��ֵ�ĵ���
        /// </summary>
        /// <param name="ddlControl">DropDownList�ؼ�ID</param>
        /// <param name="strTableName">����</param>

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
        /// �ﶨComboBox ö��ֵ�ĵ���
        /// </summary>
        /// <param name="ddlControl">DropDownList�ؼ�ID</param>
        /// <param name="strTableName">����</param>

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

