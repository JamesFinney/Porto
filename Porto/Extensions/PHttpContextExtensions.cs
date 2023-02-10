using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace Porto.Extensions
{
    public static class PHttpContextExtensions
    {
        public static string GetDns(this HttpContext context)
        {
            var entry = Dns.GetHostEntry(context.Connection.RemoteIpAddress);
            if (entry != null)
                return entry.HostName;
            return null;
        }

        public static string GetIpAddress(this HttpContext context)
        {
            return context.Connection.RemoteIpAddress.ToString();
        }

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
