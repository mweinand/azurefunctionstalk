using System;
using System.Threading;
using Microsoft.Azure.WebJobs.Host;

public static void Run(string myQueueItem, TraceWriter log)
{
    log.Info($"C# Queue trigger function processed: {myQueueItem} on {Environment.MachineName}");
    Thread.Sleep(5000); // simulate processing time
}