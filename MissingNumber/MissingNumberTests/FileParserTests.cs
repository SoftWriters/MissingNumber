using Microsoft.VisualStudio.TestTools.UnitTesting;
using MissingNumber;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace MissingNumberTests
{
    [TestClass]
    public class FileParserTests
    {
        [TestMethod]
        public void FileParser_ParseFile_ValidTest()
        {
            FileParser target = new FileParser();
            IList<int> expected = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 12 };
            IReadOnlyList<int> actual = target.ParseFile(Path.Combine(Directory.GetCurrentDirectory(), @"DataFiles\samples.txt"))[0].Numbers;
            CollectionAssert.AreEqual((ICollection)expected, (ICollection)actual);
        }

        [TestMethod]
        public void FileParser_ParseFile_IgnoreEmptyLinesTest()
        {
            FileParser target = new FileParser();
            int expected = 5;
            int actual = target.ParseFile(Path.Combine(Directory.GetCurrentDirectory(), @"DataFiles\samples.txt")).Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FileParser_ParseFile_BadDataTest()
        {
            FileParser target = new FileParser();
            int expected = 1;
            int actual = target.ParseFile(Path.Combine(Directory.GetCurrentDirectory(), @"DataFiles\badsamples.txt")).Count;
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void FileParser_ParseFile_BadData_ValidAnswerTest()
        {
            FileParser target = new FileParser();
            int expected = 3;
            int actual = target.ParseFile(Path.Combine(Directory.GetCurrentDirectory(), @"DataFiles\badsamples.txt"))[0].MissingNumber;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FileParser_ParseFile_FileBlankTest()
        {
            FileParser target = new FileParser();
            int expected = 0;
            int actual = target.ParseFile(Path.Combine(Directory.GetCurrentDirectory(), @"DataFiles\blank.txt")).Count;
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void FileParser_ParseFile_NoValidDataTest()
        {
            FileParser target = new FileParser();
            int expected = 0;
            int actual = target.ParseFile(Path.Combine(Directory.GetCurrentDirectory(), @"DataFiles\novalid.txt")).Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void FileParser_ParseFile_FileNotFoundTest()
        {
            FileParser target = new FileParser();
            target.ParseFile("fileThatDoesntExist.txt");
        }
    }
}
