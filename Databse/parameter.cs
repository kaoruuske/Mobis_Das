using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Windows.Forms;
using Microsoft.Win32;


namespace MOBISDAS.Database
{
    #region [Class] ParameterCache : Stored Procedure의 Parameter 구하기
    public sealed class ParameterCache
    {
        #region private methods, variables, and constructors

        // 객체로 생성되지 않도록 하기위해
        private ParameterCache() { }
        private static Hashtable paramCache = Hashtable.Synchronized(new Hashtable());

        /// <summary>
        ///     stored Procedure의 Parameter를 구한다.
        /// </summary>
        /// <param name="conn">SqlConnection</param>
        /// <param name="spName">stored Procedure의 이름</param>
        /// <param name="includeReturnValueParameter">whether or not to include their return value parameter</param>
        /// <returns></returns>
        private static SqlParameter[] DiscoverSpParameterSet(string strConn, string spName)
        {
            using (SqlConnection cn = new SqlConnection(strConn))
            using (SqlCommand cmd = new  SqlCommand(spName, cn))
           
            {
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlCommandBuilder.DeriveParameters(cmd);
                SqlParameter[] discoveredParameters = new SqlParameter[cmd.Parameters.Count]; ;
                cmd.Parameters.CopyTo(discoveredParameters, 0);
                return discoveredParameters;
            }
        }

        //deep copy of cached SqlParameter array
        private static SqlParameter[] CloneParameters(SqlParameter[] originalParameters)
        {
            SqlParameter[] clonedParameters = new SqlParameter[originalParameters.Length];

            for (int i = 0, j = originalParameters.Length; i < j; i++)
                clonedParameters[i] = (SqlParameter)((ICloneable)originalParameters[i]).Clone();
            return clonedParameters;
        }

        #endregion private methods, variables, and constructors

        #region [Method] caching functions

        /// <summary>
        /// add parameter array to the cache
        /// </summary>
        /// <param name="connectionString">a valid connection string for a SqlConnection</param>
        /// <param name="commandText">the stored Procedure name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters to be cached</param>
        public static void CacheParameterSet(string connectionString, string commandText, params SqlParameter[] commandParameters)
        {
            string hashKey = connectionString + ":" + commandText;

            paramCache[hashKey] = commandParameters;
        }

        /// <summary>
        /// retrieve a parameter array from the cache
        /// </summary>
        /// <param name="connectionString">a valid connection string for a SqlConnection</param>
        /// <param name="commandText">the stored Procedure name or T-SQL command</param>
        /// <returns>an array of SqlParamters</returns>
        public static SqlParameter[] GetCachedParameterSet(string connectionString, string commandText)
        {
            string hashKey = connectionString + ":" + commandText;

            SqlParameter[] cachedParameters = (SqlParameter[])paramCache[hashKey];

            if (cachedParameters == null)
            {
                return null;
            }
            else
            {
                return CloneParameters(cachedParameters);
            }
        }

        #endregion caching functions

        #region [Method] Parameter Discovery Functions
        /// <summary>
        /// Retrieves the set of SqlParameters appropriate for the stored Procedure
        /// </summary>
        /// <remarks>
        /// This method will query the database for this information, and then store it in a cache for future requests.
        /// </remarks>
        /// <param name="connectionString">a valid connection string for a SqlConnection</param>
        /// <param name="spName">the name of the stored Procedure</param>
        /// <param name="includeReturnValueParameter">a bool value indicating whether the return value parameter should be included in the results</param>
        /// <returns>an array of SqlParameters</returns>
        public static SqlParameter[] GetSpParameterSet(SqlConnection conn, string spName)
        {
            string hashKey = conn.ToString() + ":" + spName;

            SqlParameter[] cachedParameters;

            cachedParameters = (SqlParameter[])paramCache[hashKey];

            if (cachedParameters == null)
            {
                cachedParameters = (SqlParameter[])(paramCache[hashKey] = DiscoverSpParameterSet( ivizConn.ConnectionString() , spName));
            }

            return CloneParameters(cachedParameters);
        }

        #endregion Parameter Discovery Functions
    }
    #endregion
}
