using System;
using System.IO;

namespace Porto.System.IO
{
    public interface IPFile
    {
        void DeleteFile(string path);
        bool FileExists(string path);
        long? GetFileSize(string path);
        byte[] ReadAllBytes(string path);
        string ReadAllText(string path);
        bool TryGetFileCreationUtc(string path, out DateTime created);
        bool TryGetFileModifiedUtc(string path, out DateTime modified);
        void WriteAllBytes(string path, byte[] data);
    }

    public class PFile : IPFile
    {
        public bool FileExists(string path)
        {
            return File.Exists(path);
        }

        public void DeleteFile(string path)
        {
            File.Delete(path);
        }

        public string ReadAllText(string path)
        {
            return File.ReadAllText(path);
        }

        public byte[] ReadAllBytes(string path)
        {
            return File.ReadAllBytes(path);
        }

        public void WriteAllBytes(string path, byte[] data)
        {
            File.WriteAllBytes(path, data);
        }

        public bool TryGetFileCreationUtc(string path, out DateTime created)
        {
            var fileInfo = new FileInfo(path);

            if (!fileInfo.Exists)
            {
                created = default(DateTime);
                return false;
            }

            created = fileInfo.CreationTimeUtc;
            return true;
        }

        public bool TryGetFileModifiedUtc(string path, out DateTime modified)
        {
            var fileInfo = new FileInfo(path);

            if (!fileInfo.Exists)
            {
                modified = default(DateTime);
                return false;
            }

            modified = fileInfo.LastWriteTimeUtc;
            return true;
        }

        public long? GetFileSize(string path)
        {
            var fileInfo = new FileInfo(path);
            if (!fileInfo.Exists) return null;

            return fileInfo.Length;
        }
    }
}
