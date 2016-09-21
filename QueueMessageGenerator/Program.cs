using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Configuration;
using System.Threading;

namespace QueueMessageGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var storageCredentials = new StorageCredentials(ConfigurationManager.ConnectionStrings["QueueTargetSAS"].ConnectionString);
            CloudStorageAccount accountWithSAS = new CloudStorageAccount(storageCredentials, "mkeazurefunctions", "core.windows.net", true);
            var queueClient = accountWithSAS.CreateCloudQueueClient();
            var queueRef = queueClient.GetQueueReference("samplemessage");

            var counter = 0;

            while(true)
            {
                var content = $"Sample Content {counter++}";
                queueRef.AddMessage(new CloudQueueMessage(content));
                Console.WriteLine(content);
                //Thread.Sleep(1000);
            }
        }
    }
}
