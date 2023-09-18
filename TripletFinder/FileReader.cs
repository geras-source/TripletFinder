using System.Text;

namespace TripletFinder
{
    internal class FileReader : IDisposable
    {
        private readonly FileStream _fileStream;
        private readonly StreamReader _streamReader;
        private const short BUFFER_SIZE = 4096;
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
            if (!File.Exists(filePath)) throw new FileNotFoundException();

            _fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            _streamReader = new StreamReader(_fileStream);
        }

        /// <summary>
        /// Читает по словам текстовый файл (слова считаются, если разделены символом пробела) 
        /// и возвращает их в виде последовательности.
        /// </summary>
        /// <returns>Последовательность строк из текстового файла.</returns>
        public IEnumerable<string> GetWordsFromFile()
        {
            var buffer = new char[BUFFER_SIZE]; // Размер буфера чтения
            var wordBuffer = new StringBuilder();

            while (!_streamReader.EndOfStream)
            {
                var bytesRead = _streamReader.Read(buffer, 0, buffer.Length);

                for (int i = 0; i < bytesRead; i++)
                {
                    var currentChar = buffer[i];

                    if (char.IsWhiteSpace(currentChar))
                    {
                        if (wordBuffer.Length > 0)
                        {
                            yield return wordBuffer.ToString();
                            wordBuffer.Clear();
                        }
                    }
                    else
                    {
                        wordBuffer.Append(currentChar);
                    }
                }
            }

            if (wordBuffer.Length > 0)
            {
                yield return wordBuffer.ToString();
            }
        }

        public void Dispose()
        {
            if (_fileStream != null)
            {
                _fileStream.Close();
                _fileStream.Dispose();
            }

            if (_streamReader != null)
            {
                _streamReader.Close();
                _streamReader.Dispose();
            }
        }
    }
}