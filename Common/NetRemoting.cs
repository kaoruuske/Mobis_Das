using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dabom.TagAdapter;

namespace MOBISDAS
{
        
    public class NetRemoting
    {
        public static Dictionary<string, WorkStatus> CommStatus = new Dictionary<string, WorkStatus>();

        public static void TagServerConnect(string applicationName, string ip, int port, string serverUrl, string[] workStatus)
        {
            CommStatus = new Dictionary<string, WorkStatus>();
            foreach (string commid in workStatus)
            {
                Add(commid);
            }

            TagInfoAlias alias = new TagInfoAlias { ApplicationName = applicationName, Ip = ip, Port = port, ServerUrl = serverUrl, WorkStatus =workStatus };
            ////Program.aptClient = null;

            TagServerMarshalByRefObject obj = new TagServerMarshalByRefObject();

            Program.aptClient = new TagInfoAdater<TagServerMarshalByRefObject>(alias);
            //Program.aptClient = new TagInfoAdater<TagServerMarshalByRefObject>(alias);
            Program.aptClient.RecieveServerActive();
            Program.aptClient.Connect(); 

        }

        public static void Add(string Commid)
        {
            if (!CommStatus.ContainsKey (Commid)) CommStatus.Add(Commid, new WorkStatus(Commid, ""));
        }

        public static int TagSet(string TagId, string TagValue)
        {
             if (Program.aptClient != null && Program.aptClient.State)
             {
                Dabom.TagAdapter.Item.WriteTagItem datup = new Dabom.TagAdapter.Item.WriteTagItem();
                datup.TagID = TagId;
                datup.WriteValue = TagValue;
                return Program.aptClient.Recieve((RemoteEventArgs)datup);
             }

            return 0;
        }
            
        public static bool State()
        {
            if (Program.aptClient != null)
            {
                return Program.aptClient.State;
            }
            return false;

        }

        public static string TagGet(string TagId)
        {
            string retvalue = null;
            if (Program.aptClient != null && Program.aptClient.State)
            {
                retvalue= Program.aptClient.GetValue(TagId);
            }
            return retvalue;
        }

        public static string Comm_IDGet(string Comm_id)
        {
            return TagGet("STATUS_" + Comm_id);
            
        }

        public static void Comm_IDSet(Dabom.TagAdapter.Item.WorkDataUp Setdata)
        {
            if (Program.aptClient != null && Program.aptClient.State)
            {
                Program.aptClient.Recieve((RemoteEventArgs)Setdata);
            }
        }

        public static void Comm_IDSet_Etool(Dabom.TagAdapter.Item.WorkDataUp Setdata)
        {
            if (Program.aptClient != null && Program.aptClient.State)
            {
                Program.aptClient.Recieve((RemoteEventArgs)Setdata);
            }
        }

        public static int Recieve(object obj, RemoteEventArgs arg)
        {
            try
            {
                if (arg.GetType().Equals(typeof(Dabom.TagAdapter.Item.WorkStatus)))
                {
                    WorkStatus((Dabom.TagAdapter.Item.WorkStatus)arg);

                } if (arg.GetType().Equals(typeof(Dabom.TagAdapter.Item.WorkStatusDic)))
                {
                    Dabom.TagAdapter.Item.WorkStatusDic cd = (Dabom.TagAdapter.Item.WorkStatusDic)arg;

                    for (int i=0; i < cd.Comm_id.GetLength(0); i++)
                    {

                        if (CommStatus.ContainsKey(cd.Comm_id [i]))
                        {
                            if ( !CommStatus[cd.Comm_id[i]].VariablesStr.Equals(cd.WorkStatus[i]))
                                CommStatus[cd.Comm_id[i]].VariablesStr                             = cd.WorkStatus[i];
                        }
                    }
                   

                }
            }
            catch (Exception ex) { }
            return 1;
        }

        private static void WorkStatus(Dabom.TagAdapter.Item.WorkStatus arg)
        {
            if (CommStatus.ContainsKey(arg.CommId))
            {
                CommStatus[arg.CommId].VariablesStr = arg.VariablesStr;
            }
            

        }

    }
}
