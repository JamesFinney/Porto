using System.Security.Cryptography.X509Certificates;

namespace Porto.Utilities
{
    public interface ICertificatesUtility
    {
        /// <summary>
        /// Loads a certificate from the LocalMachine that matches the provided subject name.
        /// </summary>
        /// <param name="subjectName">The subject name of the certificate.</param>
        /// <returns>The X509Certifcate from the store. Returns null if the certificate could not be found.</returns>
        X509Certificate2 LoadBySubject(string subjectName);

        /// <summary>
        /// Loads a certificate from the LocalMachine who's Subject Name matches the provided pattern.
        /// </summary>
        /// <param name="pattern">The subject name pattern.</param>
        /// <returns>The X509Certifcate from the store. Returns null if the certificate could not be found.</returns>
        X509Certificate2 LoadBySubjectRegex(string pattern);

        /// <summary>
        /// Loads a certificate from a PFX file.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="password">The password for the certificate file.</param>
        /// <returns>The loaded X509Certifcate from file. Returns null if the certificate file could not be found.</returns>
        X509Certificate2 LoadFromFile(string path, string password);
    }
}