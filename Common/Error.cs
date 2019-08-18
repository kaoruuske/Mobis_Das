using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MOBISDAS.Common
{
    class Error
    {
        
		
		#region [Execute] System Error Log Save
		public static void SystemError(string strClass, Exception ex )
		{
			SystemError(strClass, ex,"" ,true);
		}
        public static void SystemError(string strClass, Exception ex, string UserMsg)
        {
            SystemError(strClass, ex, UserMsg, true);
            
        }

		public static void SystemError(string strClass, Exception ex,string UserMsg ,bool bMessage)
		{
			string[] strEx			= ex.StackTrace.Split('\n');
			string strStackTrace	= strEx[strEx.GetUpperBound(0)].Trim();
            string strMessage = null;

            if (UserMsg != "" )     strMessage += UserMsg + '\n';
            strMessage += "CompanyName: " + Application.CompanyName + '\n';
            strMessage += "Class      : " + strClass + '\n';
            strMessage += "StackTrace : " +  strStackTrace.Replace(strClass + "." ,"") + '\n';
            strMessage += "errMessage : " + ex.Message.Trim() + '\n';
            
            //try
            //{
            //    //StringBuilder strSql = new StringBuilder();
            //    //strSql.Append(@"INSERT INTO SystemError(Process, RegiDate, Class, StackTrace, Message, UserNumb, Version, IpAddress) ");
            //    //strSql.Append(@"VALUES(@Process, GetDate(), @Class, @StackTrace, @Message, @UserNumb, @Version, @IpAddress) ");

            //    //ParameterMember pm	= new ParameterMember();
            //    //pm.Add(SqlDbType.VarChar, "@Process",    Application.CompanyName);
            //    //pm.Add(SqlDbType.VarChar, "@Class",      strClass);
            //    //pm.Add(SqlDbType.Text,    "@StackTrace", strStackTrace);
            //    //pm.Add(SqlDbType.Text,    "@Message",    strMessage);
            //    //pm.Add(SqlDbType.VarChar, "@UserNumb",   UserInfo.UserNumb);
            //    //pm.Add(SqlDbType.VarChar, "@Version",    Application.ProductVersion);
            //    //pm.Add(SqlDbType.VarChar, "@IpAddress",  UserInfo.IpAddress);

            //    //DbHelper.ExecuteNonQuery(strSql, pm);
            //}
            //catch {}
            //finally
            //{
            if (bMessage)

                MessageBox.Show(strMessage, "Error : " + strClass, MessageBoxButtons.OK  , MessageBoxIcon.Error);
            //}
		}
		#endregion

   
	}

}

