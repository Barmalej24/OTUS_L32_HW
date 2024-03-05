namespace OTUS_L32_HW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            var path = @"C:\Otus";
            var listSubpath = new List<string>() { "TestDir1", "TestDir2" };

            try
            {
                DirectoryOperation.CreateAllDir(path, listSubpath);
                FileOperation.CreateAllFile(path, listSubpath, 10, cts.Token).Wait();
                FileOperation.WriteDateAllFile(path, cts.Token).Wait();
                FileOperation.ReadAllFile(path, cts.Token).Wait();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                cts.Dispose();
            }
        }
    }
}
