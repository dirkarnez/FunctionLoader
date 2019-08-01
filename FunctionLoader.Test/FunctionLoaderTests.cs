using NUnit.Framework;

namespace Tests
{
    public class FunctionLoaderTests
    {
        private delegate int DriveTypeDelegate(int iDrive);
        private static DriveTypeDelegate DriveType;

        [Test]
        public void Test1()
        {
            var functionLoader = new FunctionLoader.FunctionLoader(@"C:\Windows\System32\shell32.dll");
            var ret = ((DriveTypeDelegate)functionLoader.LoadFunction<DriveTypeDelegate>("DriveType"))(2); // 2 stands for C Drive
            Assert.True(ret == (int)System.IO.DriveType.Fixed);
        }
    }
}