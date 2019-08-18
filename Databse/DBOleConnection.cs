using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using System.Collections;
using System.Windows.Forms;
using Microsoft.Win32;
using MOBISDAS.Common;


namespace MOBISDAS.Database
{
    #region [Class] ivizconn : Database Connction, Execute 관련

    public class DBOleDb
    {
        #region [선언] database connection 선언
        public  OleDbConnection gConn = null;
        //public string gConnString = "Provider=MSDAORA.1;Data Source=BHSPM;User ID=BHSPM;Password=BHSPM";
        public string gConnString = "";
        public bool gbLogin = false;
        #endregion

        #region [Method] Database Connection
        public  bool DatabaseConnect(string gConnString)
        {            
            this.gConnString = gConnString;
            try
            {
               
                if (gConn == null)
                {
                    gConn = new OleDbConnection(gConnString);
                    gConn.Open();
                }

                string Connect_State = gConn.State.ToString();
                if (Connect_State == "Open")
                {
                    return true;
                }
                else
                {
                    gConn.Open();
                    return false;                    
                }                
            }
            catch (System.Exception ex)
            {
                //gConn = null;
                //Error.SystemError(this.ToString (),ex,
                //    "데이타베이스에 연결이 되지 않습니다.\n" +
                //    "서버관리자에게 문의하시기 바랍니다.\n\n" +   "Database Connection Error");

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

        #region [Method] AttachParameter
        /// <summary>
        /// Command객체에 Parameter를 추가한다.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="param"></param>
        private void AttachParameters(OleDbCommand command, ParameterMember param)
        {
            if (param == null) return;
            for (int i = 0; i < param.Count; i++)
            {
                OleDbParameter cmdPara = new OleDbParameter(param.GetName(i), param.GetType(i));

                cmdPara.Value = param.GetValue(i);

                if (command.CommandType != CommandType.StoredProcedure)
                {
                    command.CommandText = command.CommandText.Replace(param.GetName(i) + " ", "? ");
                }
                else
                {
                    command.CommandText = command.CommandText.Replace(param.GetName(i) , "");
                }
                command.Parameters.Add(cmdPara);

            }     
            //Console.WriteLine(command.CommandText.ToString());
           
        }
        #endregion

        private string AttachParametersErr(string CommandText, ParameterMember param,ref string Query)
        {
            if (param == null) return CommandText;
            CommandText = CommandText.Replace("\t", "");
            CommandText = CommandText.Replace(",", " ,") + " ";
            string ParmData = "";
            ParmData = "================================================================================================\n";
            ParmData += CommandText + "\n";
            ParmData += "================================================================================================\n";
           

            for (int i = 0; i < param.Count; i++)
            {
                ParmData += "\t" + param.GetName(i) + "\t='" + param.GetValue(i) + "' \n";

                CommandText = CommandText.Replace(param.GetName(i) + " ", "'" + param.GetValue(i) + "'");
            }
            CommandText = CommandText.Replace("  ", "");
            ParmData += "================================================================================================\n";
            Query = CommandText;
            CommandText = ParmData + CommandText;
            return CommandText;
            //Console.WriteLine(command.CommandText.ToString());

        }
        #region [Method] AssignParameterValues
        /// <summary>
        /// OleDbParameter에 values를 할당 
        /// </summary>
        /// <param name="commandParameters"></param>
        /// <param name="parameterValues"></param>
        private void AssignParameterValues(OleDbParameter[] commandParameters, object[] parameterValues)
        {
            if ((commandParameters == null) || (parameterValues == null))
                return;

            // we must have the same number of values as we pave parameters to put them in
            if (commandParameters.Length != parameterValues.Length)
            {
                throw new ArgumentException("Parameter count does not match Parameter Value count.");
            }

            //iterate through the OleDbParameters, assigning the values from the corresponding position in the 
            //value array
            for (int i = 0, j = commandParameters.Length; i < j; i++)
            {
                commandParameters[i].Value = parameterValues[i];
            }
        }

        private void AssignParameterValues(OleDbParameter[] commandParameters, ParameterMember parameterValues)
        {
            if ((commandParameters == null) || (parameterValues == null))
                return;

            // we must have the same number of values as we pave parameters to put them in
            if (commandParameters.Length != parameterValues.Count)
            {
                throw new ArgumentException("Parameter count does not match Parameter Value count.");
            }

            int i = 0;
            foreach (OleDbParameter p in commandParameters)
            {
                if (p.ParameterName.ToUpper() != parameterValues.GetName(i++).ToUpper())
                    throw new ArgumentException("ParameterName does not match ParamterMember Name");
            }

            //iterate through the OleDbParameters, assigning the values from the corresponding position in the 
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
        /// <param name="command">OleDbCommand</param>
        /// <param name="transaction">OleDbTransaction</param>
        /// <param name="strSql">Query문</param>
        /// <param name="commandParameters">ParameterMember</param>
        private  void PrepareCommand(OleDbCommand command, OleDbTransaction transaction, StringBuilder strSql, ParameterMember commandParameters)
        {
            if (gConn.State != ConnectionState.Open)
            {
                gConn.Open();
            }

            string CommandTextdata = strSql.ToString().Replace(",", " ,") + " ";
            CommandTextdata = CommandTextdata.Replace(")", " )");

            command.Connection = gConn;
            command.CommandText = CommandTextdata;

            string CommandTypeGubu = command.CommandText.ToUpper().Substring(0, 8);
            if (CommandTypeGubu.IndexOf("SELECT") == -1 & CommandTypeGubu.IndexOf("INSERT") == -1 & CommandTypeGubu.IndexOf("UPDATE") == -1 & CommandTypeGubu.IndexOf("DELETE") == -1)
            {
                command.CommandText = CommandTextdata.Replace(",", "");
                command.CommandType = CommandType.StoredProcedure;
            }
            else
            {
                command.CommandType = CommandType.Text;
            }
                
            if (transaction != null)
            {
                command.Transaction = transaction;
            }


            if (commandParameters != null)
            {
                AttachParameters(command, commandParameters);
            }
            if (ivizConn.DB_LOG && CommandTextdata.IndexOf("COMM")==-1)
            {
                string GetQuery = "";
                if (MessageBox.Show ( AttachParametersErr(CommandTextdata, commandParameters,ref GetQuery),"Qeury Log",    MessageBoxButtons.YesNo ) == DialogResult.Yes)
                {
                    Clipboard.Clear();
                    Clipboard.SetText( GetQuery.ToString ());
                }
            }
        }
        #endregion

        #region [Method] ExecuteReader
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public OleDbDataReader ExecuteReader(StringBuilder strSql)
        {
            return ExecuteReader(strSql, (ParameterMember)null);
        }

        /// <summary>
        /// Parameters를 설정하여 SQL 문을 실행합니다.
        /// </summary>
        /// <param name="strSql">SQL statement</param>
        /// <param name="param">Parameter</param>
        /// <returns></returns>
        public OleDbDataReader ExecuteReader(StringBuilder strSql, ParameterMember param)
        {
            OleDbCommand sqlCmd = new OleDbCommand(strSql.ToString(), gConn);
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
            return ExecuteScalar((OleDbTransaction)null, strSql, param);
        }

        public   string ExecuteScalar(OleDbTransaction transaction, StringBuilder strSql, ParameterMember param)
        {
            OleDbCommand sqlCmd = new OleDbCommand(strSql.ToString(), gConn);
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
        public bool ExecuteNonQuery(StringBuilder strSql)
        {
            return ExecuteNonQuery(strSql, null);
        }

        /// <summary>
        /// Query를 실행한다
        /// </summary>
        /// <param name="strSql">Query문</param>
        /// <param name="param">ParameterMember</param>
        /// <returns>영향받은 레코드 수</returns>
        public bool ExecuteNonQuery(StringBuilder strSql, ParameterMember param)
        {
            return ExecuteNonQuery((OleDbTransaction)null, strSql, param);
        }

        /// <summary>
        /// Query를 실행한다.
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="strSql">Query문</param>
        /// <returns>영향받은 레코드 수</returns>
        public bool ExecuteNonQuery(OleDbTransaction transaction, StringBuilder strSql)
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
        public bool ExecuteNonQuery(OleDbTransaction transaction, StringBuilder strSql, ParameterMember param)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                PrepareCommand(cmd, transaction, strSql, param);

                //finally, execute the command.
                int retval = cmd.ExecuteNonQuery();
                
                // detach the OleDbParameters from the command object, so they can be used again.
                cmd.Parameters.Clear();

                if (retval >= 1)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                //Console.WriteLine(ex.Message.ToString() + strSql.ToString () );
                return false;
            }
        }
             
        #endregion

        #region [Method] ExecuteDataSet : Query를 실행하여 DataSet을 Return한다.
         public bool ExecuteDataSet(OleDbTransaction transaction, StringBuilder strSql, ParameterMember param, ref DataSet ds)
        {
            try
            {
				OleDbCommand cmd = new OleDbCommand();
				PrepareCommand(cmd, transaction, strSql, param);

				OleDbDataAdapter da = new OleDbDataAdapter(cmd);
				ds = new DataSet();
				da.Fill(ds);
				cmd.Parameters.Clear();
				if (ds != null && ds.Tables[0].Rows.Count >= 0)
					return true;
				else
					return false;
			}
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        #endregion
    }
    #endregion
}
