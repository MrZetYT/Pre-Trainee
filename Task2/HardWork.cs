using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

class HardWork
{
    public static string ProcessData(string dataName)
    {
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Запуск обработки {dataName} (синхронно)");
        Thread.Sleep(3000);
        return $"[{DateTime.Now:HH:mm:ss.fff}] Обработка {dataName} завершена за 3 секунды";
    }

    public static async Task<string> ProcessDataAsync(string dataName)
    {
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Запуск обработки {dataName} (асинхронно)");
        await Task.Delay(3000);
        return $"[{DateTime.Now:HH:mm:ss.fff}] Обработка {dataName} завершена за 3 секунды";
    }

    public static async Task Main()
    {
        string[] files = { "Файл 1", "Файл 2", "Файл 3" };

        Console.WriteLine("Синхронная работа");
        var syncStart = DateTime.Now;

        foreach (var file in files)
        {
            var result = ProcessData(file);
            Console.WriteLine(result);
        }
        Console.WriteLine($"Общее время синхронной обработки: {(DateTime.Now - syncStart).TotalSeconds:F1} сек.\n");

        Console.WriteLine("Асинхронная работа");
        var asyncStart = DateTime.Now;
        var tasks = files.Select(ProcessDataAsync).ToArray();
        var results = await Task.WhenAll(tasks);
        foreach (var result in results)
        {
            Console.WriteLine(result);
        }
        Console.WriteLine($"Общее время асинхронной обработки: {(DateTime.Now - asyncStart).TotalSeconds:F1} сек.");
    }
}
