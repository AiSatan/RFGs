
using RFGs.Client.AutoRunController;
using System;
using System.Linq;
using System.Reflection;

namespace RFGs.Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AutoRun.SetAutoStart(new AutoStartTaskScheduler());
        }
    }
}
