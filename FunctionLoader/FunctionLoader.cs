using System;

namespace FunctionLoader
{
    public class FunctionLoader
    {
        private IntPtr hModule;

        public FunctionLoader(string path)
        {
            hModule = Kernel32.LoadLibrary(path);
            if (hModule == IntPtr.Zero)
            {
                throw new Exception("Cannot load native library");
            }
        }

        public FunctionLoader(string path86, string path64)
        {
            hModule = Kernel32.LoadLibrary(Environment.Is64BitProcess ? path64 : path86);
            if (hModule == IntPtr.Zero)
            {
                throw new Exception("Cannot load native library");
            }
        }

        public Delegate LoadFunction<T>(string functionName)
        {
            var func = Kernel32.LoadFunction<T>(hModule, functionName);
            if (func == default(Delegate))
            {
                throw new Exception("Cannot load native function");
            }
            return func;
        }

        public Delegate LoadFunction<T>(string functionName86, string functionName64)
        {
            var func = Kernel32.LoadFunction<T>(hModule, Environment.Is64BitProcess ? functionName64 : functionName86);
            if (func == default(Delegate))
            {
                throw new Exception("Cannot load native function");
            }
            return func;
        }

        ~FunctionLoader()
        {
            Kernel32.FreeLibrary(hModule);
        }
    }
}