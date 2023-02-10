using System.IO.Compression;

namespace Porto.System.IO
{
    public interface IPZip
    {
        void CreateZipFromDirectory(string sourceDir, string outputPath);
        void ExtractToDirectory(string archivePath, string outputPath, bool overwriteFiles);
    }

    public class PZip : IPZip
    {
        public void CreateZipFromDirectory(string sourceDir, string outputPath)
        {
            ZipFile.CreateFromDirectory(sourceDir, outputPath);
        }

        public void ExtractToDirectory(string archivePath, string outputPath, bool overwriteFiles)
        {
            ZipFile.ExtractToDirectory(archivePath, outputPath, overwriteFiles);
        }
    }
}
