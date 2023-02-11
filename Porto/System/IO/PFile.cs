using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Porto.System.IO
{
    /// <summary>
    /// Wraps and provides an interface for the System.IO.File class, as well as providing some additional helper methods.
    /// </summary>
    public class PFile : IPFile
    {
        public StreamReader OpenText(string path)
        {
            return File.OpenText(path);
        }
        public StreamWriter CreateText(string path)
        {
            return File.CreateText(path);
        }
        public StreamWriter AppendText(string path)
        {
            return File.AppendText(path);
        }
        public void Copy(string sourceFileName, string destFileName)
        {
            File.Copy(sourceFileName, destFileName);
        }
        public void Copy(string sourceFileName, string destFileName, bool overwrite)
        {
            File.Copy(sourceFileName, destFileName, overwrite);
        }
        public FileStream Create(string path)
        {
            return File.Create(path);
        }
        public FileStream Create(string path, int bufferSize)
        {
            return File.Create(path, bufferSize);
        }
        public FileStream Create(string path, int bufferSize, FileOptions options)
        {
            return File.Create(path, bufferSize, options);
        }
        public void Delete(string path)
        {
            File.Delete(path);
        }
        public bool Exists([NotNullWhen(true)] string? path)
        {
            return File.Exists(path);
        }
        public FileStream Open(string path, FileMode mode)
        {
            return File.Open(path, mode);
        }
        public FileStream Open(string path, FileMode mode, FileAccess access)
        {
            return File.Open(path, mode, access);
        }
        public FileStream Open(string path, FileMode mode, FileAccess access, FileShare share)
        {
            return File.Open(path, mode, access, share);
        }
        public void SetCreationTime(string path, DateTime creationTime)
        {
            File.SetCreationTime(path, creationTime);
        }
        public void SetCreationTimeUtc(string path, DateTime creationTimeUtc)
        {
            File.SetCreationTimeUtc(path, creationTimeUtc);
        }
        public DateTime GetCreationTime(string path)
        {
            return File.GetCreationTime(path);
        }
        public DateTime GetCreationTimeUtc(string path)
        {
            return File.GetCreationTimeUtc(path);
        }
        public void SetLastAccessTime(string path, DateTime lastAccessTime)
        {
            File.SetLastAccessTime(path, lastAccessTime);
        }
        public void SetLastAccessTimeUtc(string path, DateTime lastAccessTimeUtc)
        {
            File.SetLastAccessTimeUtc(path, lastAccessTimeUtc);
        }
        public DateTime GetLastAccessTime(string path)
        {
            return File.GetLastAccessTime(path);
        }
        public DateTime GetLastAccessTimeUtc(string path)
        {
            return File.GetLastAccessTimeUtc(path);
        }
        public void SetLastWriteTime(string path, DateTime lastWriteTime)
        {
            File.SetLastWriteTime(path, lastWriteTime);
        }
        public void SetLastWriteTimeUtc(string path, DateTime lastWriteTimeUtc)
        {
            File.SetLastWriteTimeUtc(path, lastWriteTimeUtc);
        }
        public DateTime GetLastWriteTime(string path)
        {
            return File.GetLastWriteTime(path);
        }
        public DateTime GetLastWriteTimeUtc(string path)
        {
            return File.GetLastWriteTimeUtc(path);
        }
        public FileAttributes GetAttributes(string path)
        {
            return File.GetAttributes(path);
        }
        public void SetAttributes(string path, FileAttributes fileAttributes)
        {
            File.SetAttributes(path, fileAttributes);
        }
        public FileStream OpenRead(string path)
        {
            return File.OpenRead(path);
        }
        public FileStream OpenWrite(string path)
        {
            return File.OpenWrite(path);
        }
        public void WriteAllText(string path, string? contents)
        {
            File.WriteAllText(path, contents);
        }
        public void WriteAllText(string path, string? contents, Encoding encoding)
        {
            File.WriteAllText(path, contents, encoding);
        }
        public void WriteAllBytes(string path, byte[] bytes)
        {
            File.WriteAllBytes(path, bytes);
        }
        public string[] ReadAllLines(string path)
        {
            return File.ReadAllLines(path);
        }
        public string[] ReadAllLines(string path, Encoding encoding)
        {
            return File.ReadAllLines(path, encoding);
        }
        public string ReadAllText(string path)
        {
            return File.ReadAllText(path);
        }
        public string ReadAllText(string path, Encoding encoding)
        {
            return File.ReadAllText(path, encoding);
        }
        public byte[] ReadAllBytes(string path)
        {
            return File.ReadAllBytes(path);
        }
        public IEnumerable<string> ReadLines(string path)
        {
            return File.ReadLines(path);
        }
        public IEnumerable<string> ReadLines(string path, Encoding encoding)
        {
            return File.ReadLines(path, encoding);
        }
        public void WriteAllLines(string path, string[] contents)
        {
            File.WriteAllLines(path, contents);
        }
        public void WriteAllLines(string path, IEnumerable<string> contents)
        {
            File.WriteAllLines(path, contents);
        }
        public void WriteAllLines(string path, string[] contents, Encoding encoding)
        {
            File.WriteAllLines(path, contents, encoding);
        }
        public void WriteAllLines(string path, IEnumerable<string> contents, Encoding encoding)
        {
            File.WriteAllLines(path, contents, encoding);
        }
        public void AppendAllText(string path, string? contents)
        {
            File.AppendAllText(path, contents);
        }
        public void AppendAllText(string path, string? contents, Encoding encoding)
        {
            File.AppendAllText(path, contents, encoding);
        }
        public void AppendAllLines(string path, IEnumerable<string> contents)
        {
            File.AppendAllLines(path, contents);
        }
        public void AppendAllLines(string path, IEnumerable<string> contents, Encoding encoding)
        {
            File.AppendAllLines(path, contents, encoding);
        }
        public void Replace(string sourceFileName, string destinationFileName, string? destinationBackupFileName)
        {
            File.Replace(sourceFileName, destinationFileName, destinationBackupFileName);
        }
        public void Replace(string sourceFileName, string destinationFileName, string? destinationBackupFileName, bool ignoreMetadataErrors)
        {
            File.Replace(sourceFileName, destinationFileName, destinationBackupFileName, ignoreMetadataErrors);
        }
        public void Move(string sourceFileName, string destFileName)
        {
            File.Move(sourceFileName, destFileName);
        }
        public void Move(string sourceFileName, string destFileName, bool overwrite)
        {
            File.Move(sourceFileName, destFileName, overwrite);
        }
        public void Encrypt(string path)
        {
            File.Encrypt(path);
        }
        public void Decrypt(string path)
        {
            File.Decrypt(path);
        }
        public Task<string> ReadAllTextAsync(string path, CancellationToken cancellationToken = default(CancellationToken))
        {
            return File.ReadAllTextAsync(path, cancellationToken);
        }
        public Task<string> ReadAllTextAsync(string path, Encoding encoding, CancellationToken cancellationToken = default(CancellationToken))
        {
            return File.ReadAllTextAsync(path, encoding, cancellationToken);
        }
        public Task WriteAllTextAsync(string path, string? contents, CancellationToken cancellationToken = default(CancellationToken))
        {
            return File.WriteAllTextAsync(path, contents, cancellationToken);
        }
        public Task WriteAllTextAsync(string path, string? contents, Encoding encoding, CancellationToken cancellationToken = default(CancellationToken))
        {
            return File.WriteAllTextAsync(path, contents, encoding, cancellationToken);
        }
        public Task<byte[]> ReadAllBytesAsync(string path, CancellationToken cancellationToken = default(CancellationToken))
        {
            return File.ReadAllBytesAsync(path, cancellationToken);
        }
        public Task WriteAllBytesAsync(string path, byte[] bytes, CancellationToken cancellationToken = default(CancellationToken))
        {
            return File.WriteAllBytesAsync(path, bytes, cancellationToken);
        }
        public Task<string[]> ReadAllLinesAsync(string path, CancellationToken cancellationToken = default(CancellationToken))
        {
            return File.ReadAllLinesAsync(path, cancellationToken);
        }
        public Task<string[]> ReadAllLinesAsync(string path, Encoding encoding, CancellationToken cancellationToken = default(CancellationToken))
        {
            return File.ReadAllLinesAsync(path, encoding, cancellationToken);
        }
        public Task WriteAllLinesAsync(string path, IEnumerable<string> contents, CancellationToken cancellationToken = default(CancellationToken))
        {
            return File.WriteAllLinesAsync(path, contents, cancellationToken);
        }
        public Task WriteAllLinesAsync(string path, IEnumerable<string> contents, Encoding encoding, CancellationToken cancellationToken = default(CancellationToken))
        {
            return File.WriteAllLinesAsync(path, contents, encoding, cancellationToken);
        }
        public Task AppendAllTextAsync(string path, string? contents, CancellationToken cancellationToken = default(CancellationToken))
        {
            return File.AppendAllTextAsync(path, contents, cancellationToken);
        }
        public Task AppendAllTextAsync(string path, string? contents, Encoding encoding, CancellationToken cancellationToken = default(CancellationToken))
        {
            return File.AppendAllTextAsync(path, contents, encoding, cancellationToken);
        }
        public Task AppendAllLinesAsync(string path, IEnumerable<string> contents, CancellationToken cancellationToken = default(CancellationToken))
        {
            return File.AppendAllLinesAsync(path, contents, cancellationToken);
        }
        public Task AppendAllLinesAsync(string path, IEnumerable<string> contents, Encoding encoding, CancellationToken cancellationToken = default(CancellationToken))
        {
            return File.AppendAllLinesAsync(path, contents, encoding, cancellationToken);
        }
        public FileSystemInfo CreateSymbolicLink(string path, string pathToTarget)
        {
            return File.CreateSymbolicLink(path, pathToTarget);
        }
        public FileSystemInfo? ResolveLinkTarget(string linkPath, bool returnFinalTarget)
        {
            return File.ResolveLinkTarget(linkPath, returnFinalTarget);
        }

        /* New methods
         * */
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
