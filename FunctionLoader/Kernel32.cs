using System;
using System.Runtime.InteropServices;

namespace FunctionLoader
{
    internal static class Kernel32
    {
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
        [DllImport("kernel32.dll")]
#pragma warning restore CA2101 // Specify marshaling for P/Invoke string arguments
        internal static extern IntPtr LoadLibrary(string path);

#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
        [DllImport("kernel32.dll")]
#pragma warning restore CA2101 // Specify marshaling for P/Invoke string arguments
        private static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        [DllImport("kernel32.dll")]
        internal static extern bool FreeLibrary(IntPtr hModule);

        internal static Delegate LoadFunction<T>(IntPtr hModule, string procName)
        {
            var procAddress = GetProcAddress(hModule, procName);
            return Marshal.GetDelegateForFunctionPointer(procAddress, typeof(T));
        }
    }
}