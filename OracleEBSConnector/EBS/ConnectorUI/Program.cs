﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace ConnectorUI
{
    static class Program
    {

    private static Mutex mutex = null;
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
        static void Main()
        {
          const string appName = "Oracle EBS Connector";
          bool createdNew;

          mutex = new Mutex(true, appName, out createdNew);

          if (!createdNew)
          {
            //app is already running! Exiting the application  
            return;
          }


                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmMain());
     


        }
  
  }
}
