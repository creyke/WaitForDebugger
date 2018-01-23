using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace WaitForDebugger
{
    public static class DebuggerAwaiter
    {
        private const int RetryDelayMilliseconds = 1000;

        public static void Wait(string[] args)
        {
            WaitAsync(args).Wait();
        }

        public static async Task WaitAsync(string[] args)
        {
            if (args == null || !args.Contains("-waitfordebugger"))
            {
                return;
            }

            await WaitAsync(true);
        }

        public static void Wait(bool wait)
        {
            WaitForDebugger().Wait();
        }

        public static async Task WaitAsync(bool wait)
        {
            await WaitForDebugger();
        }

        private static async Task WaitForDebugger()
        {
            Console.WriteLine("Awaiting debugger connection...");

            while (!Debugger.IsAttached)
            {
                await Task.Delay(RetryDelayMilliseconds);
            }

            Console.WriteLine("...debugger connected!");
        }
    }
}
