using System.Collections.Generic;
using System.Net;

namespace Porto.Utlities
{
    public interface INetworkUtility
    {
        /// <summary>
        /// Gets the first available IPv4 address of the system.
        /// </summary>
        /// <returns>The IP address of the system.</returns>
        /// <exception cref="Exception">Thrown if there are no IPv4 compatible network adapters.</exception>
        string GetIpAddress();

        /// <summary>
        /// Gets all IP addresses associated with the current host.
        /// </summary>
        /// <returns>A list of all IP addresses including local host.</returns>
        List<IPAddress> GetIpAddresses();
    }
}