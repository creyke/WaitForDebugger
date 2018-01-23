using System;

namespace WaitForDebugger.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            DebuggerAwaiter.Wait(args);
            
            Console.WriteLine("Hello World!");

            Console.Read();
        }
    }
}
