namespace TripletFinder
{
    internal class FileReader
    {
        private readonly string _filePath;

        /// <summary>
        /// Инициализирует новый экземпляр класса FileReader с указанным путем к файлу.
        /// </summary>
        /// <param name="filePath">Путь к текстовому файлу.</param>
        /// <exception cref="ArgumentNullException">Вызывается, если filePath равен null.</exception>
        /// <exception cref="ArgumentException">Вызывается, если filePath является пустой строкой.</exception>
        /// <exception cref="FileNotFoundException">Вызывается, если файл по указанному пути не существует.</exception>
        public FileReader(string filePath)
        {
            if (filePath == null) throw new ArgumentNullException();
            if (filePath == "") throw new ArgumentException("Передана пустая строка");
            if(!File.Exists(filePath)) throw new FileNotFoundException();

           _filePath = filePath;
        }

        /// <summary>
        /// Читает строки из текстового файла и возвращает их в виде последовательности.
        /// </summary>
        /// <returns>Последовательность строк из текстового файла.</returns>
        public IEnumerable<string> ReadLineFromTxt()
        {
            string line;
            using var reader = File.OpenText(_filePath);
            
            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }
    }
}
