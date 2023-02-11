using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace Porto.Extensions
{
    public static class HttpContextExtensions
    {
        /// <summary>
        /// Get the DNS entry from the remote client.
        /// </summary>
        /// <param name="context">The HttpContext.</param>
        /// <returns>The DNS name. Return null if there is no DNS name for the client.</returns>
        public static string GetDns(this HttpContext context)
        {
            var entry = Dns.GetHostEntry(context.Connection.RemoteIpAddress);
            if (entry != null)
                return entry.HostName;
            return null;
        }

        /// <summary>
        /// Gets the remote IP address of the client from the HttpContext.
        /// </summary>
        /// <param name="context">The HttpContext.</param>
        /// <returns>The IP address string of the client.</returns>
        public static string GetIpAddress(this HttpContext context)
        {
            return context.Connection.RemoteIpAddress.ToString();
        }

        /// <summary>
        /// Validates that the certificate of the caller is in the provided list of client certs. Commarsion is done against the Common Name.
        /// </summary>
        /// <param name="context">The HttpContext.</param>
        /// <param name="allowedClientCerts">A list of allowed client certificates.</param>
        /// <returns>Returns True if the client is allowed; False otherwise.</returns>
        public static bool IsValidClientCert(this HttpContext context, List<string> allowedClientCerts)
        {
            var cert = context.Connection.ClientCertificate;
            if (cert == null) return false;

            if (allowedClientCerts == null || !allowedClientCerts.Any()) return false;

            var commonName = cert.GetNameInfo(X509NameType.SimpleName, false);
            if (!allowedClientCerts.Select(x => x.Trim()).Contains(commonName.Trim())) return false;

            return true;
        }
    }
}
