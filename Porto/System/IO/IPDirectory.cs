using System;
using System.Collections.Generic;
using System.IO;

namespace Porto.System.IO
{
    public interface IPDirectory
    {
        void Clear(string path);
        void CreateDirectory(string path);
        FileSystemInfo CreateSymbolicLink(string path, string pathToTarget);
        void Delete(string path);
        void Delete(string path, bool recursive);
        IEnumerable<string> EnumerateDirectories(string path);
        IEnumerable<string> EnumerateDirectories(string path, string searchPattern);
        IEnumerable<string> EnumerateDirectories(string path, string searchPattern, EnumerationOptions enumerationOptions);
        IEnumerable<string> EnumerateDirectories(string path, string searchPattern, SearchOption searchOption);
        IEnumerable<string> EnumerateFiles(string path);
        IEnumerable<string> EnumerateFiles(string path, string searchPattern);
        IEnumerable<string> EnumerateFiles(string path, string searchPattern, EnumerationOptions enumerationOptions);
        IEnumerable<string> EnumerateFiles(string path, string searchPattern, SearchOption searchOption);
        IEnumerable<string> EnumerateFileSystemEntries(string path);
        IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern);
        IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern, EnumerationOptions enumerationOptions);
        IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern, SearchOption searchOption);
        bool Exists(string path);
        DateTime GetCreationTime(string path);
        DateTime GetCreationTimeUtc(string path);
        string GetCurrentDirectory();
        string[] GetDirectories(string path);
        string[] GetDirectories(string path, string searchPattern);
        string[] GetDirectories(string path, string searchPattern, EnumerationOptions enumerationOptions);
        string[] GetDirectories(string path, string searchPattern, SearchOption searchOption);
        string GetDirectoryRoot(string path);
        string[] GetFiles(string path);
        string[] GetFiles(string path, string searchPattern);
        string[] GetFiles(string path, string searchPattern, EnumerationOptions enumerationOptions);
        List<string> GetFiles(string directoryPath, string pattern, SearchOption searchOption);
        string[] GetFileSystemEntries(string path);
        string[] GetFileSystemEntries(string path, string searchPattern);
        string[] GetFileSystemEntries(string path, string searchPattern, EnumerationOptions enumerationOptions);
        string[] GetFileSystemEntries(string path, string searchPattern, SearchOption searchOption);
        DateTime GetLastAccessTime(string path);
        DateTime GetLastAccessTimeUtc(string path);
        DateTime GetLastWriteTime(string path);
        DateTime GetLastWriteTimeUtc(string path);
        string[] GetLogicalDrives();
        DirectoryInfo GetParent(string path);
        void Move(string sourceDirName, string destDirName);
        FileSystemInfo ResolveLinkTarget(string linkPath, bool returnFinalTarget);
        void SetCreationTime(string path, DateTime creationTime);
        void SetCreationTimeUtc(string path, DateTime creationTimeUtc);
        void SetCurrentDirectory(string path);
        void SetLastAccessTime(string path, DateTime lastAccessTime);
        void SetLastAccessTimeUtc(string path, DateTime lastAccessTimeUtc);
        void SetLastWriteTime(string path, DateTime lastWriteTime);
        void SetLastWriteTimeUtc(string path, DateTime lastWriteTimeUtc);
    }
}