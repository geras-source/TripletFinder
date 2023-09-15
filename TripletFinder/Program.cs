using System.Diagnostics;

namespace TripletFinder
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            TripletFinder finder = new();
            Console.Write("Введите путь к файлу: ");
            var filePath = Console.ReadLine();

            Stopwatch stopWatch = new();
            stopWatch.Start();

            var triplets = finder.FindTriplet(filePath);
            finder.PrintTriplets(triplets);

            stopWatch.Stop();
            var elapsedTime = stopWatch.Elapsed;
            Console.WriteLine($"Время выполнения: {elapsedTime.TotalMilliseconds:00}мс.");
        }
    }
}