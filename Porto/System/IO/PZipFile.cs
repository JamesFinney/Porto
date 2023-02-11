using System.IO.Compression;
using System.Text;

namespace Porto.System.IO
{
    public class PZipFile : IPZipFile
    {
        public ZipArchive OpenRead(string archiveFileName)
        {
            return ZipFile.OpenRead(archiveFileName);
        }
        public ZipArchive Open(string archiveFileName, ZipArchiveMode mode)
        {
            return ZipFile.Open(archiveFileName, mode);
        }
        public ZipArchive Open(string archiveFileName, ZipArchiveMode mode, Encoding? entryNameEncoding)
        {
            return ZipFile.Open(archiveFileName + entryNameEncoding, mode);
        }
        public void CreateFromDirectory(string sourceDirectoryName, string destinationArchiveFileName)
        {
            ZipFile.CreateFromDirectory(sourceDirectoryName, destinationArchiveFileName);
        }
        public void CreateFromDirectory(string sourceDirectoryName, string destinationArchiveFileName, CompressionLevel compressionLevel, bool includeBaseDirectory)
        {
            ZipFile.CreateFromDirectory(sourceDirectoryName, destinationArchiveFileName, compressionLevel, includeBaseDirectory);
        }
        public void CreateFromDirectory(string sourceDirectoryName, string destinationArchiveFileName,
                                               CompressionLevel compressionLevel, bool includeBaseDirectory, Encoding? entryNameEncoding)
        {
            ZipFile.CreateFromDirectory(sourceDirectoryName, destinationArchiveFileName, compressionLevel, includeBaseDirectory, entryNameEncoding);
        }


        /* New methods
         * */
        public void ExtractToDirectory(string archivePath, string outputPath, bool overwriteFiles)
        {
            ZipFile.ExtractToDirectory(archivePath, outputPath, overwriteFiles);
        }
    }
}
