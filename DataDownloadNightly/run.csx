using System;

public static async Task Run(TimerInfo myTimer, TraceWriter log, Stream outputBlob)
{
    log.Info($"C# Timer trigger function executed at: {DateTime.Now}");   
    var httpClient = new HttpClient();
    using(var download = await httpClient.GetStreamAsync("http://www.fdic.gov/bank/individual/failed/banklist.csv"))
    {
        await download.CopyToAsync(outputBlob);
    }    
}