using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Dabom.TagAdapter;
using System.Diagnostics;

namespace MOBISDAS
{
    static class Program
    {
        public static TagInfoAdater<TagServerMarshalByRefObject> aptClient;

        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]              
        static void Main()
        {
            Process[] mProcess = Process.GetProcessesByName("MOBISDAS");

            if (mProcess.Length < 2)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new mdiMain());
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
