using SpaRNP.Analysis.API.Test;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;


const string uriApi = "http://localhost:5050";
const int second = 10;

swaggerClient client = new swaggerClient(uriApi, new HttpClient());

Console.WriteLine($"\nТест производительности WebAPI (host: {uriApi}\nВремя опроса {second} секунд.\n");


#region Test 1

Console.WriteLine($"Запуск теста получения данных.");

CancellationTokenSource cts = new CancellationTokenSource();

try
{
    cts.CancelAfter(TimeSpan.FromSeconds(second));
    var result = await RunTest(() =>
    {
        client.AnalysisAsync().Wait();        
    }, cts.Token);
    ShowResult(result, second);
}
catch
{
    cts.Dispose();
}

#endregion

#region Test 2

Console.WriteLine("\n\n");
Console.WriteLine($"Запуск теста рассчитать длительностей жизней пользователей.");

cts = new CancellationTokenSource();

try
{
    cts.CancelAfter(TimeSpan.FromSeconds(second));
    var result = await RunTest(() =>
    {
        client.CalculateAsync().Wait();
    }, cts.Token);
    ShowResult(result, second);
}
catch
{
    cts.Dispose();
}

#endregion

#region Test 3
Console.WriteLine("\n\n");
Console.WriteLine($"Запуск теста обновление данных.");

List<AnalysisUser> request = new()
{
    new()
    {
        Id = 1,
        RegisteredAt = DateTime.Now.AddDays(-10),
        ActiveAt = DateTime.Now.AddDays(-5)
    }
};

cts = new CancellationTokenSource();

try
{
    cts.CancelAfter(TimeSpan.FromSeconds(second));
    var result = await RunTest(() =>
    {
        client.SaveAsync(request).Wait();
    }, cts.Token);
    ShowResult(result, second);
}
catch
{
    cts.Dispose();
}


#endregion


void ShowResult(int result, int second) => Console.WriteLine($"\nReq/sec ({result}/{second}) result: {result / second}");

Task<int> RunTest(Action action, CancellationToken token)
{
    int result = 0;
    try
    {
        while (true)
        {
            token.ThrowIfCancellationRequested();
            action?.Invoke();
            result++;
        }
    }
    catch (OperationCanceledException)
    {
        return Task.FromResult(result);
    }
}
Console.WriteLine("\n");
Console.WriteLine("Press any key.");
Console.ReadLine();
