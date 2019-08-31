using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocalNetworkHardware.DataLayer.Context;
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
                    return GetAnswer();
                case "/getshort":
                    return HardwareInformationHelper.GetShortHardwareInfoToSend();
                default:
                    return "Invalid Request";
            }
        }

        public static string GetAnswer()
        {
            string answer = "";
            string activities = "";

            answer += HardwareInformationHelper.GetHardwareInfoToSend();

            using (UnitOfWork uow = new UnitOfWork())
            {
                ManageSystemInformations systemInformations =
                    new ManageSystemInformations(uow, false);
                activities = systemInformations.GetSystemActvities();
            }

            answer += activities;

            return answer;
        }
    }
}
