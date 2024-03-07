using System.IO;
using System.Text;

namespace OTUS_L32_HW
{
    public class FileOperation
    {
        public static async Task CreateAllFile(string path, List<string> subPath, int count)
        {
            foreach (var subpathItem in subPath)
            {
                for (int i = 1; i <= count; i++)
                {
                    CreateFile($@"{path}\{subpathItem}\File{i}");
                    await WriteNameFile($@"{path}\{subpathItem}\File{i}", $"File{i}\n");
                }
            }
            Console.WriteLine("Файлы созданы...");
        }
        private static void CreateFile(string path)
        {
            var fileInfo = new FileInfo(path);
            if (!fileInfo.Exists)
            {
                fileInfo.Create().Dispose();
                Console.WriteLine(path);
            }
        }

        private static async Task WriteNameFile(string path, string nameFile)
        {
            await using var wr = new StreamWriter(path, true, Encoding.UTF8);
            await wr.WriteLineAsync(nameFile);
        }

        public static async Task WriteDateAllFile(string path)
        {
            var directory = new DirectoryInfo(path);

            if (directory.Exists)
            {
                var dirs = directory.GetDirectories();
                foreach (var dir in dirs)
                {
                    var files = dir.GetFiles();
                    foreach (var file in files)
                    {
                       await WriteDateFile(file.FullName);
                    }
                }
            }
            Console.WriteLine("В файлы добавлена дата...");
        }

        private static async Task WriteDateFile(string path)
        {
            var date = DateTime.Now.ToString();
            await using var wr = new StreamWriter(path, true, Encoding.UTF8);
            await wr.WriteLineAsync(date);
        }

        public static async Task ReadAllFile(string path, CancellationToken token)
        {
            var directory = new DirectoryInfo(path);

            if (directory.Exists)
            {
                var dirs = directory.GetDirectories();
                foreach (var dir in dirs)
                {
                    var files = dir.GetFiles();
                    foreach (var file in files)
                    {
                       await ReadFile(file.FullName, token);
                    }
                }
            }
        }

        private static async Task ReadFile(string path, CancellationToken token)
        {
            var fileName = new FileInfo(path).Name;
            var fileText = await File.ReadAllTextAsync(path, token);
            Console.WriteLine($"{fileName} :: {fileText}");
        }
    }
}
