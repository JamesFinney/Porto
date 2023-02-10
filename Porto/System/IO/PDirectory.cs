using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Porto.System.IO
{
    public interface IPDirectory
    {
        /// <summary>
        /// Clears all contents of a directory.
        /// </summary>
        /// <param name="path">The path to the directory to clear</param>
        void Clear(string path);

        /// <summary>
        /// Creates a new directoy.
        /// </summary>
        /// <param name="path">The path to the directory to create</param>
        void CreateDirectory(string path);

        /// <summary>
        /// Checks whether the specified directory exsits.
        /// </summary>
        /// <param name="path">The path to the directory.</param>
        /// <returns>True if the directory exists; False if it does not</returns>
        bool Exists(string path);

        /// <summary>
        /// Gets a list of all files in a directory.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="pattern"></param>
        /// <param name="searchOption"></param>
        /// <returns></returns>
        List<string> GetFiles(string path, string pattern, SearchOption searchOption);
    }

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

        public List<string> GetFiles(string directoryPath, string pattern, SearchOption searchOption)
        {
            return Directory.GetFiles(directoryPath, pattern, searchOption).ToList();
        }
    }
}
