using System.Text.RegularExpressions;

namespace WordCounter
{
    public class FileHandler
    {
        public static string GetPath(string rawPath) {
            string basePath = Environment.CurrentDirectory;

            string fullPath = Path.GetFullPath(rawPath, basePath);
            return fullPath;
        }

        public static string GetFileName(string path) {
            if (Path.EndsInDirectorySeparator(path)) {
                throw new ArgumentException("Specified path is a directory, not a file.");
            }

            string name = Path.GetFileNameWithoutExtension(path);

            if (name.Contains(" ")){
                throw new ArgumentException("File name can't contain space.");
            }

            if (new Regex(@"[^\p{L}\p{N} ]+").Matches(name).Count > 0)
            {
                throw new ArgumentException("File name should only have one extension.");
            }

            return name;
        }

        public static string GetFileContent(string path) {
            using (var sr = new StreamReader(path))
            {
                return sr.ReadToEnd();
            }
        }
    }
}
