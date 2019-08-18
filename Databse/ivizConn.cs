using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Drawing;
using System.Resources;
using System.Reflection;
using System.Windows.Forms;
using MOBISDAS.Common;
using System.Data;
using Microsoft.Win32;
using System.Data.SqlClient;
using System.Data.OleDb;
using MOBISDAS.Global;

namespace MOBISDAS.Database  
{
    
    public  enum  OLEProvider
    {   NONE=-1, 
        Microsoft_Jet_OLEDB_3_51=0, 
        Microsoft_Jet_OLEDB_4_0=1, 
        MSDASQL_1 = 2,
        MSDAORA_1 = 3,
        OraOLEDB_ORACLE = 4,
        SQLOLEDB_1 = 5}

    public class ivizConn 
    {
        #region 선언
        //db 설정 관리
        private static DBOleDb cDBOleDb = new DBOleDb();
        private static DBSqlDB cDBSqlDB = new DBSqlDB();
        private static DBOraDb cDBOraDb = new DBOraDb();
        //설정 File 관리
        public static Filehandle cFilehandle =null;
        private static string tmpFName = Application.StartupPath + "\\INI\\db.ini";
        
        //설정 parameter
        private static string _Datasource;
        private static string _PROVIDER;
        private static string _UID;
        private static string _PWD;
        private static string _Catalog;
        private static string _ConGubun;
        //TAG Parameter
        private static string _Applicationname;
        private static string _TagIp;
        private static string _Tagport;
        private static string _Serverurl;
        private static string _Workstatus;

        public static string RegistryPath = "Software\\" + Application.ProductName + "\\";				// Registry Root Path
        public static string Datasource { get { return _Datasource; } set { _Datasource = value; } }
        public static string PROVIDER         {           get            {               if (_PROVIDER == null)                                                return "2";                                            else                                               return _PROVIDER;                                            ; }                                               set { _PROVIDER = value; } }        
        public static string UID { get { return _UID; } set { _UID = value; } }
        public static string PWD { get { return _PWD; } set { _PWD = value; } }
        public static string Catalog { get { return _Catalog; } set { _Catalog = value; } }
        public static string ConGubun { get { return _ConGubun; } set { _ConGubun = value; } }
        //
        public static string Applicationname { get { return _Applicationname; } set { _Applicationname = value; } }
        public static string TagIp { get { return _TagIp; } set { _TagIp = value; } }
        public static string Tagport { get { return _Tagport; } set { _Tagport = value; } }
        public static string Serverurl { get { return _Serverurl; } set { _Serverurl = value; } }
        public static string Workstatus { get { return _Workstatus; } set { _Workstatus = value; } }


        #endregion

        public static bool DB_LOG = false;

        public static void DBConnctionLoad()
        {
            string index= RegistryInfo.RegistryRead(Registry.LocalMachine, "Software\\" + Application.ProductName  + "\\", "INDEX", "0");

            cFilehandle = new Filehandle(tmpFName);
            if (cFilehandle._FileInfo.Exists)
            {
                IniFile Filehandle = new IniFile(tmpFName);

                _Datasource = Filehandle.IniReadValue("DBINFO", "DATASOURCE", "(local)");
                _PROVIDER = Filehandle.IniReadValue("DBINFO", "PROVIDER", "5");
                _UID = Filehandle.IniReadValue("DBINFO", "UID", "sa");
                _PWD = Filehandle.IniReadValue("DBINFO", "PWD", "sa12sa");
                _Catalog = Filehandle.IniReadValue("DBINFO", "CATALOG", "local_simmetch_sps");

                EquipInfo.WORKCENTER = Filehandle.IniReadValue("LINE_INFO", "WORKCENTER", "");
                EquipInfo.ROUTE_NO = Filehandle.IniReadValue("LINE_INFO", "ROUTE_NO", "");
                EquipInfo.BODY_NO = Filehandle.IniReadValue("LINE_INFO", "BODY_NO", "");
                EquipInfo.WAIT_CNT = Filehandle.IniReadValue("LINE_INFO", "WAIT_CNT", "");

                _Applicationname = Filehandle.IniReadValue(".NETREMOTING", "APPLICATIONNAME", "WORK");
                _TagIp = Filehandle.IniReadValue(".NETREMOTING", "IP", "");
                _Tagport = Filehandle.IniReadValue(".NETREMOTING", "PORT", "8001");
                _Serverurl = Filehandle.IniReadValue(".NETREMOTING", "SERVERURL", "tcp://Localhost:8000/Tag");
                _Workstatus = Filehandle.IniReadValue(".NETREMOTING", "WORKSTATUS", "");
            }
            else
            {
                DBConnectionDefualtmakeFIle();
            }
        }
        public static bool DBConnectionDefualtmakeFIle()
        {
            bool bDBConnectionDefualtmakeFIle=false;

            Filehandle create = new Filehandle(tmpFName);

            IniFile cFilehandle = new IniFile(tmpFName);           
                
            cFilehandle.IniWriteValue ("DBINFO","DATASOURCE","");
            cFilehandle.IniWriteValue ("DBINFO","PROVIDER","");
            cFilehandle.IniWriteValue ("DBINFO","UID","");
            cFilehandle.IniWriteValue ("DBINFO","PWD","");
            cFilehandle.IniWriteValue("DBINFO", "CATALOG", "");           

            cFilehandle.IniWriteValue("LINE_INFO", "WORKCENTER", "");
            cFilehandle.IniWriteValue("LINE_INFO", "ROUTE_NO", "");
            cFilehandle.IniWriteValue("LINE_INFO", "BODY_NO", "");
            cFilehandle.IniWriteValue("LINE_INFO", "WAIT_CNT", "N");

            cFilehandle.IniWriteValue(".NETREMOTING", "APPLICATIONNAME", "WORK");
            cFilehandle.IniWriteValue(".NETREMOTING", "IP", "");
            cFilehandle.IniWriteValue(".NETREMOTING", "PORT", "8001");
            cFilehandle.IniWriteValue(".NETREMOTING", "SERVERURL", "tcp://Localhost:8000/Tag");
            cFilehandle.IniWriteValue(".NETREMOTING", "WORKSTATUS", "");

            return bDBConnectionDefualtmakeFIle;
                  
        }

        public static void DBConnctionSave()
        {
            IniFile cFilehandle = new IniFile(tmpFName);
            
            cFilehandle.IniWriteValue("DBINFO", "DATASOURCE", _Datasource);
            cFilehandle.IniWriteValue("DBINFO", "PROVIDER", _PROVIDER);
            cFilehandle.IniWriteValue("DBINFO", "UID", _UID);
            cFilehandle.IniWriteValue("DBINFO", "PWD", _PWD);
            cFilehandle.IniWriteValue("DBINFO", "CATALOG", _Catalog);                        

            cFilehandle.IniWriteValue("LINE_INFO", "WORKCENTER", EquipInfo.WORKCENTER);
            cFilehandle.IniWriteValue("LINE_INFO", "ROUTE_NO", EquipInfo.ROUTE_NO);
            cFilehandle.IniWriteValue("LINE_INFO", "BODY_NO", EquipInfo.BODY_NO);
            cFilehandle.IniWriteValue("LINE_INFO", "WAIT_CNT", EquipInfo.WAIT_CNT);

            cFilehandle.IniWriteValue(".NETREMOTING", "APPLICATIONNAME", _Applicationname);
            cFilehandle.IniWriteValue(".NETREMOTING", "IP", _TagIp);
            cFilehandle.IniWriteValue(".NETREMOTING", "PORT", _Tagport);
            cFilehandle.IniWriteValue(".NETREMOTING", "SERVERURL", _Serverurl);
            cFilehandle.IniWriteValue(".NETREMOTING", "WORKSTATUS", _Workstatus);
        }
        //TAG Server 연결
        public static void NetRemoting_Connect()
        {
            string applicationName = _Applicationname;
            string ip = _TagIp;
            int port = int.Parse(_Tagport);
            string serverUrl = _Serverurl;
            string[] workStatus = _Workstatus.Split(' ');

            NetRemoting.TagServerConnect(applicationName, ip, port, serverUrl, workStatus);
        }

        public static string ConnectionString() 
        {
            string strConn = null;

            switch (Convert.ToInt16(_PROVIDER) )           
            {
                case 0 :
                    strConn = "Provider=Microsoft.Jet.OLEDB.3.51;";
                    _ConGubun = "1";
                    break;

                case 1 :
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                                 "Jet OLEDB:Database Password=" + _PWD + ";";
                    _ConGubun = "1";
                    break;
                case 2 ://'ODBC
                    strConn = "Provider=MSDASQL.1;" +
                                 "Password=" + _PWD + ";" +
                                 "User ID=" + _UID + ";";
                    _ConGubun = "2";
                    break;
                case 3 ://'MSORA
                    strConn = "Provider=MSDAORA.1;" +
                                 "Password=" + _PWD + ";" +
                                 "User ID=" + _UID + ";";
                    _ConGubun = "1";
                    break;
                case 4 ://'ORA
                    strConn = "Provider=OraOLEDB.Oracle;" +
                                 "Password=" + _PWD + ";" +
                                 "User ID=" + _UID + ";";
                    _ConGubun = "1";
                    break;
                case 5:// 'SQL Server
                    strConn = "Provider=SQLOLEDB;Initial Catalog=" + _Catalog + ";" +
                                 "Password=" + _PWD + ";" +
                                 "User ID=" + _UID + ";";
                    _ConGubun = "1";
                    break;
            
            }
            strConn += "Persist Sethisity Info=True;" + "Data Source=" + _Datasource + ";";
           
            return strConn;
        }


        #region [Method](bool) DatabaseConnect
        public static bool DatabaseConnect() 
        {
            try
            {
                bool bDatabaseConnect = false;                                           
                if (_ConGubun == null) ConnectionString();
                switch (_ConGubun)
                {
                    case "1": bDatabaseConnect = cDBOleDb.DatabaseConnect(ConnectionString()); break;
                    case "2": bDatabaseConnect = cDBSqlDB.DatabaseConnect(ConnectionString()); break;
                    //case 3: bDatabaseConnect = cDBOraDb.DatabaseConnect(gstrConn); break;
                }
                return bDatabaseConnect;
            }
            catch (SqlException Err)
            {
                MessageBox.Show(Err.Message);
                return false;
            }
        }
        #endregion

        #region [Method] DatabaseClose
        public static void DatabaseClose()
        {
            switch (_ConGubun)
            {
                case "1":  cDBOleDb.DatabaseClose(); break;
                case "2":  cDBSqlDB.DatabaseClose(); break;
                //case 3:  cDBOraDb.DatabaseClose(); break;
            }
          
        }
        #endregion

        public void DBconn()
        {
            throw new System.NotImplementedException();

        }
        #region [Method] ExcuteDS
        public static bool Excute(StringBuilder strSql)
        {
            return Excute(strSql, (ParameterMember)null);
        }
        public static bool Excute(StringBuilder strSql, ParameterMember param)
        {
            return cDBOleDb.ExecuteNonQuery((OleDbTransaction)null, strSql, param);
        }
                   
        #endregion
     
        #region [Method] ExcuteDS
        public static bool ExcuteDS(StringBuilder strSql,ref DataSet ds)
        {
            return ExcuteDS(strSql, (ParameterMember)null,ref ds);
        }
        public static bool ExcuteDS(StringBuilder strSql, ParameterMember param, ref DataSet ds)
        {   
                return cDBOleDb.ExecuteDataSet((OleDbTransaction)null, strSql, param, ref ds); 
        }
        #endregion
    } 
}
