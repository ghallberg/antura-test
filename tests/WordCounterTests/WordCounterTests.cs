using Xunit;
using WordCounter;
using System;
using System.IO;

namespace WordCounterTests
{
    public class GetPathTests
    {
        [Fact]
        public void TestIsFullPath()
        {
            var input = "/testfiles/test.txt";
            Assert.Equal(input, WordCounter.FileHandler.GetPath(input));
        }

        [Fact]
        public void TestAddsBasePath()
        {
            string basePath = Environment.CurrentDirectory;
            var sep = Path.DirectorySeparatorChar;

            string input = "testfiles"+ sep + "test.txt";
            Assert.Equal(basePath + sep + input, WordCounter.FileHandler.GetPath(input));
        }
    }

    public class CountWordsTest
    {
        [Fact]
        public void Counts()
        {
            string input = "hej test, testtest lol test,test";
            string word = "test";
            Assert.Equal(3, WordCounter.WordCounter.CountWords(input, word));
        }

        [Fact]
        public void IsCaseSensitive()
        {
            string input = "test TEST";
            string word = "test";
            Assert.Equal(1, WordCounter.WordCounter.CountWords(input, word));
        }
        [Fact]
        public void HandlesEmpty()
        {
            string input = "";
            string word = "test";
            Assert.Equal(0, WordCounter.WordCounter.CountWords(input, word));
        }

        [Fact]
        public void HandlesDiacritics()
        {
            string input = "löl";
            string word = "löl";
            Assert.Equal(1, WordCounter.WordCounter.CountWords(input, word));
        }

        [Fact]
        public void HandlesNumbers()
        {
            string input = "1o1";
            string word = "1o1";
            Assert.Equal(1, WordCounter.WordCounter.CountWords(input, word));
        }
    }

    public class GetFileNameTest
    {
        [Fact]
        public void GetsName()
        {
            string input = "/testfiles/testhmm.txt";
            Assert.Equal("testhmm", WordCounter.FileHandler.GetFileName(input));
        }

        [Fact]
        public void HandlesNoExtension()
        {
            string input = "/testfiles/testhmm";
            Assert.Equal("testhmm", WordCounter.FileHandler.GetFileName(input));
        }

        [Fact]
        public void ThrowsOnMultipleExtensions()
        {
            string input = "/testfiles/testhmm.txt.test.lol";
            Assert.Throws<ArgumentException>(() => WordCounter.FileHandler.GetFileName(input));
        }

        [Fact]
        public void ThrowsOnSpace()
        {
            string input = "/testfiles/test hmm.txt";
            Assert.Throws<ArgumentException>(() => WordCounter.FileHandler.GetFileName(input));
        }

        [Fact]
        public void TestEndsInDirectory()
        {
            Assert.Throws<ArgumentException>(() => WordCounter.FileHandler.GetFileName("/test/"));
        }
    }
}
