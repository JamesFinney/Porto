using System.IO.Compression;
using System.Text;

namespace Porto.System.IO
{
    public interface IPZipFile
    {
        void CreateFromDirectory(string sourceDirectoryName, string destinationArchiveFileName);
        void CreateFromDirectory(string sourceDirectoryName, string destinationArchiveFileName, CompressionLevel compressionLevel, bool includeBaseDirectory);
        void CreateFromDirectory(string sourceDirectoryName, string destinationArchiveFileName, CompressionLevel compressionLevel, bool includeBaseDirectory, Encoding entryNameEncoding);
        void ExtractToDirectory(string archivePath, string outputPath, bool overwriteFiles);
        ZipArchive Open(string archiveFileName, ZipArchiveMode mode);
        ZipArchive Open(string archiveFileName, ZipArchiveMode mode, Encoding entryNameEncoding);
        ZipArchive OpenRead(string archiveFileName);
    }
}