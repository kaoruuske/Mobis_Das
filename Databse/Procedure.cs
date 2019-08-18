using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MOBISDAS.Global;

namespace MOBISDAS.Database
{
    class Procedure
    {
        public static bool PPC_MPIS_DTL_INFO(string WC_ID, string ROUTE_NO, string TR_ID, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_MPIS_DTL_INFO";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :REOUTE_NO  "; sqler.AddString(":REOUTE_NO", ROUTE_NO);
            SQL += "   :TR_ID  "; sqler.AddString(":TR_ID", TR_ID);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }

        public static bool PPC_MPIS_LOAD_HIST(string WC_ID, string ROUTE_NO, string TR_ID, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_MPIS_LOAD_HIST";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :REOUTE_NO  "; sqler.AddString(":REOUTE_NO", ROUTE_NO);
            SQL += "   :TR_ID  "; sqler.AddString(":TR_ID", TR_ID);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }

        public static bool PPC_MPIS(string WC_ID, string ROUTE_NO, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_MPIS";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :REOUTE_NO  "; sqler.AddString(":REOUTE_NO", ROUTE_NO);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }
        public static bool PPC_SAVE_BAD(string WC_ID,string ROUTE_NO,string TR_ID,string PART_ID, string BAD_GROUP,string BAD_CODE,string INPUT_TIME,string INSPECTOR, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_SAVE_BAD";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :ROUTE_NO  "; sqler.AddString(":ROUTE_NO", ROUTE_NO);
            SQL += "   :TR_ID  "; sqler.AddString(":TR_ID", TR_ID);
            SQL += "   :PART_ID  "; sqler.AddString(":PART_ID", PART_ID);
            SQL += "   :BAD_GROUP  "; sqler.AddString(":BAD_GROUP", BAD_GROUP);
            SQL += "   :BAD_CODE  "; sqler.AddString(":BAD_CODE", BAD_CODE);
            SQL += "   :INPUT_TIME  "; sqler.AddString(":INPUT_TIME", INPUT_TIME);
            SQL += "   :INSPECTOR  "; sqler.AddString(":INSPECTOR", INSPECTOR);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }

        public static bool PPC_LOAD_BAD_HIST(string WC_ID, string TR_ID, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_LOAD_BAD_HIST";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :TR_ID  "; sqler.AddString(":TR_ID", TR_ID);

            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }

        public static void PPC_DELETE_BAD_HIST(string ROW_STAMP)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_DELETE_BAD_HIST";
            SQL += "   :ROW_STAMP  "; sqler.AddString(":ROW_STAMP", ROW_STAMP);

            strSql.Append(SQL);

            ivizConn.Excute(strSql,sqler);
        }

        public static bool PPC_LOAD_PREV_ORDER(string WC_ID,string TR_ID, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_LOAD_PREV_ORDER";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :TR_ID  "; sqler.AddString(":TR_ID", TR_ID);

            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }

        public static bool PPC_LOAD_NEXT_ORDER(string WC_ID, string TR_ID, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_LOAD_NEXT_ORDER";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :TR_ID  "; sqler.AddString(":TR_ID", TR_ID);

            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }
        public static bool PPC_LOAD_BAD(string BAD_GROUP, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_LOAD_BAD";
            SQL += "   :BAD_GROUP  "; sqler.AddString(":BAD_GROUP", BAD_GROUP);
           
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }

        public static bool PPC_LOAD_PART(string WC_ID, string CAR_CODE, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_LOAD_PART";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :CAR_CD  "; sqler.AddString(":CAR_CD", CAR_CODE);
           
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }

        public static bool PPC_REAL_TAG_CHECK(string WC_ID, string TAG_ID, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_REAL_TAG_CHECK";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :TAG_ID  "; sqler.AddString(":TAG_ID", TAG_ID);

            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }

        public static bool PPC_INSP_SAVE(string WC_ID, string ROUTE, string CAR_CODE,string InspCode,string Result, string TR_ID)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_INSP_SAVE";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :STATION_NO  "; sqler.AddString(":STATION_NO", ROUTE);
            SQL += "   :CAR_CODE  "; sqler.AddString(":CAR_CODE", CAR_CODE);
            SQL += "   :INSP_CODE  "; sqler.AddString(":INSP_CODE", InspCode);
            SQL += "   :RESULT  "; sqler.AddString(":RESULT", Result);
            SQL += "   :TR_ID  "; sqler.AddString(":TR_ID", TR_ID);
            strSql.Append(SQL);

            return ivizConn.Excute(strSql, sqler);
        }

        public static bool PPC_DAILY_INSP_SAVE(string WORK_DATE,string WC_ID, string ROUTE, string WORK_TYPE, string WORK_VALUE)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_DAILY_INSP_SAVE";
            SQL += "   :WORK_DATE  "; sqler.AddString(":WORK_DATE", WORK_DATE);
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :ROUTE_NO  "; sqler.AddString(":ROUTE_NO", ROUTE);
            SQL += "   :WORK_TYPE  "; sqler.AddString(":WORK_TYPE", WORK_TYPE);
            SQL += "   :WORK_VALUE  "; sqler.AddString(":WORK_VALUE", WORK_VALUE);
            strSql.Append(SQL);

            return ivizConn.Excute(strSql, sqler);
        }

        public static bool PPC_INSP_LOAD(string WC_ID,string ROUTE, string CAR_CODE,string TR_ID, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_INSP_LOAD";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :STATION_NO  "; sqler.AddString(":STATION_NO", ROUTE);
            SQL += "   :CAR_CODE  "; sqler.AddString(":CAR_CODE", CAR_CODE);
            SQL += "   :TR_ID  "; sqler.AddString(":TR_ID", TR_ID);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }

        public static bool PPC_PARTID(string WC_ID, string CAR_CODE,ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_PARTID";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :CAR_CODE  "; sqler.AddString(":CAR_CODE", CAR_CODE);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }


        public static bool PPC_LOAD_TOOL_TYPE(string WC_ID, string ROUTE, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_LOAD_TOOL_TYPE";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :ROUTE  "; sqler.AddString(":ROUTE", ROUTE);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }
        //마지막 작업 TR정보
        public static bool PPC_MAIN_LASTWORK_TRID(string WC_ID, string ROUTE,ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_LASTWORK_TRID";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :ROUTE  "; sqler.AddString(":ROUTE", ROUTE);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }
        //가상서열 일반공정 마지막 작업 TR정보
        public static bool PPC_VIRTUAL_MAIN_LASTWORK_TRID(string WC_ID, string ROUTE, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_VIRTUAL_LASTWORK_TRID";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :ROUTE  "; sqler.AddString(":ROUTE", ROUTE);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }
        //작업서열 위에 두줄 
        public static bool PPC_MAIN_TOP_LIST(string WC_ID, string ROUTE, string LASTWORK,ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_MAIN_TOP_LIST";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :ROUTE  "; sqler.AddString(":ROUTE", ROUTE);
            SQL += "   :LASTWORK  "; sqler.AddString(":LASTWORK", LASTWORK);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }
        //가상서열 일반공정 작업서열 위에 두줄 
        public static bool PPC_VIRTUAL_MAIN_TOP_LIST(string WC_ID, string ROUTE, string LASTWORK, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_VIRTUAL_MAIN_TOP_LIST";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :ROUTE  "; sqler.AddString(":ROUTE", ROUTE);
            SQL += "   :LASTWORK  "; sqler.AddString(":LASTWORK", LASTWORK);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }
        //작업서열 아래 세줄
        public static bool PPC_MAIN_DOWN_LIST(string WC_ID, string ROUTE, string LASTWORK, string GUBUN,ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_MAIN_DOWN_LIST";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :ROUTE  "; sqler.AddString(":ROUTE", ROUTE);
            SQL += "   :LASTWORK  "; sqler.AddString(":LASTWORK", LASTWORK);
            SQL += "   :GUBUN  "; sqler.AddString(":GUBUN", GUBUN);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }
        //가상서열 일반공정 작업서열 아래 세줄
        public static bool PPC_VIRTUAL_MAIN_DOWN_LIST(string WC_ID, string ROUTE, string LASTWORK, string GUBUN, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_VIRTUAL_MAIN_DOWN_LIST";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :ROUTE  "; sqler.AddString(":ROUTE", ROUTE);
            SQL += "   :LASTWORK  "; sqler.AddString(":LASTWORK", LASTWORK);
            SQL += "   :GUBUN  "; sqler.AddString(":GUBUN", GUBUN);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }
        //서브, 트롤리 라인에서 작지 변경 조회 
        public static bool PPC_SUB_CHANGE_TOP_LIST(string WC_ID, string ROUTE, string LASTWORK, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_SUB_CHANGE_TOP_LIST";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :ROUTE  "; sqler.AddString(":ROUTE", ROUTE);
            SQL += "   :LASTWORK  "; sqler.AddString(":LASTWORK", LASTWORK);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }
        //가상서열 서브, 트롤리 라인에서 작지 변경 조회 위 두줄 
        public static bool PPC_VIRTUAL_SUB_CHANGE_TOP_LIST(string WC_ID, string ROUTE, string LASTWORK, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_VIRTUAL_SUB_CHANGE_TOP_LIST";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :ROUTE  "; sqler.AddString(":ROUTE", ROUTE);
            SQL += "   :LASTWORK  "; sqler.AddString(":LASTWORK", LASTWORK);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }
        //서브, 트롤리 라인에서 작지 변경 조회 
        public static bool PPC_SUB_CHANGE_DOWN_LIST(string WC_ID, string ROUTE, string LASTWORK, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_SUB_CHANGE_DOWN_LIST";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :ROUTE  "; sqler.AddString(":ROUTE", ROUTE);
            SQL += "   :LASTWORK  "; sqler.AddString(":LASTWORK", LASTWORK);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }
        //가상서열 서브, 트롤리 라인에서 작지 변경 조회 아래 세줄
        public static bool PPC_VIRTUAL_SUB_CHANGE_DOWN_LIST(string WC_ID, string ROUTE, string LASTWORK, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_VIRTUAL_SUB_CHANGE_DOWN_LIST";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :ROUTE  "; sqler.AddString(":ROUTE", ROUTE);
            SQL += "   :LASTWORK  "; sqler.AddString(":LASTWORK", LASTWORK);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }
        //작업서열 위에 두줄 
        public static bool PPC_MAIN_START_TOP_LIST(string WC_ID, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_MAIN_START_TOP_LIST";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }
        //가상 서열 시작 공정 작업서열 위에 두줄 
        public static bool PPC_VIRTUAL_MAIN_START_TOP_LIST(string WC_ID, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_VIRTUAL_MAIN_START_TOP_LIST";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }
        public static bool PPC_MAIN_START_DOWN_LIST(string WC_ID, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_MAIN_START_DOWN_LIST";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }
        //가상 서열 시작 공정 작업서열 아래 세줄 
        public static bool PPC_VIRTUAL_MAIN_START_DOWN_LIST(string WC_ID, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_VIRTUAL_MAIN_START_DOWN_LIST";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }
        // ALC 정보를 가져온다.
        public static bool PPC_MAINDETAIL_LIST(string WC_ID, string  ROUTE_NO, string CAR_CODE, string TR_ID,string GUBUN, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_MAINDETAIL_LIST";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :ROUTE_NO  "; sqler.AddString(":ROUTE_NO", ROUTE_NO);
            SQL += "   :CAR_CODE  "; sqler.AddString(":CAR_CODE", CAR_CODE);
            SQL += "   :TR_ID  "; sqler.AddString(":TR_ID", TR_ID);
            SQL += "   :GUBUN  "; sqler.AddString(":GUBUN", GUBUN);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }
        //가상서열 ALC 정보를 가져온다.
        public static bool PPC_VIRTUAL_MAINDETAIL_LIST(string WC_ID, string ROUTE_NO, string CAR_CODE, string TR_ID, string GUBUN, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_VIRTUAL_MAINDETAIL_LIST";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :ROUTE_NO  "; sqler.AddString(":ROUTE_NO", ROUTE_NO);
            SQL += "   :CAR_CODE  "; sqler.AddString(":CAR_CODE", CAR_CODE);
            SQL += "   :TR_ID  "; sqler.AddString(":TR_ID", TR_ID);
            SQL += "   :GUBUN  "; sqler.AddString(":GUBUN", GUBUN);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }
        public static bool PPC_VW_LINETRK(string WC_ID, string ROUTE_NO, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_VW_LINETRK";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :ROUTE_NO  "; sqler.AddString(":ROUTE_NO", ROUTE_NO);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }

        public static bool PPC_VW_LINETRK_SKID(string WC_ID, string ROUTE_NO, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_VW_LINETRK_SKID";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :ROUTE_NO  "; sqler.AddString(":ROUTE_NO", ROUTE_NO);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }
        //TR_ID 조회
        public static bool PPC_TRID(string WC_ID, string ORDER_DATE, string COMMIT_NO, string BODY_NO, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_TRID";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :ORDER_DATE  "; sqler.AddString(":ORDER_DATE", ORDER_DATE);
            SQL += "   :COMMIT_NO  "; sqler.AddString(":COMMIT_NO", COMMIT_NO);
            SQL += "   :BODY_NO  "; sqler.AddString(":BODY_NO", BODY_NO);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }
        //가상서열 TR_ID 조회
        public static bool PPC_VIRTUAL_TRID(string WC_ID, string ORDER_DATE, string COMMIT_NO, string BODY_NO, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_VIRTUAL_TRID";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :ORDER_DATE  "; sqler.AddString(":ORDER_DATE", ORDER_DATE);
            SQL += "   :COMMIT_NO  "; sqler.AddString(":COMMIT_NO", COMMIT_NO);
            SQL += "   :BODY_NO  "; sqler.AddString(":BODY_NO", BODY_NO);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }
        //투입공정에서 투입이 되었는지 조회
        public static bool PPC_INPUT_FLAG(string WC_ID, string ORDER_DATE, string COMMIT_NO, string BODY_NO, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_INPUT_FLAG";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :ORDER_DATE  "; sqler.AddString(":ORDER_DATE", ORDER_DATE);
            SQL += "   :COMMIT_NO  "; sqler.AddString(":COMMIT_NO", COMMIT_NO);
            SQL += "   :BODY_NO  "; sqler.AddString(":BODY_NO", BODY_NO);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }
        //가상서열 투입공정에서 투입이 되었는지 조회
        public static bool PPC_VIRTUAL_INPUT_FLAG(string WC_ID, string ORDER_DATE, string COMMIT_NO, string BODY_NO, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_VIRTUAL_INPUT_FLAG";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :ORDER_DATE  "; sqler.AddString(":ORDER_DATE", ORDER_DATE);
            SQL += "   :COMMIT_NO  "; sqler.AddString(":COMMIT_NO", COMMIT_NO);
            SQL += "   :BODY_NO  "; sqler.AddString(":BODY_NO", BODY_NO);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }
        //이전 공정에 있는지  조회
        public static bool PPC_BEFORE_ROUTE_CHECK(string WC_ID, string CAR_CODE, string ROUTE_NO, string BARCODE, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_BEFORE_ROUTE_CHECK";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :CAR_CODE  "; sqler.AddString(":CAR_CODE", CAR_CODE);
            SQL += "   :ROUTE_NO  "; sqler.AddString(":ROUTE_NO", ROUTE_NO);
            SQL += "   :BARCODE  "; sqler.AddString(":BARCODE", BARCODE);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }
        //가상서열 이전 공정에 있는지  조회
        public static bool PPC_VIRTUAL_BEFORE_ROUTE_CHECK(string WC_ID, string CAR_CODE, string ROUTE_NO, string BARCODE, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_VIRTUAL_BEFORE_ROUTE_CHECK";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :CAR_CODE  "; sqler.AddString(":CAR_CODE", CAR_CODE);
            SQL += "   :ROUTE_NO  "; sqler.AddString(":ROUTE_NO", ROUTE_NO);
            SQL += "   :BARCODE  "; sqler.AddString(":BARCODE", BARCODE);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }
        //REWORK 조회
        public static bool PPC_REWORK_CHECK(string WC_ID, string ROUTE_NO, string TR_ID, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_REWORK_CHECK";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :ROUTE_NO  "; sqler.AddString(":ROUTE_NO", ROUTE_NO);
            SQL += "   :TR_ID  "; sqler.AddString(":TR_ID", TR_ID);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }
        //가상서열 REWORK 조회
        public static bool PPC_VIRTUAL_REWORK_CHECK(string WC_ID, string ROUTE_NO, string TR_ID, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_VIRTUAL_REWORK_CHECK";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :ROUTE_NO  "; sqler.AddString(":ROUTE_NO", ROUTE_NO);
            SQL += "   :TR_ID  "; sqler.AddString(":TR_ID", TR_ID);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }
        //NEW PROCESSJOB
        public static bool PPC_PROCESSJOB_ALC(string BARCODE, string WC_ID, string ROUTE_NO, string CAR_CODE,
                                          string PART_ID, string ALC, string READ_BARCODE, string TR_ID, string GUBUN, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_PROCESSJOB_ALC";
            SQL += "   :BARCODE  "; sqler.AddString(":BARCODE", BARCODE);
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :ROUTE_NO  "; sqler.AddString(":ROUTE_NO", ROUTE_NO);
            SQL += "   :CAR_CODE  "; sqler.AddString(":CAR_CODE", CAR_CODE);
            SQL += "   :PART_ID  "; sqler.AddString(":PART_ID", PART_ID);
            SQL += "   :ALC  "; sqler.AddString(":ALC", ALC);
            SQL += "   :READ_BARCODE  "; sqler.AddString(":READ_BARCODE", READ_BARCODE);
            SQL += "   :TR_ID  "; sqler.AddString(":TR_ID", TR_ID);
            SQL += "   :GUBUN  "; sqler.AddString(":GUBUN", GUBUN);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }
        // TOOL 정보
        public static bool PPC_LOAD_TOOL(string WC_ID, string CAR_CODE, string ROUTE_NO, string PART_ID, 
                                         string TR_ID,  string ASSY_SEQ,string ORDER_DATE, string BODY_NO, string CMT, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_TOOL_LIST";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :CAR_CODE  "; sqler.AddString(":CAR_CODE", CAR_CODE);
            SQL += "   :ROUTE_NO  "; sqler.AddString(":ROUTE_NO", ROUTE_NO);
            SQL += "   :PART_ID  "; sqler.AddString(":PART_ID", PART_ID);
            SQL += "   :TR_ID  "; sqler.AddString(":TR_ID", TR_ID);
            SQL += "   :ASSY_SEQ  "; sqler.AddString(":ASSY_SEQ", ASSY_SEQ);
            SQL += "   :ORDER_DATE  "; sqler.AddString(":ORDER_DATE", ORDER_DATE);
            SQL += "   :BODY_NO  "; sqler.AddString(":BODY_NO", BODY_NO);
            SQL += "   :CMT  "; sqler.AddString(":CMT", CMT);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }
        //가상서열 TOOL 정보
        public static bool PPC_VIRTUAL_LOAD_TOOL(string WC_ID, string CAR_CODE, string ROUTE_NO, string PART_ID,
                                         string TR_ID, string ASSY_SEQ, string ORDER_DATE, string BODY_NO, string CMT, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_VIRTUAL_TOOL_LIST";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :CAR_CODE  "; sqler.AddString(":CAR_CODE", CAR_CODE);
            SQL += "   :ROUTE_NO  "; sqler.AddString(":ROUTE_NO", ROUTE_NO);
            SQL += "   :PART_ID  "; sqler.AddString(":PART_ID", PART_ID);
            SQL += "   :TR_ID  "; sqler.AddString(":TR_ID", TR_ID);
            SQL += "   :ASSY_SEQ  "; sqler.AddString(":ASSY_SEQ", ASSY_SEQ);
            SQL += "   :ORDER_DATE  "; sqler.AddString(":ORDER_DATE", ORDER_DATE);
            SQL += "   :BODY_NO  "; sqler.AddString(":BODY_NO", BODY_NO);
            SQL += "   :CMT  "; sqler.AddString(":CMT", CMT);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }
        // TOOL 이미지 체결 위치 정보 조회
        public static bool PPC_TOOL_IMAGE_POSITION(string WC_ID, string CAR_CODE, string ROUTE_NO, string PART_ID,string ASSY_SEQ, 
                                                        string ORDER_DATE, string BODY_NO, string CMT, string TR_ID, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_TOOL_IMAGE_POSITION";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :CAR_CODE  "; sqler.AddString(":CAR_CODE", CAR_CODE);
            SQL += "   :ROUTE_NO  "; sqler.AddString(":ROUTE_NO", ROUTE_NO);
            SQL += "   :PART_ID  "; sqler.AddString(":PART_ID", PART_ID);
            SQL += "   :ASSY_SEQ  "; sqler.AddString(":ASSY_SEQ", ASSY_SEQ);
            SQL += "   :ORDER_DATE  "; sqler.AddString(":ORDER_DATE", ORDER_DATE);
            SQL += "   :BODY_NO  "; sqler.AddString(":BODY_NO", BODY_NO);
            SQL += "   :CMT  "; sqler.AddString(":CMT", CMT);
            SQL += "   :TR_ID  "; sqler.AddString(":TR_ID", TR_ID);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }
        //가상서열 TOOL 이미지 체결 위치 정보 조회
        public static bool PPC_VIRTUAL_TOOL_IMAGE_POSITION(string WC_ID, string CAR_CODE, string ROUTE_NO, string PART_ID, string ASSY_SEQ,
                                                        string ORDER_DATE, string BODY_NO, string CMT, string TR_ID, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_VIRTUAL_TOOL_IMAGE_POSITION";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :CAR_CODE  "; sqler.AddString(":CAR_CODE", CAR_CODE);
            SQL += "   :ROUTE_NO  "; sqler.AddString(":ROUTE_NO", ROUTE_NO);
            SQL += "   :PART_ID  "; sqler.AddString(":PART_ID", PART_ID);
            SQL += "   :ASSY_SEQ  "; sqler.AddString(":ASSY_SEQ", ASSY_SEQ);
            SQL += "   :ORDER_DATE  "; sqler.AddString(":ORDER_DATE", ORDER_DATE);
            SQL += "   :BODY_NO  "; sqler.AddString(":BODY_NO", BODY_NO);
            SQL += "   :CMT  "; sqler.AddString(":CMT", CMT);
            SQL += "   :TR_ID  "; sqler.AddString(":TR_ID", TR_ID);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }

        // TOOL 상,하한치 CHECK
        public static bool PPC_TOOL_CHECK(string WC_ID, string CAR_CODE, string ROUTE_NO, string PART_ID,ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_TOOLMESSPECCHECK";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :CAR_CODE  "; sqler.AddString(":CAR_CODE", CAR_CODE);
            SQL += "   :ROUTE_NO  "; sqler.AddString(":ROUTE_NO", ROUTE_NO);
            SQL += "   :PART_ID  "; sqler.AddString(":PART_ID", PART_ID);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }
        
        // TOOL 체결값 이력관리
        public static bool PPC_TOOL_CHECK_HIST(string WC_ID, string TR_ID, string ROUTE_NO, string PART_ID, 
                                               string TWORK_SEQ, string TVALUE, string TRESULT, string TDEVICE)
        {   
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_TOOLMESSPECCHECK_HIST";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :TR_ID  "; sqler.AddString(":TR_ID", TR_ID);
            SQL += "   :ROUTE_NO  "; sqler.AddString(":ROUTE_NO", ROUTE_NO);
            SQL += "   :PART_ID  "; sqler.AddString(":PART_ID", PART_ID);
            SQL += "   :TWORK_SEQ  "; sqler.AddString(":TWORK_SEQ", TWORK_SEQ);
            SQL += "   :TVALUE  "; sqler.AddString(":TVALUE", TVALUE);
            SQL += "   :TRESULT  "; sqler.AddString(":TRESULT", TRESULT);
            SQL += "   :TDEVICE  "; sqler.AddString(":TDEVICE", TDEVICE);
            strSql.Append(SQL);

            return ivizConn.Excute(strSql, sqler);
        }

        // 전동 TOOL 체결값 이력관리
        public static bool PPC_ETOOL_CHECK_HIST(string WC_ID, string TR_ID, string ROUTE_NO, string PART_ID,
                                               string TWORK_SEQ, string TVALUE, string TRESULT, string TDEVICE)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_ETOOLMESSPECCHECK_HIST";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :TR_ID  "; sqler.AddString(":TR_ID", TR_ID);
            SQL += "   :ROUTE_NO  "; sqler.AddString(":ROUTE_NO", ROUTE_NO);
            SQL += "   :PART_ID  "; sqler.AddString(":PART_ID", PART_ID);
            SQL += "   :TWORK_SEQ  "; sqler.AddString(":TWORK_SEQ", TWORK_SEQ);
            SQL += "   :TVALUE  "; sqler.AddString(":TVALUE", TVALUE);
            SQL += "   :TRESULT  "; sqler.AddString(":TRESULT", TRESULT);
            SQL += "   :TDEVICE  "; sqler.AddString(":TDEVICE", TDEVICE);
            strSql.Append(SQL);

            return ivizConn.Excute(strSql, sqler);
        }

        // Barcode 작업시 해당 PART_ID가 예외처리 TABLE에 존재하는지 체크
        public static bool PPC_ALC_EXP(string WC_ID, string CAR_CODE, string PART_ID, string ALC_CODE, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_ALC_EXP";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :CAR_CODE  "; sqler.AddString(":CAR_CODE", CAR_CODE);
            SQL += "   :PART_ID  "; sqler.AddString(":PART_ID", PART_ID);
            SQL += "   :ALC_CODE  "; sqler.AddString(":ALC_CODE", ALC_CODE);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }

        // 바코드 작업 시 해당 PART_ID가 예외처리 TABLE에 존재하는지 체크(이종작업 비교)
        public static bool SP_PPC_STATION_EXP(string WC_ID, string ROUTE_NO, string PART_ID, string BARCODE, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_STATION_EXP";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :ROUTE_NO  "; sqler.AddString(":ROUTE_NO", ROUTE_NO);
            SQL += "   :PART_ID  "; sqler.AddString(":PART_ID", PART_ID);
            SQL += "   :BARCODE  "; sqler.AddString(":BARCODE", BARCODE);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }

        // 작업완료
        public static bool PPC_WORK_COMPLETE(string WC_ID, string ROUTE_NO, string TR_ID, string GUBUN)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_WORKCOMPLETE_PROCESS";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :ROUTE_NO  "; sqler.AddString(":ROUTE_NO", ROUTE_NO);
            SQL += "   :TR_ID  "; sqler.AddString(":TR_ID", TR_ID);
            SQL += "   :GUBUN  "; sqler.AddString(":GUBUN", GUBUN); 
            strSql.Append(SQL);

            return ivizConn.Excute(strSql, sqler);
        }
        //가상서열 작업완료
        public static bool PPC_VIRTUAL_WORK_COMPLETE(string WC_ID, string ROUTE_NO, string TR_ID, string GUBUN)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_VIRTUAL_WORKCOMPLETE_PROCESS";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :ROUTE_NO  "; sqler.AddString(":ROUTE_NO", ROUTE_NO);
            SQL += "   :TR_ID  "; sqler.AddString(":TR_ID", TR_ID);
            SQL += "   :GUBUN  "; sqler.AddString(":GUBUN", GUBUN);
            strSql.Append(SQL);

            return ivizConn.Excute(strSql, sqler);
        }
        //SUB(CPS) 작업지시 조회
        public static bool PPC_SUB_WORKORDER(string WC_ID, string ORDER_DATE, string COMMIT_NO, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_SUB_WORKORDER_LIST";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :ORDER_DATE  "; sqler.AddString(":ORDER_DATE", ORDER_DATE);
            SQL += "   :COMMIT_NO  "; sqler.AddString(":COMMIT_NO", COMMIT_NO);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }
        //가상서열 SUB(CPS) 작업지시 조회
        public static bool PPC_VIRTUAL_SUB_WORKORDER(string WC_ID, string ORDER_DATE, string COMMIT_NO, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_VIRTUAL_SUB_WORKORDER_LIST";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :ORDER_DATE  "; sqler.AddString(":ORDER_DATE", ORDER_DATE);
            SQL += "   :COMMIT_NO  "; sqler.AddString(":COMMIT_NO", COMMIT_NO);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }
        //라인 시리얼 포트 정보
        public static bool PPC_LINE_INFO(string WC_ID, string ROUTE_NO,ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_LINE_INFO";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :ROUTE_NO  "; sqler.AddString(":ROUTE_NO", ROUTE_NO);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }

        //라인 시리얼 포트 정보
        public static bool PPC_LINE_INFO2(string WC_ID, string ROUTE_NO, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_LINE_INFO2";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :ROUTE_NO  "; sqler.AddString(":ROUTE_NO", ROUTE_NO);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }
        //KEEPER 라인 조회
        public static bool PPC_WORK_KEEPER(string WC_ID, string BARCODE, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_WORK_KEEPER";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :BARCODE  "; sqler.AddString(":BARCODE", BARCODE);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }
        //가상서열 KEEPER 라인 조회
        public static bool PPC_VIRTUAL_WORK_KEEPER(string WC_ID, string BARCODE, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_VIRTUAL_WORK_KEEPER";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :BARCODE  "; sqler.AddString(":BARCODE", BARCODE);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }
        // KEEPER 폼에서 결과가 OK인 체결값 조회
        public static bool PPC_KEEPER_TOOL_VALUES(string WC_ID, string TR_ID, string ROUTE_NO, 
                                                  string PART_ID, string GUBUN, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_WORK_KEEPER_TOOL_VALUES";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :TR_ID  "; sqler.AddString(":TR_ID", TR_ID);
            SQL += "   :ROUTE_NO  "; sqler.AddString(":ROUTE_NO", ROUTE_NO);
            SQL += "   :PART_ID  "; sqler.AddString(":PART_ID", PART_ID);
            SQL += "   :GUBUN  "; sqler.AddString(":GUBUN", GUBUN);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }
        // 조립 투입공정
        public static bool PPC_ROUTE_TRK_INFO(string WC_ID, string ROUTE_NO, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_ROUTE_TRK_INFO";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :ROUTE_NO  "; sqler.AddString(":ROUTE_NO", ROUTE_NO);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }
        // TAGMASTER에 투입중인 TAG_ID 있는지 조회
        public static bool PPC_SELECT_TRK_SKID(string WC_ID, string ORDER_DATE, string CMT, string BODY_NO, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_SELECT_TRK_SKID";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :ORDER_DATE  "; sqler.AddString(":ORDER_DATE", ORDER_DATE);
            SQL += "   :CMT  "; sqler.AddString(":CMT", CMT);
            SQL += "   :BODY_NO  "; sqler.AddString(":BODY_NO", BODY_NO);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }
        public static bool PPC_SELECT_WAIT_ORDER_CNT(string WC_ID, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_SELECT_WAIT_ORDER_CNT";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }
        //가상서열 대기 작업지시 확인
        public static bool PPC_VIRTUAL_SELECT_WAIT_ORDER_CNT(string WC_ID, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_VIRTUAL_SELECT_WAIT_ORDER_CNT";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }
        public static bool PPC_SELECT_DUPORDER(string WC_ID, string BODY_NO,ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_SELECT_DUPORDER";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :BODY_NO  "; sqler.AddString(":BODY_NO", BODY_NO);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }
        //가상서열 중복바디 체크 및 말소바디 체크
        public static bool PPC_VIRTUAL_SELECT_DUPORDER(string WC_ID, string BODY_NO, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_VIRTUAL_SELECT_DUPORDER";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :BODY_NO  "; sqler.AddString(":BODY_NO", BODY_NO);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }
        // 스키드 매칭
        public static bool PPC_INPUT_TRAN(string WC_ID, string TR_ID, string BARCODE)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_INPUT_TRAN";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :TR_ID  "; sqler.AddString(":TR_ID", TR_ID);
            SQL += "   :BARCODE  "; sqler.AddString(":BARCODE", BARCODE); ;
            strSql.Append(SQL);

            return ivizConn.Excute(strSql, sqler);
        }
        // 스키드 매칭
        public static bool PPC_INPUT_TRAN_CPM1(string WC_ID, string TR_ID, string BARCODE)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_INPUT_TRAN_CPM1";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :TR_ID  "; sqler.AddString(":TR_ID", TR_ID);
            SQL += "   :BARCODE  "; sqler.AddString(":BARCODE", BARCODE); ;
            strSql.Append(SQL);

            return ivizConn.Excute(strSql, sqler);
        }
        //가상서열 CPM1 스키드 매칭
        public static bool PPC_VIRTUAL_INPUT_TRAN_CPM1(string WC_ID, string TR_ID, string BARCODE)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_VIRTUAL_INPUT_TRAN_CPM1";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :TR_ID  "; sqler.AddString(":TR_ID", TR_ID);
            SQL += "   :BARCODE  "; sqler.AddString(":BARCODE", BARCODE); ;
            strSql.Append(SQL);

            return ivizConn.Excute(strSql, sqler);
        }
        // 스키드 매칭
        public static bool PPC_INPUT_TRAN_CPM2(string WC_ID, string TR_ID, string BARCODE)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_INPUT_TRAN_CPM2";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :TR_ID  "; sqler.AddString(":TR_ID", TR_ID);
            SQL += "   :BARCODE  "; sqler.AddString(":BARCODE", BARCODE); ;
            strSql.Append(SQL);

            return ivizConn.Excute(strSql, sqler);
        }
        //가상서열 CPM2 스키드 매칭
        public static bool PPC_VIRTUAL_INPUT_TRAN_CPM2(string WC_ID, string TR_ID, string BARCODE)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_VIRTUAL_INPUT_TRAN_CPM2";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :TR_ID  "; sqler.AddString(":TR_ID", TR_ID);
            SQL += "   :BARCODE  "; sqler.AddString(":BARCODE", BARCODE); ;
            strSql.Append(SQL);

            return ivizConn.Excute(strSql, sqler);
        }
        // 스키드 매칭
        public static bool PPC_INPUT_TRAN_FEM1(string WC_ID, string TR_ID, string BARCODE)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_INPUT_TRAN_FEM1";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :TR_ID  "; sqler.AddString(":TR_ID", TR_ID);
            SQL += "   :BARCODE  "; sqler.AddString(":BARCODE", BARCODE); ;
            strSql.Append(SQL);

            return ivizConn.Excute(strSql, sqler);
        }
        //가상서열 FEM1 스키드 매칭
        public static bool PPC_VIRTUAL_INPUT_TRAN_FEM1(string WC_ID, string TR_ID, string BARCODE)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_VIRTUAL_INPUT_TRAN_FEM1";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :TR_ID  "; sqler.AddString(":TR_ID", TR_ID);
            SQL += "   :BARCODE  "; sqler.AddString(":BARCODE", BARCODE); ;
            strSql.Append(SQL);

            return ivizConn.Excute(strSql, sqler);
        }
        // 스키드 매칭
        public static bool PPC_INPUT_TRAN_FEM2(string WC_ID, string TR_ID, string BARCODE)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_INPUT_TRAN_FEM2";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :TR_ID  "; sqler.AddString(":TR_ID", TR_ID);
            SQL += "   :BARCODE  "; sqler.AddString(":BARCODE", BARCODE); ;
            strSql.Append(SQL);

            return ivizConn.Excute(strSql, sqler);
        }
        //가상서열 FEM2 스키드 매칭
        public static bool PPC_VIRTUAL_INPUT_TRAN_FEM2(string WC_ID, string TR_ID, string BARCODE)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_VIRTUAL_INPUT_TRAN_FEM2";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :TR_ID  "; sqler.AddString(":TR_ID", TR_ID);
            SQL += "   :BARCODE  "; sqler.AddString(":BARCODE", BARCODE); ;
            strSql.Append(SQL);

            return ivizConn.Excute(strSql, sqler);
        }
        public static bool PPC_INPUT_CAR(string WC_ID, string ROUTE_NO, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_INPUT_CAR";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :ROUTE_NO  "; sqler.AddString(":ROUTE_NO", ROUTE_NO);        
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }
        // 스키드 RESET
        public static bool PPC_TRAN_CANCLE(string WC_ID, string TAG_ID, string BARCODE)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_TRAN_CANCLE";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :TAG_ID  "; sqler.AddString(":TAG_ID", TAG_ID);
            SQL += "   :BARCODE  "; sqler.AddString(":BARCODE", BARCODE); ;
            strSql.Append(SQL);

            return ivizConn.Excute(strSql, sqler);
        }
        //가상서열 스키드 RESET
        public static bool PPC_VIRTUAL_TRAN_CANCLE(string WC_ID, string TAG_ID, string BARCODE)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_VIRTUAL_TRAN_CANCLE";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :TAG_ID  "; sqler.AddString(":TAG_ID", TAG_ID);
            SQL += "   :BARCODE  "; sqler.AddString(":BARCODE", BARCODE); ;
            strSql.Append(SQL);

            return ivizConn.Excute(strSql, sqler);
        }
        // 스키드 NG
        public static bool PPC_TRAN_NG(string WC_ID, string ROUTE_NO)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_TRAN_NG";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :ROUTE_NO  "; sqler.AddString(":ROUTE_NO", ROUTE_NO);
            strSql.Append(SQL);

            return ivizConn.Excute(strSql, sqler);
        }
        public static bool PPC_PLC_OKNG_END_STATE(string WC_ID, string ROUTE_NO, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_PLC_OKNG_END_STATE";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :ROUTE_NO  "; sqler.AddString(":ROUTE_NO", ROUTE_NO);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }
        //라인별 대기 수량 조회
        public static bool PPC_ASSY_WAIT_CNT(string WC_ID, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_ASSY_WAIT_CNT";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }
        
        //이벤트 메세지
        public static bool PPC_EVENT_MESSAGE(string WC_ID, string ROUTE_NO, string BODY_NO, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_EVENT_MESSAGE_LOAD";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :ROUTE_NO  "; sqler.AddString(":ROUTE_NO", ROUTE_NO);
            SQL += "   :BODY_NO  "; sqler.AddString(":BODY_NO", BODY_NO);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }
        //가상서열 이벤트 메세지
        public static bool PPC_VIRTUAL_EVENT_MESSAGE(string WC_ID, string ROUTE_NO, string BODY_NO, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_VIRTUAL_EVENT_MESSAGE_LOAD";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :ROUTE_NO  "; sqler.AddString(":ROUTE_NO", ROUTE_NO);
            SQL += "   :BODY_NO  "; sqler.AddString(":BODY_NO", BODY_NO);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }
        public static bool PPC_IMAGE_DOWN_LOAD(string WC_ID, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_IMAGE_DOWN";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }


        //20140917 유민호 추가
        public static bool PPC_DAILY_TIME_FLAG_LOAD(string WC_ID, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_DAILY_INSP_SET_LOAD";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }

        // 2014 02 06 유민호 추가부분
        // 검사구 이미지 체결 위치 정보 조회
        public static bool PPC_INSP_IMAGE_POSITION(string WC_ID, string CAR_CODE, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_INSP_IMAGE_POSITION_LOAD";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :CAR_CODE  "; sqler.AddString(":CAR_CODE", CAR_CODE);

            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }

        // 2014 02 06 유민호 추가부분
        // 검사구 이미지 체결 위치 결과 저장
        public static bool PPC_INSP_RESULT_SAVE(string WC_ID, string CAR_CODE, string BODY_NO, DataSet ds, string[] Result_Data)
        {
            bool result = false;
            for (int i = 0; i < 16; i++)
            {
                string SQL = "";
                StringBuilder strSql = new StringBuilder();
                ParameterMember sqler = new ParameterMember();

                SQL += "SP_PPC_INSP_IMAGE_POSITION_SAVE";
                SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
                SQL += "   :CAR_CODE  "; sqler.AddString(":CAR_CODE", CAR_CODE);
                SQL += "   :BODY_NO  "; sqler.AddString(":BODY_NO", BODY_NO);
                SQL += "   :WORK_SEQ  "; sqler.AddString(":WORK_SEQ", (i + 1).ToString());
                SQL += "   :POSX  "; sqler.AddString(":POSX", (i + 1).ToString());
                SQL += "   :POSY  "; sqler.AddString(":POSY", (i + 1).ToString());
                SQL += "   :RESULT_DATA  "; sqler.AddString(":RESULT_DATA", Result_Data[i]);
                strSql.Append(SQL);

                result = ivizConn.Excute(strSql, sqler);

            }
            return result;

        }

        // 2014 09 15 유민호
        // 작업표준서용 차량코드
        public static bool PPC_WorkBoard_CarCode(string WC_ID, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_LOAD_WC_CAR";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }

        // 2014 10 08 유민호 추가
        // 일일점검 스펙 체크
        public static bool PPC_Daily_Spect_Check(string WC_ID,string T_TYPE, ref DataSet ds)
        {
            string SQL = "";
            StringBuilder strSql = new StringBuilder();
            ParameterMember sqler = new ParameterMember();

            SQL += "SP_PPC_LOAD_daily_insp_SPEC";
            SQL += "   :WC_ID  "; sqler.AddString(":WC_ID", WC_ID);
            SQL += "   :TOOL_TYPE  "; sqler.AddString(":TOOL_TYPE", T_TYPE);
            strSql.Append(SQL);

            return ivizConn.ExcuteDS(strSql, sqler, ref ds);
        }

    }
}
