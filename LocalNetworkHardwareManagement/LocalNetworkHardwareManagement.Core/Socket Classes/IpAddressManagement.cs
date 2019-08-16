using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LocalNetworkHardwareManagement.Core.Socket_Classes
{
    public class IpAddressManagement
    {
        private static List<string> _hostIpList;
        private static string _myIP;
        public IpAddressManagement()
        {
            _hostIpList = new List<string>();
            _myIP = "";
        }

        public async Task<string[]> StartGettingHosts(string ipAddress)
        {
            return await Task.Run(() =>
            {
                _myIP = ipAddress;
                string baseIp = GetBaseIp(ipAddress);
                //if (baseIp.ToLower().Equals("error")) continue;
                GetHosts(baseIp);


                return _hostIpList.ToArray();
            });
        }

        public static void GetHosts(string baseIp)
        {
            string ipBase = baseIp;
            for (int i = 1; i < 255; i++)
            {
                string ip = ipBase + i.ToString();

                Ping p = new Ping();
                p.PingCompleted += new PingCompletedEventHandler(p_PingCompleted);
                p.SendAsync(ip, 100, ip);
            }
        }

        public static IEnumerable<string> GetLocalIPv4Addresses()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    yield return ip.ToString();
                }
            }
        }

        public static string GetBaseIp(string ipv4)
        {
            string[] ipArray = ipv4.Split('.');
            if (ipArray.Length != 4)
                return "Error";
            string baseIp = ipArray[0] + "." + ipArray[1] + "." + ipArray[2] + ".";
            return baseIp;
        }

        static void p_PingCompleted(object sender, PingCompletedEventArgs e)
        {
            string ip = (string)e.UserState;
            if (e.Reply != null && e.Reply.Status == IPStatus.Success)
            {
                if (_myIP != ip)
                    _hostIpList.Add(ip);
            }
        }
    }
}
