## Задание
### Необходимо написать консольное приложение на C#, выполняющее частотный анализ текста.
- Входные параметры: путь к текстовому файлу.
- Выходные результаты: вывести на экран 10 самых часто встречающихся в тексте триплетов (3 идущих подряд буквы слова) и число их повторений, и на последней строке время работы программы в миллисекундах.
- Требования: программа должна обрабатывать текст в многопоточном режиме.

## Решение
**[FileReader](https://github.com/geras-source/TripletFinder/blob/master/TripletFinder/FileReader.cs)** - класс-помощник, реализующий метод чтения строки из текстового файла по мере необходимости.

**[TripletFinder](https://github.com/geras-source/TripletFinder/blob/master/TripletFinder/TripletFinder.cs)** - основной класс, реализующий два метода: подсчет триплетов и вывод информации в консоль.

В репозитории находится тестовый файл с текстом. Вывод с использованием данного файла:

Введите путь к файлу: C:\test.txt
| :---: |
№: 1     Триплет: ост.   Количество повторений: 23846
№: 2     Триплет: что.   Количество повторений: 23352
№: 3     Триплет: ать.   Количество повторений: 23072
№: 4     Триплет: про.   Количество повторений: 21116
№: 5     Триплет: его.   Количество повторений: 20936
№: 6     Триплет: ого.   Количество повторений: 19490
№: 7     Триплет: ста.   Количество повторений: 19126
№: 8     Триплет: мен.   Количество повторений: 18794
№: 9     Триплет: ала.   Количество повторений: 18662
№: 10    Триплет: оль.   Количество повторений: 17600
Время выполнения: 1452мс.

### При измененном алгоритме 
Время выполнения 312мс.
Занимаяемая память ~31мб 
**При старом варианте алгоритма ~35мб**
