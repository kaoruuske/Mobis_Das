using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Windows.Forms;
using Microsoft.Win32;
using MOBISDAS.Common;

namespace MOBISDAS.Database
{
    #region [Class] ivizconn : Database Connction, Execute 관련
    public class DBSqlDB
    {
        #region [선언] Database Connection 선언
        public    SqlConnection gConn = null;
        public    string gConnString = "";
        //public string gConnString = "server=128.134.104.31; uid=sa; pwd=; database=QES";
        //		public   string gConnString = "server=127.0.0.1; uid=sa; pwd=enwls; database=QES";
        public   bool gbLogin = false;
        
        #endregion

        #region [Method] Database Connection
        public   bool DatabaseConnect(string strConnString)
        {
            gConnString = strConnString;
            try
            {
                if (gConn == null)
                {
                    //"Server=.,1433; database=KIMES; user id=sa; password=acs;Connect Timeout=600"
                    gConn = new SqlConnection(gConnString);
                    gConn.Open();
                }
                return true;
            }
            catch (System.Exception ex)
            {
                Error.SystemError("", ex,
                   "데이타베이스에 연결이 되지 않습니다.\n" +
                   "서버관리자에게 문의하시기 바랍니다.\n\n" + "Database Connection Error");
                
                return false;
            }
        }
        #endregion

        #region [Method] DatabaseClose
        public   void DatabaseClose()
        {
            try
            {
                if (gConn != null) gConn.Close();
            }
            catch (Exception ex)
            {
                Error.SystemError("", ex);

            }
        }
        #endregion

        #region [Method] AttachParameter
        /// <summary>
        /// Command객체에 Parameter를 추가한다.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="param"></param>
        private   void AttachParameters(SqlCommand command, ParameterMember param)
        {
            if (param == null) return;

            for (int i = 0; i < param.Count; i++)
            {
                SqlParameter cmdPara = new SqlParameter(param.GetName(i), param.GetType(i));
                cmdPara.Value = param.GetValue(i);

                command.Parameters.Add(cmdPara);
            }
        }
        #endregion

        #region [Method] AssignParameterValues
        /// <summary>
        /// SqlParameter에 values를 할당 
        /// </summary>
        /// <param name="commandParameters"></param>
        /// <param name="parameterValues"></param>
        private   void AssignParameterValues(SqlParameter[] commandParameters, object[] parameterValues)
        {
            if ((commandParameters == null) || (parameterValues == null))
                return;

            // we must have the same number of values as we pave parameters to put them in
            if (commandParameters.Length != parameterValues.Length)
            {
                throw new ArgumentException("Parameter count does not match Parameter Value count.");
            }

            //iterate through the SqlParameters, assigning the values from the corresponding position in the 
            //value array
            for (int i = 0, j = commandParameters.Length; i < j; i++)
            {
                commandParameters[i].Value = parameterValues[i];
            }
        }

        private   void AssignParameterValues(SqlParameter[] commandParameters, ParameterMember parameterValues)
        {
            if ((commandParameters == null) || (parameterValues == null))
                return;

            // we must have the same number of values as we pave parameters to put them in
            if (commandParameters.Length != parameterValues.Count)
            {
                throw new ArgumentException("Parameter count does not match Parameter Value count.");
            }

            int i = 0;
            foreach (SqlParameter p in commandParameters)
            {
                if (p.ParameterName.ToUpper() != parameterValues.GetName(i++).ToUpper())
                    throw new ArgumentException("ParameterName does not match ParamterMember Name");
            }

            //iterate through the SqlParameters, assigning the values from the corresponding position in the 
            //value array
            i = 0;
            for (int j = commandParameters.Length; i < j; i++)
            {
                commandParameters[i].Value = parameterValues.GetValue(i);
            }
        }
        #endregion

        #region [Method] PrepareCommand
        /// <summary>
        /// Command객체을 설정한다.
        /// </summary>
        /// <param name="command">SqlCommand</param>
        /// <param name="transaction">SqlTransaction</param>
        /// <param name="strSql">Query문</param>
        /// <param name="commandParameters">ParameterMember</param>
        private   void PrepareCommand(SqlCommand command, SqlTransaction transaction, StringBuilder strSql,
            ParameterMember commandParameters)
        {
            if (gConn.State != ConnectionState.Open)
            {
                gConn.Open();
            }

            command.Connection = gConn;
            command.CommandText = strSql.ToString();
            command.CommandType = CommandType.Text;

            if (transaction != null)
            {
                command.Transaction = transaction;
            }

            if (commandParameters != null)
            {
                AttachParameters(command, commandParameters);
            }
        }
        #endregion

        #region [Method] ExecuteReader
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public   SqlDataReader ExecuteReader(StringBuilder strSql)
        {
            return ExecuteReader(strSql, (ParameterMember)null);
        }

        /// <summary>
        /// Parameters를 설정하여 SQL 문을 실행합니다.
        /// </summary>
        /// <param name="strSql">SQL statement</param>
        /// <param name="param">Parameter</param>
        /// <returns></returns>
        public   SqlDataReader ExecuteReader(StringBuilder strSql, ParameterMember param)
        {
            SqlCommand sqlCmd = new SqlCommand(strSql.ToString(), gConn);
            AttachParameters(sqlCmd, param);
            return sqlCmd.ExecuteReader();
        }
        #endregion

        #region [Method] ExecuteScalar
        /// <summary>
        /// 쿼리를 실행하고 쿼리에서 반환된 결과 집합의 첫 번째 행의 첫 번째 열을 반환합니다. 추가 열이나 행은 무시됩니다.   
        /// </summary>
        /// <param name="strSql">StringBuilder SQL Syntax</param>
        /// <returns>결과 집합의 첫 행의 첫 열 또는 결과 집합이 비어있을 경우 null 참조입니다. </returns>
        public   string ExecuteScalar(StringBuilder strSql)
        {
            return ExecuteScalar(strSql, (ParameterMember)null);
        }
        public   string ExecuteScalar(StringBuilder strSql, ParameterMember param)
        {
            return ExecuteScalar((SqlTransaction)null, strSql, param);
        }

        public   string ExecuteScalar(SqlTransaction transaction, StringBuilder strSql, ParameterMember param)
        {
            SqlCommand sqlCmd = new SqlCommand(strSql.ToString(), gConn);
            PrepareCommand(sqlCmd, transaction, strSql, param);
            return sqlCmd.ExecuteScalar().ToString();
        }

        #endregion

        #region [Method] ExecuteNonQuery
        /// <summary>
        /// Query를 실행한다
        /// </summary>
        /// <param name="strSql">Query문</param>
        /// <returns>영향받은 레코드 수</returns>
        public   int ExecuteNonQuery(StringBuilder strSql)
        {
            return ExecuteNonQuery(strSql, null);
        }

        /// <summary>
        /// Query를 실행한다
        /// </summary>
        /// <param name="strSql">Query문</param>
        /// <param name="param">ParameterMember</param>
        /// <returns>영향받은 레코드 수</returns>
        public   int ExecuteNonQuery(StringBuilder strSql, ParameterMember param)
        {
            return ExecuteNonQuery((SqlTransaction)null, strSql, param);
        }

        /// <summary>
        /// Query를 실행한다.
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="strSql">Query문</param>
        /// <returns>영향받은 레코드 수</returns>
        public   int ExecuteNonQuery(SqlTransaction transaction, StringBuilder strSql)
        {
            return ExecuteNonQuery(transaction, strSql, (ParameterMember)null);
        }

        /// <summary>
        /// Query를 실행한다.
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="strSql">Query문</param>
        /// <param name="param">ParameterMember</param>
        /// <returns>영향받은 레코드 수</returns>
        public   int ExecuteNonQuery(SqlTransaction transaction, StringBuilder strSql, ParameterMember param)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, transaction, strSql, param);

            //finally, execute the command.
            int retval = cmd.ExecuteNonQuery();

            // detach the SqlParameters from the command object, so they can be used again.
            cmd.Parameters.Clear();
            return retval;
        }
        #endregion

        #region [Method] ExecuteDataSet : Query를 실행하여 DataSet을 Return한다.
        //public   DataSet ExecuteDataSet(StringBuilder strSql)
        //{
        //    return ExecuteDataSet(strSql, (ParameterMember)null);
        //}
        //public   DataSet ExecuteDataSet(StringBuilder strSql, ParameterMember param)
        //{
        //    return ExecuteDataSet((SqlTransaction)null, strSql, param);
        //}
        public bool ExecuteDataSet(SqlTransaction transaction, StringBuilder strSql, ref DataSet ds)
        {
            return ExecuteDataSet(transaction, strSql, (ParameterMember)null,ref ds);
        }
        public   bool ExecuteDataSet(SqlTransaction transaction, StringBuilder strSql, ParameterMember param,ref DataSet ds)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, transaction, strSql, param);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            cmd.Parameters.Clear();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
                return true;
            else
                return false;
        }

        #endregion

        #region [Method] ExecuteStoreProc
        /// <summary>
        /// Stored Procedure를 실행하고 결과를 ParameterMember에 담아 리턴한다.
        ///		Procedure자체의 리턴은 PrameterMember의 마지막에 'RC'라는 이름으로 추가되어 리턴된다.
        ///		thissor형태의 Output은 지원되지 않는다.
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="spName"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public int ExecuteStoreProc(string spName, ParameterMember parameterValues)
        {
            return ExecuteStoreProc((SqlTransaction)null, spName, parameterValues);
        }

        public  int ExecuteStoreProc(SqlTransaction transaction, string spName, ParameterMember parameterValues)
        {
            SqlCommand command = new SqlCommand();

            command.Connection = gConn;
            command.CommandText = spName;
            command.CommandType = CommandType.StoredProcedure;

            if (transaction != null) command.Transaction = transaction;

            if ((parameterValues != null) && (parameterValues.Count > 0))
            {
                SqlParameter[] commandParameters = ParameterCache.GetSpParameterSet(gConn, spName);
                AssignParameterValues(commandParameters, parameterValues);

                foreach (SqlParameter p in commandParameters)
                {
                    if ((p.Direction == ParameterDirection.InputOutput) && (p.Value == null))
                        p.Value = DBNull.Value;

                    command.Parameters.Add(p);
                }

                int retval = command.ExecuteNonQuery();

                int i = 0;
                foreach (SqlParameter p in commandParameters)
                {
                    if (p.Direction == ParameterDirection.Output || p.Direction == ParameterDirection.InputOutput)
                        parameterValues.SetValue(i, p.Value);
                    else if (p.Direction == ParameterDirection.ReturnValue)
                        parameterValues.Add(p.SqlDbType, @"RC", p.Value);
                    i++;
                }

                command.Parameters.Clear();
                return retval;
            }
            else
            {
                int retval = command.ExecuteNonQuery();

                command.Parameters.Clear();
                return retval;
            }
        }
        #endregion




        //========================================테스트============================================
        #region [Method] ExecuteStoreProc
        /// <summary>
        /// Stored Procedure를 실행하고 결과를 ParameterMember에 담아 리턴한다.
        ///		Procedure자체의 리턴은 PrameterMember의 마지막에 'RC'라는 이름으로 추가되어 리턴된다.
        ///		thissor형태의 Output은 지원되지 않는다.
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="spName"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public string ExecuteStoreProcs(string spName, ParameterMember parameterValues)
        {
            return ExecuteStoreProcs((SqlTransaction)null, spName, parameterValues);
        }

        public string ExecuteStoreProcs(SqlTransaction transaction, string spName, ParameterMember parameterValues)
        {
            SqlCommand command = new SqlCommand();

            command.Connection = gConn;
            command.CommandText = spName;
            command.CommandType = CommandType.StoredProcedure;

            if (transaction != null) command.Transaction = transaction;

            if ((parameterValues != null) && (parameterValues.Count > 0))
            {
                SqlParameter[] commandParameters = ParameterCache.GetSpParameterSet(gConn, spName);
                AssignParameterValues(commandParameters, parameterValues);

                foreach (SqlParameter p in commandParameters)
                {
                    if ((p.Direction == ParameterDirection.InputOutput) && (p.Value == null))
                        p.Value = DBNull.Value;

                    command.Parameters.Add(p);
                }

                string retval = command.ExecuteNonQuery().ToString();

                int i = 0;
                foreach (SqlParameter p in commandParameters)
                {
                    if (p.Direction == ParameterDirection.Output || p.Direction == ParameterDirection.InputOutput)
                        parameterValues.SetValue(i, p.Value);
                    else if (p.Direction == ParameterDirection.ReturnValue)
                        parameterValues.Add(p.SqlDbType, @"RC", p.Value);
                    i++;
                }

                //command.Parameters.Clear();
                return retval;
            }
            else
            {
                string retval = command.ExecuteNonQuery().ToString();

                //command.Parameters.Clear();
                return retval;
            }
        }
        #endregion
    }
    #endregion
}
