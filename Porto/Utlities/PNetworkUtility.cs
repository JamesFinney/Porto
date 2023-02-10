using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;

namespace Porto.Utlities
{
    public class PNetworkUtility
    {
        public static string GetIpAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system");
        }

        /// <summary>
        /// Gets all IP addresses associated with the current host.
        /// </summary>
        /// <returns>A list of all IP addresses including local host.</returns>
        public static List<IPAddress> GetIpAddresses()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            var ipAddresses = new List<IPAddress>();

            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    ipAddresses.Add(ip);
                }
            }

            if (ipAddresses.All(x => x.ToString() != "127.0.0.1"))
            {
                ipAddresses.Add(IPAddress.Parse("127.0.0.1"));
            }

            return ipAddresses;
        }
    }
}
