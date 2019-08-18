using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using MOBISDAS.Forms;
using System.IO.Ports;

namespace MOBISDAS.Global
{
    public sealed class EquipInfo
    {
        public static string WORKCENTER = "";
        public static string ROUTE_NO = "";
        public static string ROUTE_GB = "";
        //--------------서브라인 조정 변수------------------------------     
        public static string R_Rtn = "";   //서브라인 조정버튼을 누르면 WORK폼에서 닫기와 조정 버튼의 구분을 주기 위해서. R=조정
        public static string R_TR_ID = "";
        public static string T_ORDER_DATE = "";
        public static string R_CMT = "";
        public static string R_BODY_NO = "";
        public static string R_ASSY_SEQ = "";
        public static string R_PART_ID = "";
        public static string R_ALC = "";
        public static string R_CAR_CODE = "";
        //-------------------------------------------------------------
        public static string TR_ID = "";
        public static string W_TR_ID = "";
        public static string ORDER_DATE = "";
        public static string CMT = "";
        public static string BODY_NO = "";
        //유민호 추가
        public static string H_CAR_CODE = "";
        public static string H_ROUTE_NO = "";
        public static bool Msg_Off = false;
        public static bool SubFalg = true;
        public static bool BoardFlag = false;
        public static bool Auto_Flag = true;   // 작업표준서 자동 수동 설정
        //
        public static string ASSY_SEQ = "";
        public static string PART_ID = "";
        public static string ALC = "";
        public static string CAR_CODE = "";
        public static string TAG_ID = "";

        public static string BARCODE = "";
        public static string EMP = "";

        public static string Rtn = "";
        public static string Tool_Cancle_Rtn = "";

        public static int gdCarrentCnt = 0;
        public static string WAIT_CNT = "";
        public static int Message_Timer_Interval = 0;

        public static string _Frm= null;  // 현재 폼
        public static string _BFrm = null;  // 다음폼
        public static bool Virtual = false; 

        //LOG 파일 생성
        public static DateTime Date_Time = DateTime.Now;        
        public static Filehandle fhLog = new Filehandle("./LOG/" +DateTime.Now.Year + "_" + DateTime.Now.Month + "/LOG" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + ".TXT");
        public static Filehandle fh_Err_Log = new Filehandle("./Err_LOG/" + DateTime.Now.Year + "_" + DateTime.Now.Month + "/Err_LOG" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + ".TXT");

        public static string Test = "Git";

        public static void Initialization()
        {
            TR_ID = "";
            ORDER_DATE = "";
            CMT = "";
            BODY_NO = "";
            ASSY_SEQ = "";
            PART_ID = "";
            ALC = "";
            CAR_CODE = "";
            TAG_ID = "";
            BARCODE = "";
            //서브라인 서열정보 조정 정보
            R_Rtn = "";   
            R_TR_ID = "";
            T_ORDER_DATE = "";
            R_CMT = "";
            R_BODY_NO = "";
            R_ASSY_SEQ = "";
            R_PART_ID = "";
            R_ALC = "";
            R_CAR_CODE = "";
            Tool_Cancle_Rtn = "";
        }
    }
}