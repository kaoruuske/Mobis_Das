using System;
using System.Collections.Generic;
using System.Text;
using Dabom.TagAdapter;
using Dabom.TagAdapter.Item;
using Dabom.TagAdapter.SubScription;
using System.Threading;

namespace MOBISDAS
{
    public class TagServerMarshalByRefObject:MarshalByRefObject ,Dabom.TagAdapter.ITagServer , IDisposable 

    {


        #region ThreadBuff
        public static  Dabom.TagAdapter.Generic.SafeQueue <RemoteEventArgs> RecieveQ = new Dabom.TagAdapter.Generic.SafeQueue <RemoteEventArgs>();
        ManualResetEvent stopEvent = new ManualResetEvent(false);
        Thread thread = null;
        void RecieveQThreadStart()
        {
            lock (this)
            {
                if (thread != null && thread.IsAlive)
                {
                    thread.Interrupt();
                    thread.Abort();
                }

                thread = new Thread(new ThreadStart(ThreadProc));
                thread.IsBackground = true;
                thread.Start();

            }
        }

        void ThreadProc()
        {
            //server url
            stopEvent.Reset();
            while (!stopEvent.WaitOne(0, true))
            {
                try
                {
                    if (LoadDisplay())
                    {
                        
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(2);
                    }

                }
                catch (ThreadInterruptedException e)
                {
                    return;
                }
                catch (Exception e)
                {
                    /*
                     This exception is most likely because the remote server 
                     is down. So, we just notify the user by printing this exception to the console and
                     try again.
                    */
                }

                finally
                {
                    //    System.Threading.Thread.Sleep(1); 
                }

            }

        }

        private bool LoadDisplay()
        {
            RemoteEventArgs arg = null;
            if (RecieveQ.Count > 0)
            {
                lock (RecieveQ)
                {
                    while (RecieveQ.Count > 0)
                    {
                        arg = RecieveQ.Dequeue();
                        NetRemoting .Recieve(this, arg);
                        //Program.form1.
                        //Console.WriteLine(arg);
                    }
               }
               return false ;
            }
            else
            {
                return false;
            }
        }

        
        #endregion

        public TagServerMarshalByRefObject()
        {
            ////Console.WriteLine(string.Format("##CommTagAdaptor.CurrentThread:{0}", System.Threading .Thread.CurrentThread.ManagedThreadId));
            RecieveQThreadStart();
        }
        ~TagServerMarshalByRefObject()
        {
            if (thread != null && thread.IsAlive)
            {
                thread.Interrupt();
                thread.Abort();
            }
            stopEvent.Set();
        }

        #region ITagServer 멤버


        public event EventHandler<RemoteEventArgs> eTagRecieve;


        public System.Collections.Hashtable GetTagGroup()
        {
            throw new NotImplementedException();
        }

        public void AddSubscription(Type type, TagInfoAlias url)
        {
            //throw new NotImplementedException();
        }

        public void AddSubscription(Type type, string methodName, TagInfoAlias url)
        {
            //throw new NotImplementedException();
        }

        public void RemoveSubscription(Type type, TagInfoAlias url)
        {
            //throw new NotImplementedException();
        }

        public void RemoveSubscription(Type type, string methodName, TagInfoAlias url)
        {
            //throw new NotImplementedException();
        }

        public int Sink(RemoteEventArgs arg)
        {
            return 1;

            //throw new NotImplementedException();
        }

        public int Recieve(RemoteEventArgs arg)
        {
            //Dabom .CommManager .View.CommPresenter .CommService .
//            if (eTagRecieve != null) eTagRecieve(this, arg);
            if (arg.GetType().Equals(typeof(Dabom.TagAdapter.Item.TagItem)))
            {
                ((Dabom.TagAdapter.Item.TagItem)arg).RecieveTimeSet = true;
            }
            lock (RecieveQ)
            {
                RecieveQ.Enqueue(arg);
                //Program.form1.Recieve(this, arg);
            }
            return 1;
        }


        public IDictionary<string, TagItem> GetTagBag
        {
            get
            {
                return null;
            }
            set
            {
                
            }
        }

        public IDictionary<string, Dabom.TagAdapter.SubScription.EventSubscription> SubscriptionBag
        {
            get
            {
                return null;
            }
            set
            {
                
            }
        }

        public int Echo(RemoteEventArgs arg)
        {
            EchoResponse();
            return 1;
        }

       
       
        
        #endregion

        public int EchoResponse()
        {
            
            return 1;
        }



        #region ITagServer 멤버


        public Dabom.TagAdapter.Logger.ILogger Logger
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region ITagServer 멤버


        public string GetValue(string ptag)
        {
            return "";
        }



        public int SetValue(string ptag, string pValue)
        {
            return 0;
        }


        public Dabom.TagAdapter.SubScription.EventSubscription[] SubscriptionBagArry
        {
            get
            {
                return null;
            }
        }
        #endregion

        #region IDisposable 멤버

        public void Dispose()
        {
            
        }

        #endregion
    }
}
