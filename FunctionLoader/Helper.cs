using System.IO;

namespace FunctionLoader
{
    class Helper
    {
        public string AssemblyLocation {
            get
            {
                return Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            }
        }
    }
}