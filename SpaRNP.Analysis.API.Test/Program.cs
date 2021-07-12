using SpaRNP.Analysis.API.Test;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;


const string uriApi = "http://localhost:5050";
swaggerClient client = new swaggerClient(uriApi, new HttpClient());

Console.WriteLine($"Запуск теста WebAPI (host: {uriApi})\n");
Stopwatch stopWatch = new Stopwatch();

#region Test 1
Console.WriteLine($"Запуск теста получения данных.");
stopWatch.Start();

var response = await client.AnalysisAsync();

stopWatch.Stop();

TimeSpan ts = stopWatch.Elapsed;

string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
Console.WriteLine($"Время ожидания {elapsedTime}\n");

Console.WriteLine("|    id    |    RegistredAt        |       ActiveAt         |");
foreach (var item in response)
{
    Console.WriteLine($"|    {item.Id}     |    {item.RegisteredAt.ToString("dd.MM.yyyy")}         |       {item.ActiveAt.ToString("dd.MM.yyyy")}        |");
}
#endregion

#region Test 2
Console.WriteLine("\n\n");
Console.WriteLine($"Запуск теста рассчитать длительностей жизней пользователей.");
stopWatch.Start();

var data = await client.CalculateAsync();

stopWatch.Stop();

ts = stopWatch.Elapsed;

elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
Console.WriteLine($"Время ожидания {elapsedTime}\n");
Console.WriteLine($"Результат: {data}");
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

stopWatch.Start();

await client.SaveAsync(request);

stopWatch.Stop();

ts = stopWatch.Elapsed;

elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
Console.WriteLine($"Время ожидания {elapsedTime}\n");
#endregion

Console.ReadLine();
 