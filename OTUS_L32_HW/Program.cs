namespace OTUS_L32_HW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\Otus";
            var listSubpath = new List<string>() { "TestDir1", "TestDir2" };

            DirectoryOperation.CreateAllDir(path, listSubpath);
            FileOperation.CreateAllFile(path, listSubpath, 10);
            FileOperation.WriteDateAllFile(path);
            FileOperation.ReadAllFile(path);

        }
    }
}
