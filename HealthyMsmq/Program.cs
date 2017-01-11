using System;
using System.Runtime.InteropServices;

namespace HealthyMsmq
{
    class Program
    {
        static void Main(string[] args)
        {
            var msmq = IntPtr.Zero;
            try
            {
                Console.WriteLine("Press any key to check if MSMQ is installed");
                Console.ReadKey();

                msmq = LoadLibrary("mqrt.dll");
                Console.WriteLine("MSMQ is {0}installed", msmq == IntPtr.Zero? "not " : "");
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} - {1}", ex.Message, ex.StackTrace);
            }
            finally
            {
                FreeLibrary(msmq);
            }
            Console.WriteLine("Press any key to exit ...");
            Console.ReadKey();
       }

        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string dllToLoad);
        [DllImport("kernel32.dll")]
        public static extern bool FreeLibrary(IntPtr hModule);
    }
}
