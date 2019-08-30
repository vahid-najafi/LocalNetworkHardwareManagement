using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocalNetworkHardwareManagement.Core.Buisness;
using LocalNetworkHardwareManagement.Core.Helpers;

namespace LocalNetworkHardwareManagement.Core.Socket_Classes
{
    public class RequestManager
    {
        public static string ReadRequest(string request)
        {
            switch (request)
            {
                case "/get":
                    return HardwareInformationHelper.GetHardwareInfoToSend();
                case "/getshort":
                    return HardwareInformationHelper.GetShortHardwareInfoToSend();
                default:
                    return "Invalid Request";
            }
        }
    }
}
