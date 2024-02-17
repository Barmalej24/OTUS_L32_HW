namespace OTUS_L32_HW
{
    public class DirectoryOperation
    {
        public static void CreateAllDir(string path, List<string> subpath)
        {
            foreach (var subpathItem in subpath)
            {
                CreateDir(path, subpathItem);
            }
            Console.WriteLine("Директории созданы...");
        }
        private static void CreateDir(string path, string subpath)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            dirInfo.CreateSubdirectory(subpath);
        }
    }
}
