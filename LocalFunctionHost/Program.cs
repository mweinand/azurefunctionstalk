using Microsoft.Azure.WebJobs.Script;
using System;
using Microsoft.Azure.WebJobs;
using System.Threading;
using System.Threading.Tasks;

namespace LocalFunctionHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ScriptHostConfiguration config = new ScriptHostConfiguration()
            {
                // path to root function script directory
                RootScriptPath = Environment.CurrentDirectory
            };

            config.HostConfig.UseTimers();

            var manager = new ScriptHostManager(config);
            manager.RunAndBlock();

            Console.ReadLine();
        }
    }
}
