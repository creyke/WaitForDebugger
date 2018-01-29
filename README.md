# WaitForDebugger
Adds the ability to easily wait for a debugger connection before a .NET Core application executes.

# Usage
1. Add a reference to the the WaitForDebugger project (no NuGet currently).

2. Add the following line to the top of your Program.cs `Main()` method:
```
    class Program
    {
        static void Main(string[] args)
        {
            DebuggerAwaiter.Wait(args);
        }
    }
```

3. Pass the argument '-waitfordebugger' to your application to have it wait for a local or remote debugger connection before continuing execution.

# Alternative Usage
You can also pass a boolean to the `Wait()` method if you require more granular control over when to wait for the debugger connection:
```
    class Program
    {
        static void Main(string[] args)
        {
            DebuggerAwaiter.Wait(true);
        }
    }
```

If you are going full async, you can of course do:
```
    class Program
    {
        static async Task Main(string[] args)
        {
            await DebuggerAwaiter.WaitAsync(args);
        }
    }
```
