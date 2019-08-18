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
    #region [Class] ParameterMember : Parameter Set
    public class ParameterMember
    {
        private ArrayList param;
        //private IsValidate  isVlid = new IsValidate();
        #region [Class] ParameterValue : ADO의 Parameter의 내용을 보관할 틀
        private class ParameterValue
        {
          
            public object Type;
            public object Name;
            public object Value;

            //public object direction; // in out 구분

            public ParameterValue(object objType, object objName, object objValue)
            {
                this.Type = objType;
                this.Name = objName;
                this.Value = objValue;

              //  this.direction = new object();
            }

            //public ParameterValue(object objType, object objName, object objValue)
            //{
            //    this.Type = objType;
            //    this.Name = objName;
            //    this.Value = objValue;

            //  //  this.direction = objDirection;
            //}
        }
        #endregion

        #region 생성자
        public ParameterMember()
        {
            param = new ArrayList();
        }
        #endregion

        #region [Method] Count : 등록된 Parameter의 개수를 리턴한다.
        public int Count
        {
            get { return param.Count; }
        }
        #endregion

        #region [Method] Add : Parameter 등록
        /// <summary>
        /// ex)objType SqlDbType.DateTime
        /// </summary>
        /// <param name="objType"></param>
        /// <param name="objName"></param>
        /// <param name="objValue"></param>
        public void Add(object objType, object objName, object objValue)
        {
            this.param.Add(new ParameterValue(objType, objName, objValue));
        }
        #endregion
        public void Add( object objName, object objValue)
        {
            this.param.Add(new ParameterValue(SqlDbType.VarChar, objName, objValue));
        }

        public void AddString( object objName, object objValue)
        {
            this.param.Add(new ParameterValue(SqlDbType.VarChar, objName, objValue));
        }

        //public void AddString(object objName, object objValue)
        //{
        //    this.param.Add(new ParameterValue(SqlDbType.VarChar, objName, objValue));
        //}

        //public void AddNumber(object objName, object objValue)
        //{
        //    this.param.Add(new ParameterValue(SqlDbType.VarChar, objName, isVlid.IsDoubleFormat ( objValue)));
        //}
        public void AddDtTime(object objName, object objValue)
        {
            this.param.Add(new ParameterValue(SqlDbType.DateTime, objName, objValue));
        }
        #endregion

        #region [Method] Clear : Parameter Clear
        public void Clear()
        {
            this.param.Clear();
        }
        #endregion

        #region [Method] GetType : 해당 Index의 SqlType 반환
        public object GetType(int index)
        {
            ParameterValue pv = (ParameterValue)this.param[index];
            return pv.Type;
        }
        #endregion

        #region [Method] GetName : 해당 Index의 Parameter Name 반환
        public string GetName(int index)
        {
            ParameterValue pv = (ParameterValue)this.param[index];
            return pv.Name.ToString();
        }
        #endregion

        #region [Method] GetValue : 해당 Index/Name의 Parameter Value 반환
        public object GetValue(int index)
        {
            ParameterValue pv = (ParameterValue)this.param[index];
            return pv.Value;
        }

        public object GetValue(string name)
        {
            for (int i = 0; i < param.Count; i++)
                if (((ParameterValue)this.param[i]).Name.ToString() == name)
                    return ((ParameterValue)this.param[i]).Value;
            return null;
        }

       
        #endregion

        #region [Method] SetValue : 해당 Index의 Parameter Value 설정
        public void SetValue(int index, object value)
        {
            ParameterValue pv = (ParameterValue)this.param[index];
            pv.Value = value;
        }
        #endregion
    }
    
}
