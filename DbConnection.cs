using System.Reflection;

namespace ApiDevBP
{
    public class DbConnection
    {
        public string path { get; set; } = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        public string db { get; set; } = "localDb";
    }
}
