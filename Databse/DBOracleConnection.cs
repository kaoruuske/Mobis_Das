using System;
using System.Data;
using System.Configuration;
using System.Data.OleDb;
using MOBISDAS.Common;
//using Oracle.DataAccess.Client;

namespace MOBISDAS.Database
{
    #region [Class] ivizconn : Database Connction, Execute 관련

    class DBOraDb
    {
        #region [선언] Database connection 
        //public static string gConnString = "server=128.134.104.31; uid=sa; pwd=; database=QES";
        //		public static string gConnString = "server=127.0.0.1; uid=sa; pwd=enwls; database=QES";
		
        public string gConnString = "" ;
        //public OracleConnection gConn = null;
        public OleDbConnection gConn = null;
        public bool gbLogin = false;
	    
        #endregion
        
        #region [Method] Database Connection
        public bool DatabaseConnect(string strConnString )
        {
            this.gConnString = strConnString;
            try
            {
                if (this.gConn == null)
                {
                    //gConn = new OracleConnection(gConnString);
                    gConn = new OleDbConnection(gConnString);
                    gConn.Open();
                }
                return true;
            }
            catch (System.Exception ex)
            {
                Error.SystemError(this.ToString(), ex,
                   "데이타베이스에 연결이 되지 않습니다.\n" +
                   "서버관리자에게 문의하시기 바랍니다.\n\n" + "Database Connection Error");
                return false;
            }

        }
        #endregion

        #region [Method] DatabaseClose
        public void DatabaseClose()
        {
            try
            {
                if (gConn != null) gConn.Close();
            }
            catch (Exception ex)
            {
                Error.SystemError(this.ToString(), ex);
            }
        }
        #endregion

//        string strConn = ConfigurationManager.AppSettings["db"];

//        OracleConnection conn = new OracleConnection();

//        public DBOracleConnection(string paramDB)
//        {
//            if (paramDB!="")
//                strConn = ConfigurationManager.AppSettings[paramDB];
//        }

//        private void openDB()
//        {
//            conn = new OracleConnection();

//            if (conn.State != System.Data.ConnectionState.Open)
//            {
//                conn.ConnectionString = strConn;
//                conn.Open();
//            }
//        }

//        private void closeDB()
//        {
//            if (conn.State != System.Data.ConnectionState.Closed)
//                conn.Close();

//            conn.Dispose();
//        }

//        public string selectCommand(ref DataSet resDS, string paramSQL, CommandType paramType, string paramValues)
//        {
//            try
//            {
//                openDB();

//                OracleCommand cmd = new OracleCommand(paramSQL, conn);
//                cmd.CommandType = paramType;

//                if (paramType == CommandType.StoredProcedure)
//                {
//                    if (paramValues != null)
//                    {
//                        string[] aryV = paramValues.Split(new char[] { '\t' });

//                        for (int i = 0; i < aryV.Length; i++)
//                        {
//                            cmd.Parameters.Add("p_" + i.ToString(), OracleDbType.Varchar2).Value = (aryV[i] == "" ? "*" : aryV[i]);
//                        }
//                    }

//                    cmd.Parameters.Add(new OracleParameter("p_return_rec", OracleDbType.Refthissor)).Direction = ParameterDirection.Output;
//                }

//                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
//                adapter.Fill(resDS);

//                cmd.Dispose();
//                adapter.Dispose();

//                return null;

//            }
//            catch (Exception err)
//            {
//                return err.Message;
//            }
//            finally
//            {
//                closeDB();
//            }
//        }

//        public string executeCommand(ref int paramRows, string paramSQL, CommandType paramType, string paramValues)
//        {
//            try
//            {
//                openDB();

//                OracleCommand cmd = new OracleCommand(paramSQL, conn);
//                cmd.CommandType = paramType;

//                if (paramType == CommandType.StoredProcedure)
//                {
//                    if (paramValues != null)
//                    {
//                        string[] aryV = paramValues.Split(new char[] { '\t' });

//                        for (int i = 0; i < aryV.Length; i++)
//                        {
//                            cmd.Parameters.Add("p_" + i.ToString(), OracleDbType.Varchar2).Value = (aryV[i] == "" ? " " : aryV[i]);
//                        }
//                    }

//                }

//                paramRows = cmd.ExecuteNonQuery();

//                cmd.Dispose();

//                return null;

//            }
//            catch (Exception err)
//            {
//                return err.Message;
//            }
//            finally
//            {
//                closeDB();
//            }
//        }

    }
    #endregion
}