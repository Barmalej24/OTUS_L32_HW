using System.IO;

namespace OTUS_L32_HW
{
    public class FileOperation
    {
        public static void CreateAllFile(string path, List<string> subpath, int count)
        {
            foreach (var subpathItem in subpath)
            {
                for (int i = 1; i <= count; i++)
                {
                    CreateFile($@"{path}\{subpathItem}\File{i}");
                    WriteNameFile($@"{path}\{subpathItem}\File{i}", $"File{i}\n");
                }
            }
            Console.WriteLine("Файлы созданы...");
        }
        private static void CreateFile(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            if (!fileInfo.Exists)
            {
                File.Create(path);
                Console.WriteLine(path);
            }
        }

        private async static void WriteNameFile(string path, string nameFile)
        {
            await File.WriteAllTextAsync(path, nameFile);
        }

        public static void WriteDateAllFile(string path)
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
                        WriteDateFile(file.FullName);
                    }
                }
            }
            Console.WriteLine("В файлы добавлена дата...");
        }

        private async static void WriteDateFile(string path)
        {
            var date = DateTime.Now.ToString();
            await File.AppendAllTextAsync(path, date);
        }

        public static void ReadAllFile(string path)
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
                        ReadFile(file.FullName);
                    }
                }
            }
        }

        private async static void ReadFile(string path)
        {
            var fileName = new FileInfo(path).Name;
            var fileText = await File.ReadAllTextAsync(path);
            Console.WriteLine($"{fileName} :: {fileText}");
        }
    }
}
