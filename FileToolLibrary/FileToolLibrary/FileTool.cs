using System.IO;

namespace FileToolLibrary
{
    public static class FileTool
    {
        private const string INCORRECT_DIR_MESSAGE = "Incorrect directory.";
        private const string INCORRECT_DIR_MESSAGE_WITH_ADVICE = "Incorrect directory. Try to add '\\' at the end.";

        public static List<string> GetFilesInfo(string? directory)
        {
            PathAndDirectoryValidator(directory!, nameof(directory));

            try
            {
                string[] files = Directory.GetFiles(directory!);
                List<string> info = [];

                foreach (var file in files)
                {
                    info.Add($"Path: {file}. Name: {Path.GetFileName(file)}.\n");
                }

                return info;
            }
            catch (Exception)
            {
                throw new ArgumentException("Incorrect directory.");
            }
        } 

        public static void AppendText(string path, string text)
        {
            PathAndDirectoryValidator(path!, nameof(path));

            try
            {
                using FileStream fileStream = new FileStream(path, FileMode.Append);
                using StreamWriter streamWriter = new StreamWriter(fileStream);

                streamWriter.Write(text);
            }
            catch (Exception)
            {
                throw new ArgumentException(INCORRECT_DIR_MESSAGE);
            }
        }

        public static string ReadFile(string path)
        {
            PathAndDirectoryValidator(path!, nameof(path));

            try
            {
                using StreamReader streamReader = new StreamReader(path);
                return streamReader.ReadToEnd();
            }
            catch (Exception)
            {
                throw new ArgumentException(INCORRECT_DIR_MESSAGE);
            }
        }

        public static void MoveFiles(string directory, string destinationDirectory)
        {
            PathAndDirectoryValidator(directory!, nameof(directory));
            PathAndDirectoryValidator(destinationDirectory!, nameof(destinationDirectory));

            try
            {
                string[] files = Directory.GetFiles(directory);

                foreach (var file in files)
                {
                    File.Move(file, $"{destinationDirectory}{Path.GetFileName(file)}");
                }
            }
            catch (Exception)
            {
                throw new ArgumentException(INCORRECT_DIR_MESSAGE_WITH_ADVICE);
            }
        }

        private static void PathAndDirectoryValidator(string directory, string argumentName)
        {
            if (directory is null)
            {
                throw new ArgumentException($"{argumentName} is null.");
            }
            if (directory.Length == 0)
            {
                throw new ArgumentException($"{argumentName} is empty.");
            }
            if (string.IsNullOrWhiteSpace(directory))
            {
                throw new ArgumentException($"{argumentName} contains white spaces");
            }
        }
    }
}
