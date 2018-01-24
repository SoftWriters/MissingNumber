using Microsoft.VisualStudio.TestTools.UnitTesting;
using MissingNumber;
using System.IO;

namespace MissingNumberTests
{
    [TestClass]
    public class MainViewModelTests
    {
        [TestMethod]
        public void MainViewModel_ReadFile_ResultsTest()
        {
            MainViewModel target = new MainViewModel();
            target.ReadFile(Path.Combine(Directory.GetCurrentDirectory(), @"DataFiles\badsamples.txt"));
            int expected = 1;
            Assert.AreEqual(expected, target.Results.Count);
        }
        
        [TestMethod]
        public void MainViewModel_ReadFile_ClearsResults()
        {
            MainViewModel target = new MainViewModel();
            target.ReadFile(Path.Combine(Directory.GetCurrentDirectory(), @"DataFiles\badsamples.txt"));
            target.ReadFile(Path.Combine(Directory.GetCurrentDirectory(), @"DataFiles\samples.txt"));
            int expected = 5;
            Assert.AreEqual(expected, target.Results.Count);
        }

        [TestMethod]
        public void MainViewModel_ReadFile_BadFileFormat()
        {
            MainViewModel target = new MainViewModel();
            target.ReadFile(Path.Combine(Directory.GetCurrentDirectory(), @"DataFiles\wrongformat.pdf"));
        }
    }
}
