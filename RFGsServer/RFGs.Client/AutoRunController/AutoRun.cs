using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFGs.Client.AutoRunController
{
    internal static class AutoRun
    {
        internal static void SetAutoStart(IAutoRun autoStart)
        {
            autoStart.Setup();
        }
    }
}
