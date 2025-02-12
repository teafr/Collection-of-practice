using FileToolLibrary;
using System.IO;

namespace FileToolLibrary.Tests
{
    [TestClass]
    public sealed class FileToolTest
    {
        [TestMethod]
        public void GetFilesInfo_ShouldGiveInfoAboutAllFilesByDir()
        {
            // Arange
            string directory = @$"{Environment.CurrentDirectory}\testFolder";
            Directory.CreateDirectory(directory);

            string expactedName = "forTesting.txt";
            string expactedPath = directory + @$"\{expactedName}";

            File.Create(expactedPath);
            string expacted = $"Path: {expactedPath}. Name: {expactedName}.\n";

            // Act
            List<string> actual = FileTool.GetFilesInfo(directory);

            // Assert
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual(expacted, actual[0]);
        }

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
        public void AppendTextInFile_ShouldCorrectlyAppendText()
        {
            // Arange
            string path = @$"{Environment.CurrentDirectory}\appendTest.txt", text = "some text";
            File.Create(path).Close();

            // Act
            FileTool.AppendText(path, text);
            FileInfo fileInfo = new FileInfo(path);

            // Assert
            Assert.AreEqual(text.Length, fileInfo.Length);
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
        public void ReadFile_ShouldCorrectlyReadTextInFile()
        {
            // Arange
            string path = @$"{Environment.CurrentDirectory}\readTest.txt", expacted = "a lot of text";
            File.Create(path).Close();

            // Act
            FileTool.AppendText(path, expacted);
            string actual = FileTool.ReadFile(path);

            // Assert
            Assert.AreEqual(expacted, actual);
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
        public void MoveFiles_ShouldMoveFilesFromOneDirToAnother()
        {
            // Arange
            string directory = @$"{Environment.CurrentDirectory}\moveFrom\";
            string destination = @$"{Environment.CurrentDirectory}\moveTo\";

            Directory.CreateDirectory(directory);
            Directory.CreateDirectory(destination);

            string fileName = "forMoving.txt";
            File.Create(directory + @$"\{fileName}").Close();

            // Act
            FileTool.MoveFiles(directory, destination);

            // Assert
            Assert.IsTrue(File.Exists(destination + @$"\{fileName}"));
            File.Delete(destination + @$"\{fileName}");
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
