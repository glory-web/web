using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections.Generic;


    public class DBParameter
    {
        public string ParamName;
        public object ParamValue;
        public DBParameter()
        {
        }
        public DBParameter(string PName, object PValue)
        {
            this.ParamName = PName;
            this.ParamValue = PValue;
        }
    }

    public class DBManager
    {
        public readonly static string ConnectionString = ConfigurationManager.ConnectionStrings["VSConnectionString"].ToString();
        private SqlConnection SqlDbConn;
        string sqlQuery = "";
        public int errCode = 0;
        public string errCodeStr = "";
        public string ExceptionStr = "";

        public DBManager()
        {         
        }

        public static DataTable PopulateList(string SelectSql)
        {
            SqlConnection Conn = new SqlConnection();
            try
            {
                Conn.ConnectionString = ConnectionString;
                Conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(SelectSql, Conn);
                DataSet ds = new DataSet();
                int x = adapter.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (Conn.State == ConnectionState.Open)
                    Conn.Close();
            }

        }

        public static int ExecuteTransactionQuery(string TransactSql)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = ConnectionString;
            SqlCommand cmd = new SqlCommand(TransactSql, Conn);
            Conn.Open();
            try
            {
                int effectedRows = cmd.ExecuteNonQuery();
                return effectedRows;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (Conn.State == ConnectionState.Open)
                    Conn.Close();
            }
            return 0;
        }

        public static DataTable PopulateList(string SelectSql, List<DBParameter> ParamList)
        {
            DataSet ds = new DataSet();
            SqlConnection Conn = new SqlConnection();
            try
            {
                Conn.ConnectionString = ConnectionString;
                Conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Conn;
                cmd.CommandText = SelectSql;
                cmd.Parameters.Clear();
                for (int i = 0; i < ParamList.Count; i++)
                {
                    cmd.Parameters.AddWithValue(ParamList[i].ParamName, ParamList[i].ParamValue);
                }
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (Conn.State == ConnectionState.Open)
                    Conn.Close();
            }
        }

        public static DataTable PopulateList(string SelectSql, List<SqlParameter> ParamList)
        {
            DataSet ds = new DataSet();
            SqlConnection Conn = new SqlConnection();
            try
            {
                Conn.ConnectionString = ConnectionString;
                Conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Conn;
                cmd.CommandText = SelectSql;
                cmd.Parameters.Clear();
                for (int i = 0; i < ParamList.Count; i++)
                {
                    cmd.Parameters.Add(ParamList[i]);
                }
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (Conn.State == ConnectionState.Open)
                    Conn.Close();
            }
        }

        public static int ExecuteTransactionQuery(String TransSqlStr, List<DBParameter> ParamList)
        {
            SqlConnection Conn = new SqlConnection();
            int effectedRows = 0;
            try
            {
                Conn.ConnectionString = ConnectionString;
                Conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Conn;
                cmd.CommandText = TransSqlStr;
                cmd.Parameters.Clear();
                for (int i = 0; i < ParamList.Count; i++)
                {
                    cmd.Parameters.AddWithValue(ParamList[i].ParamName, ParamList[i].ParamValue);
                }

                effectedRows = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (Conn.State == ConnectionState.Open)
                    Conn.Close();
            }
            return effectedRows;
        }

        public static int ExecuteTransactionQuery(String TransSqlStr, List<SqlParameter> ParamList)
        {
            SqlConnection Conn = new SqlConnection();
            int effectedRows = 0;
            try
            {
                Conn.ConnectionString = ConnectionString;
                Conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Conn;
                cmd.CommandText = TransSqlStr;
                cmd.Parameters.Clear();
                for (int i = 0; i < ParamList.Count; i++)
                {
                    cmd.Parameters.Add(ParamList[i]);
                }

                effectedRows = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (Conn.State == ConnectionState.Open)
                    Conn.Close();
            }
            return effectedRows;
        }

    }
