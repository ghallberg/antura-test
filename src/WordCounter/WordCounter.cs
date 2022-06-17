using System.Text.RegularExpressions;

using static WordCounter.FileHandler;

namespace WordCounter
{
    public class WordCounter
    {
        static void Main(string[] args) {
            try {
                if (args.Length != 1) {
                    throw new ArgumentException("This program takes exactly one filename argument");
                }

                var path = FileHandler.GetPath(args[0]);

                var name = FileHandler.GetFileName(path);
                var content = FileHandler.GetFileContent(path);

                var count = CountWords(content, name);

                Console.WriteLine("found " + count);
            } catch (ArgumentException ex) {
                Console.WriteLine("There was a problem with the path:" + ex);
                Environment.Exit(1);
            } catch (FileNotFoundException) {
                Console.WriteLine("File not found");
                Environment.Exit(1);
            } catch (DirectoryNotFoundException) {
                Console.WriteLine("File not found");
                Environment.Exit(1);
            } catch (Exception ex) {
                Console.WriteLine("Something went wrong: " + ex);
                Environment.Exit(1);
            }
        }

        public static int CountWords(string input, string word) {
            string cleanInput = Regex.Replace(input, @"[^\p{L}\p{N} ]+", " ");
            var tokens = cleanInput.Split(" ");
            return tokens.Count(s => s == word);
        }
    }
}
