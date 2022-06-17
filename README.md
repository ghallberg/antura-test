#WordCounter

This is a simple console tool for counting occurences of a filename inside the text file with the same name.

##Scope
There are three major limitations to the scope for this application:
1. We can not check if a file is actually a text file. If you pass a non-text file you will probably get unexpected results.
2. The program does not support filenames with spaces, and will error out if such a file is provided as input.
3. The program does not support multiple file extensions.
4. The program has only been tested on Linux, so there could be some oddities around windows file paths.

##Usage
From the project root, run `dotnet run src/WordCounter <path>` to count the number of occurences in the file at the specified path.

Examples:
`dotnet run src/WordCounter ./testfiles/test.txt`
`dotnet run src/WordCounter /home/username/md_test.md`
`dotnet run src/WordCounter c:\test.txt`


##Tests
From the project root run `dotnet test tests/WordCounterTests` to run the tests.

##Assumptions
- Words should not be counted if they are part of other words.
  E.g "test testtest hej" contains "test" only 1 time.
- Any non alphanumerical character is not part of a word
  E.g "test, test,test" contains "test" 3 times.
- The program i case sensitive.
  E.g "test TEST" contains "test" only once.
