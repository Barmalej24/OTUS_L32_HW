using System.IO;
using System.Text;

namespace OTUS_L32_HW
{
    public class FileOperation
    {
        public static async Task CreateAllFile(string path, List<string> subPath, int count, CancellationToken token)
        {
            foreach (var subpathItem in subPath)
            {
                for (int i = 1; i <= count; i++)
                {
                    CreateFile($@"{path}\{subpathItem}\File{i}");
                    await WriteNameFile($@"{path}\{subpathItem}\File{i}", $"File{i}\n", token);
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

        private static async Task WriteNameFile(string path, string nameFile, CancellationToken token)
        {
            await File.AppendAllTextAsync(path, nameFile, Encoding.UTF8, token);
        }

        public static async Task WriteDateAllFile(string path, CancellationToken token)
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
                       await WriteDateFile(file.FullName, token);
                    }
                }
            }
            Console.WriteLine("В файлы добавлена дата...");
        }

        private static async Task WriteDateFile(string path, CancellationToken token)
        {
            var date = DateTime.Now.ToString();
            await File.AppendAllTextAsync(path, date, Encoding.UTF8, token);
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
