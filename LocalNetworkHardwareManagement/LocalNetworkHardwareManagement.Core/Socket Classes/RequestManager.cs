using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalNetworkHardwareManagement.Core.Socket_Classes
{
    public class RequestManager
    {
        public static string ReadRequest(string request)
        {
            switch (request)
            {
                case "/get":
                    return "Should return hardware informations";
                default:
                    return "Invalid Request";
            }
        }
    }
}
