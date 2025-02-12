namespace FileToolLibrary
{
    public static class FileTool
    {
        public static List<string> GetFilesInfo(string directory)
        {
            string[] files = Directory.GetFiles(directory);
            List<string> info = new List<string>();

            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);

                info.Add($"Path of file: {file}. Name of file: {Path.GetFileNameWithoutExtension(file)}." +
                         $"Extemtion: {Path.GetExtension(file)}. Name with extention: {Path.GetFileName(file)}" +
                         $"Creation time: {fileInfo.CreationTime}. Length: {fileInfo.Length}.\n");
            }

            return info;
        }

        public static void MoveFiles(string directory, string destinationDir)
        {
            string[] files = Directory.GetFiles(directory);

            foreach (var file in files)
                File.Move(file, $"{destinationDir}{Path.GetFileName(file)}");
        }
        public static void FileAppend(string path, string text)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.Append))
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                    streamWriter.WriteLine(text);
        }
        public static string ReadFile(string path)
        {
            using (StreamReader streamReader = new StreamReader(path))
            {
                return streamReader.ReadToEnd();
            }
        }
    }
}
