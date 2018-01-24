using Microsoft.VisualStudio.TestTools.UnitTesting;
using MissingNumber;
using System.Collections.Generic;
using System.Collections;
using System;

namespace MissingNumberTests
{
    [TestClass]
    public class NumberLineTests
    {
        [TestMethod]
        public void NumberLine_Constructor_ValidDataTest()
        {
            NumberLine target = new NumberLine("1,2,4,5", ',');
            IList<int> expected = new List<int> { 1, 2, 4, 5 };
            CollectionAssert.AreEqual((ICollection)expected, (ICollection)target.Numbers);
        }

        [TestMethod]
        public void NumberLine_Constructor_WithSpacesTest()
        {
            NumberLine target = new NumberLine("1, 2 , 4 ,     5", ',');
            IList<int> expected = new List<int> { 1, 2, 4, 5 };
            CollectionAssert.AreEqual((ICollection)expected, (ICollection)target.Numbers);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NumberLine_Constructor_InvalidStringTest()
        {
            NumberLine target = new NumberLine("bad data", ',');
        }

        [TestMethod]
        public void NumberLine_FindMissingNumber_ValidTest()
        {
            NumberLine target = new NumberLine("1,2,4,5", ',');
            int expected = 3;
            Assert.AreEqual(expected, target.MissingNumber);
        }

        [TestMethod]
        public void NumberLine_FindMissingNumber_ValidTest2()
        {
            NumberLine target = new NumberLine("1,2,3,4,5,6,7,8,9,10,12", ',');
            int expected = 11;
            Assert.AreEqual(expected, target.MissingNumber);
        }

        [TestMethod]
        public void NumberLine_FindMissingNumber_ValidTest3()
        {
            NumberLine target = new NumberLine("24,26,27,29,28", ',');
            int expected = 25;
            Assert.AreEqual(expected, target.MissingNumber);
        }

        [TestMethod]
        public void NumberLine_FindMissingNumber_ValidTest4()
        {
            NumberLine target = new NumberLine("99,100,101,102,103,104,105,107", ',');
            int expected = 106;
            Assert.AreEqual(expected, target.MissingNumber);
        }

        [TestMethod]
        public void NumberLine_FindMissingNumber_ValidTest5()
        {
            NumberLine target = new NumberLine("109,105,107,108,106,110,112,111,118,116,115,114,117", ',');
            int expected = 113;
            Assert.AreEqual(expected, target.MissingNumber);
        }
    }
}
