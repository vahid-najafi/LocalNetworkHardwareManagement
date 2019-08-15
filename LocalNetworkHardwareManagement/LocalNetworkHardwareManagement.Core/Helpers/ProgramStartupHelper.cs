using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace LocalNetworkHardwareManagement.Core.Helpers
{
    public class ProgramStartupHelper
    {
        public static void CheckApplicationStartupRegistry(string appExecutingPath)
        {
            try
            {
                RegistryKey rkApp = Registry.CurrentUser
                    .OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", false);

                if (rkApp.GetValue("LNHM") == null)
                {
                    rkApp.SetValue("LNHM", appExecutingPath);
                }
            }
            catch { }
        }

    }
}
