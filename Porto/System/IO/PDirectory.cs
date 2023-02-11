using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Porto.System.IO
{

    /// <summary>
    /// Wraps and provides and interface for the System.IO.Directory class, as well as providing some additional helper methods.
    /// </summary>
    public class PDirectory : IPDirectory
    {
        public bool Exists(string path)
        {
            return Directory.Exists(path);
        }
        public void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }
        public DirectoryInfo? GetParent(string path)
        {
            return Directory.GetParent(path);
        }
        public void SetCreationTime(string path, DateTime creationTime)
        {
            Directory.SetCreationTime(path, creationTime);
        }
        public void SetCreationTimeUtc(string path, DateTime creationTimeUtc)
        {
            Directory.SetCreationTimeUtc(path, creationTimeUtc);
        }
        public DateTime GetCreationTime(string path)
        {
            return Directory.GetCreationTime(path);
        }
        public DateTime GetCreationTimeUtc(string path)
        {
            return Directory.GetCreationTimeUtc(path);
        }
        public void SetLastWriteTime(string path, DateTime lastWriteTime)
        {
            Directory.SetLastWriteTime(path, lastWriteTime);
        }
        public void SetLastWriteTimeUtc(string path, DateTime lastWriteTimeUtc)
        {
            Directory.SetCreationTimeUtc(path, lastWriteTimeUtc);
        }
        public DateTime GetLastWriteTime(string path)
        {
            return Directory.GetLastWriteTime(path);
        }
        public DateTime GetLastWriteTimeUtc(string path)
        {
            return Directory.GetLastWriteTimeUtc(path);
        }
        public void SetLastAccessTime(string path, DateTime lastAccessTime)
        {
            Directory.SetLastAccessTime(path, lastAccessTime);
        }
        public void SetLastAccessTimeUtc(string path, DateTime lastAccessTimeUtc)
        {
            Directory.SetLastAccessTimeUtc(path, lastAccessTimeUtc);
        }
        public DateTime GetLastAccessTime(string path)
        {
            return Directory.GetLastAccessTime(path);
        }
        public DateTime GetLastAccessTimeUtc(string path)
        {
            return GetLastAccessTimeUtc(path);
        }
        public string[] GetFiles(string path)
        {
            return Directory.GetFiles(path);
        }
        public string[] GetFiles(string path, string searchPattern)
        {
            return Directory.GetFiles(path, searchPattern);
        }
        public List<string> GetFiles(string directoryPath, string pattern, SearchOption searchOption)
        {
            return Directory.GetFiles(directoryPath, pattern, searchOption).ToList();
        }
        public string[] GetFiles(string path, string searchPattern, EnumerationOptions enumerationOptions)
        {
            return Directory.GetFiles(path, searchPattern, enumerationOptions);
        }
        public string[] GetDirectories(string path)
        {
            return Directory.GetDirectories(path);
        }
        public string[] GetDirectories(string path, string searchPattern)
        {
            return Directory.GetDirectories(path, searchPattern);
        }
        public string[] GetDirectories(string path, string searchPattern, SearchOption searchOption)
        {
            return Directory.GetDirectories(path, searchPattern, searchOption);
        }
        public string[] GetDirectories(string path, string searchPattern, EnumerationOptions enumerationOptions)
        {
            return Directory.GetDirectories(path, searchPattern, enumerationOptions);
        }
        public string[] GetFileSystemEntries(string path)
        {
            return Directory.GetFileSystemEntries(path);
        }
        public string[] GetFileSystemEntries(string path, string searchPattern)
        {
            return Directory.GetFileSystemEntries(path, searchPattern);
        }
        public string[] GetFileSystemEntries(string path, string searchPattern, SearchOption searchOption)
        {
            return Directory.GetFileSystemEntries(path, searchPattern, searchOption);
        }
        public string[] GetFileSystemEntries(string path, string searchPattern, EnumerationOptions enumerationOptions)
        {
            return Directory.GetFileSystemEntries(path, searchPattern, enumerationOptions);
        }
        public IEnumerable<string> EnumerateDirectories(string path)
        {
            return Directory.EnumerateDirectories(path);
        }
        public IEnumerable<string> EnumerateDirectories(string path, string searchPattern)
        {
            return Directory.EnumerateDirectories(path, searchPattern);
        }
        public IEnumerable<string> EnumerateDirectories(string path, string searchPattern, SearchOption searchOption)
        {
            return Directory.EnumerateDirectories(path, searchPattern, searchOption);
        }
        public IEnumerable<string> EnumerateDirectories(string path, string searchPattern, EnumerationOptions enumerationOptions)
        {
            return Directory.EnumerateDirectories(path, searchPattern, enumerationOptions);
        }
        public IEnumerable<string> EnumerateFiles(string path)
        {
            return Directory.EnumerateFiles(path);
        }
        public IEnumerable<string> EnumerateFiles(string path, string searchPattern)
        {
            return Directory.EnumerateFiles(path, searchPattern);
        }
        public IEnumerable<string> EnumerateFiles(string path, string searchPattern, SearchOption searchOption)
        {
            return Directory.EnumerateFiles(path, searchPattern, searchOption);
        }
        public IEnumerable<string> EnumerateFiles(string path, string searchPattern, EnumerationOptions enumerationOptions)
        {
            return Directory.EnumerateFiles(path, searchPattern, enumerationOptions);
        }
        public IEnumerable<string> EnumerateFileSystemEntries(string path)
        {
            return Directory.EnumerateFileSystemEntries(path);
        }
        public IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern)
        {
            return Directory.EnumerateFileSystemEntries(path, searchPattern);
        }
        public IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern, SearchOption searchOption)
        {
            return Directory.EnumerateFileSystemEntries(path, searchPattern, searchOption);
        }
        public IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern, EnumerationOptions enumerationOptions)
        {
            return Directory.EnumerateFileSystemEntries(path, searchPattern, enumerationOptions);
        }
        public string GetDirectoryRoot(string path)
        {
            return Directory.GetDirectoryRoot(path);
        }
        public string GetCurrentDirectory()
        {
            return Directory.GetCurrentDirectory();
        }
        public void SetCurrentDirectory(string path)
        {
            Directory.SetCurrentDirectory(path);
        }
        public void Move(string sourceDirName, string destDirName)
        {
            Directory.Move(sourceDirName, destDirName);
        }
        public void Delete(string path)
        {
            Directory.Delete(path);
        }
        public void Delete(string path, bool recursive)
        {
            Directory.Delete(path, recursive);
        }
        public string[] GetLogicalDrives()
        {
            return Directory.GetLogicalDrives();
        }
        public FileSystemInfo CreateSymbolicLink(string path, string pathToTarget)
        {
            return Directory.CreateSymbolicLink(path, pathToTarget);
        }
        public FileSystemInfo? ResolveLinkTarget(string linkPath, bool returnFinalTarget)
        {
            return Directory.ResolveLinkTarget(linkPath, returnFinalTarget);
        }


        /* New methods
         * */
        public void Clear(string path)
        {
            var di = new DirectoryInfo(path);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }

            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }


    }
}
