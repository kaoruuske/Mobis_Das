using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace MOBISDAS
{
    public delegate void WorkStatusChnanged(string pCommId, string EvnetParams);

    public class WorkStatusList
    {
        public static Dictionary<string, WorkStatus> WS = new Dictionary<string, WorkStatus>();

        public event WorkStatusChnanged OnWorkStatusChanged;

        public void eHandle(string pCommId,string EvnetParams)
        {
            if (OnWorkStatusChanged != null)
                OnWorkStatusChanged(pCommId, EvnetParams);

        }

        public WorkStatusList()
        {
            
        }

        public void Set(string pCommId,string pVariablesStr)
        {
            if (!WS.ContainsKey (pCommId))
            {
                WorkStatus item = new WorkStatus(pCommId, pVariablesStr);
                item.OnWorkStatusChanged +=  new WorkStatusChnanged(item_OnWorkStatusChanged);
                WS.Add(pCommId, item);
            }else
            {
                WS[pCommId].VariablesStr = pVariablesStr;
            }
        }

        void item_OnWorkStatusChanged(string pCommId,string EvnetParams)
        {
            eHandle(pCommId, EvnetParams);
        }

        public Dictionary<string, Dabom.TagAdapter.Item.VariableItem> Get(string pCommId)
        {
            if (WS.ContainsKey(pCommId))
            {
                return WS[pCommId].VariableItems;        
            }
            else
            {
                return null;
            }
        }
        public string  GetVariableid(string pCommId, string pVarID)
        {
            if (WS.ContainsKey(pCommId) && WS[pCommId].VariableItems.ContainsKey(pVarID))
            {
                return WS[pCommId].VariableItems[pVarID].Value.ToString ();
            }
            else
            {
                return null;
            }
        }
        public IEnumerable<string> CommIdList()
        {
            return WS.Keys;
        }

    }

    public class WorkStatus
    {
        public event WorkStatusChnanged OnWorkStatusChanged;

        public WorkStatus(string pCommId,string pVariablesStr)
        {
            mCommId = pCommId;
            VariablesStr = pVariablesStr;
        }
        public void eHandle(string EvnetParams)
        {
            if (OnWorkStatusChanged != null)
                OnWorkStatusChanged(mCommId, EvnetParams);
        }

        string mVariablesStr;
        string _VariablesStr;
        string mCommId;
        Dictionary<string, Dabom.TagAdapter.Item.VariableItem> mVariableItems;

        public string CommId        {            get { return mCommId; }            set { mCommId = value; }        }
        public Dictionary<string, Dabom.TagAdapter.Item.VariableItem> VariableItems        {            get { return mVariableItems; }            set { mVariableItems = value; }        }

       

        public string VariablesStr
        {
            get { return mVariablesStr; }
            set { 
                mVariablesStr = value;
                ThreadPool.QueueUserWorkItem(new WaitCallback(SetDictionary ));
            }
        }

        void SetDictionary(object  stateInfo)
        {
            string  changeid = "";

            Dictionary<string, Dabom.TagAdapter.Item.VariableItem> _mVariableItems = (new Dabom.TagAdapter.StateParse(mVariablesStr)).ToVariableItems();

            if (mVariableItems != null)
            {
                foreach (KeyValuePair<string, Dabom.TagAdapter.Item.VariableItem> item in _mVariableItems)
                {
                    if (mVariableItems.ContainsKey(item.Value.VarID) && !mVariableItems[item.Value.VarID].Value .Equals(item.Value.Value))
                    {
                        changeid += (changeid.Length == 0 ? "" : ",") + item.Value.VarID;
                    }

                }
            }
            mVariableItems = _mVariableItems;
            //mVariablesStr

            eHandle(changeid);
        }
        
    }
}
