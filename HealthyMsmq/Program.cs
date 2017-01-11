using System;
using System.Runtime.InteropServices;

namespace HealthyMsmq
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Press any key to load the Mqrt.dll library");
                Console.ReadKey();

                var lres = LoadLibrary("Mqrt.dll");
                Console.WriteLine("Done with result {0}", lres);
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} - {1}", ex.Message, ex.StackTrace);
            }
            finally
            {
                Console.WriteLine("Press any key to exit ...");
                Console.ReadKey();
            }
        }

        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string dllToLoad);
    }
}
