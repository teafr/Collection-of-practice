using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileToolLibrary.Tests
{
    [TestClass]
    public class ThrowsExceptionTests
    {
        [TestMethod]
        [DataRow("")]
        [DataRow("      ")]
        [DataRow(null)]
        [DataRow(@"\djfj")]
        public void GetFilesInfo_ThrowsArgumentException(string argument)
        {
            Assert.ThrowsException<ArgumentException>(() => FileTool.GetFilesInfo(argument));
        }

        [TestMethod]
        [DataRow("")]
        [DataRow("      ")]
        [DataRow(null)]
        [DataRow(@"\djfj")]
        public void AppendTextInFile_ThrowsArgumentException(string argument)
        {
            Assert.ThrowsException<ArgumentException>(() => FileTool.AppendText(argument, "Some text"));
        }

        [TestMethod]
        [DataRow("")]
        [DataRow("      ")]
        [DataRow(null)]
        [DataRow(@"\djfj")]
        public void ReadFile_ThrowsArgumentException(string argument)
        {
            Assert.ThrowsException<ArgumentException>(() => FileTool.ReadFile(argument));
        }

        [TestMethod]
        [DataRow("", @"C:\")]
        [DataRow("      ", @"C:\")]
        [DataRow(null, @"C:\")]
        [DataRow(@"\djfj", @"C:\")]
        [DataRow(@"C:\", "")]
        [DataRow(@"C:\", "    ")]
        [DataRow(@"C:\", null)]
        [DataRow(@"C:\", @"\djfj")]
        public void MoveFiles_ThrowsArgumentException(string direction, string destination)
        {
            Assert.ThrowsException<ArgumentException>(() => FileTool.MoveFiles(direction, destination));
        }
    }
}
