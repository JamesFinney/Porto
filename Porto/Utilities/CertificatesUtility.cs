using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security;
using System.IO;
using System.Text.RegularExpressions;

namespace Porto.Utilities
{
    /// <summary>
    /// Various certificate-related utility methods.
    /// </summary>
    public class CertificatesUtility : ICertificatesUtility
    {
        /// <inheritdoc/>
        public X509Certificate2 LoadBySubject(string subjectName)
        {
            using X509Store store = new X509Store(StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly);
            var matchingCerts = store.Certificates.Find(X509FindType.FindBySubjectName, subjectName, true);
            if (matchingCerts.Count == 0)
                return null;

            return matchingCerts[0];
        }

        /// <inheritdoc/>
        public X509Certificate2 LoadBySubjectRegex(string pattern)
        {
            using X509Store store = new X509Store(StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly);

            var regex = new Regex(pattern);

            var matchingCerts = store.Certificates.Where(c =>
            {
                var match = regex.Match(c.SubjectName.Name);
                if (match.Success)
                    return true;

                return false;
            });

            if (matchingCerts.Count() == 0)
                return null;

            return matchingCerts.ElementAt(0);
        }

        /// <inheritdoc/>
        public X509Certificate2 LoadFromFile(string path, string password)
        {
            if (!File.Exists(path)) return null;

            var secureString = new SecureString();
            foreach (var c in password)
                secureString.AppendChar(c);

            return new X509Certificate2(File.ReadAllBytes(path), secureString);
        }
    }
}
