using System.Collections.Concurrent;
using System.Text.RegularExpressions;

namespace TripletFinder
{
    internal class TripletFinder
    {
        /// <summary>
        /// Ищет и подсчитывает триплеты в указанном файле.
        /// </summary>
        /// <param name="path">Путь к файлу для анализа.</param>
        /// <returns>Последовательность из 10 самых часто встречающихся триплетов в порядке убывания частоты повторений.</returns>
        public IEnumerable<KeyValuePair<string, int>> FindTriplet(string path)
        {
            Regex regex = new(@"(?=(\p{L}{3}))");
            ConcurrentDictionary<string, int> triplets = new();
            try
            {
                FileReader file = new(path);

                Parallel.ForEach(
                    file.ReadLineFromTxt(),
                    new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount },
                    line =>
                    {
                        var matches = regex.Matches(line);
                        foreach (var match in matches.Cast<Match>())
                        {
                            triplets.AddOrUpdate(match.Groups[1].Value, 1, (_, count) => count + 1);
                        }
                    });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            var results = triplets.OrderByDescending(x => x.Value).Take(10);

            return results;

        }
        /// <summary>
        ///  Выводит на консоль информацию о триплетах и количестве их повторений.
        /// </summary>
        /// <param name="results">Результат обработки текста</param>
        public void PrintTriplets(IEnumerable<KeyValuePair<string, int>> results)
        {
            var number = 1;
            foreach (var triplet in results)
            {
                Console.WriteLine($"№: {number++}\t Триплет: {triplet.Key}.\t Количество повторений: {triplet.Value}");
            }
        }
    }
}
