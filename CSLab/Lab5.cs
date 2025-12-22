// using System;
// using System.Collections;
// using System.Collections.Generic;

// class MyMatrix
// {
//     private int[,] matrix;
//     private static Random random = new Random();
//     private static int minValue;
//     private static int maxValue;

//     public MyMatrix(int rows, int cols)
//     {
//         matrix = new int[rows, cols];
//     }

//     public static void InputRange()
//     {
//         Console.Write("Введите минимальное значение: ");
//         minValue = int.Parse(Console.ReadLine());

//         Console.Write("Введите максимальное значение: ");
//         maxValue = int.Parse(Console.ReadLine());
//     }

//     public void Fill()
//     {
//         for (int i = 0; i < matrix.GetLength(0); i++)
//         {
//             for (int j = 0; j < matrix.GetLength(1); j++)
//             {
//                 matrix[i, j] = random.Next(minValue, maxValue + 1);
//             }
//         }
//     }

//     public void ChangeSize(int newRows, int newCols)
//     {
//         int[,] newMatrix = new int[newRows, newCols];

//         int rowsToCopy = Math.Min(newRows, matrix.GetLength(0));
//         int colsToCopy = Math.Min(newCols, matrix.GetLength(1));

//         for (int i = 0; i < rowsToCopy; i++)
//         {
//             for (int j = 0; j < colsToCopy; j++)
//             {
//                 newMatrix[i, j] = matrix[i, j];
//             }
//         }

//         for (int i = 0; i < newRows; i++)
//         {
//             for (int j = 0; j < newCols; j++)
//             {
//                 if (i >= matrix.GetLength(0) || j >= matrix.GetLength(1))
//                 {
//                     newMatrix[i, j] = random.Next(minValue, maxValue + 1);
//                 }
//             }
//         }

//         matrix = newMatrix;
//     }

//     public void ShowPartialy(int startRow, int endRow, int startCol, int endCol)
//     {

//         startRow = Math.Max(0, startRow);
//         endRow = Math.Min(matrix.GetLength(0) - 1, endRow);
//         startCol = Math.Max(0, startCol);
//         endCol = Math.Min(matrix.GetLength(1) - 1, endCol);

//         Console.WriteLine($"Часть матрицы [{startRow}:{endRow}, {startCol}:{endCol}]:");

//         for (int i = startRow; i < endRow + 1; i++)
//         {
//             for (int j = startCol; j < endCol + 1; j++)
//             {
//                 Console.Write(matrix[i, j] + "\t");
//             }
//             Console.WriteLine();
//         }
//     }

//     public void Show()
//     {
//         Console.WriteLine("Полная матрица:");
//         for (int i = 0; i < matrix.GetLength(0); i++)
//         {
//             for (int j = 0; j < matrix.GetLength(1); j++)
//             {
//                 Console.Write(matrix[i, j] + "\t");
//             }
//             Console.WriteLine();
//         }
//     }

//     public int this[int row, int col]
//     {
//         get
//         {
//             if (row < 0 || row >= matrix.GetLength(0) ||
//                 col < 0 || col >= matrix.GetLength(1))
//                 throw new IndexOutOfRangeException("Индекс выходит за границы матрицы");

//             return matrix[row, col];
//         }
//         set
//         {
//             if (row < 0 || row >= matrix.GetLength(0) ||
//                 col < 0 || col >= matrix.GetLength(1))
//                 throw new IndexOutOfRangeException("Индекс выходит за границы матрицы");

//             matrix[row, col] = value;
//         }
//     }
// }


// // Задание 2
// public class MyList<T> : IEnumerable<T>
// {
//     private T[] _items;
//     private int _count;

//     public MyList()
//     {
//         _items = new T[4];
//         _count = 0;
//     }

//     public MyList(int capacity)
//     {
//         _items = new T[capacity];
//         _count = 0;
//     }

//     public int Count
//     {
//         get { return _count; }
//     }

//     public void Add(T item)
//     {
//         if (_count == _items.Length)
//         {

//             T[] newArray = new T[_items.Length * 2]; // Увеличиваем емкость в 2 раза

//             for (int i = 0; i < _items.Length; i++)
//             {
//                 newArray[i] = _items[i];
//             }

//             _items = newArray; // новый список
//         }

//         // Добавляем элемент
//         _items[_count] = item;
//         _count++;
//     }

//     public T this[int index]
//     {
//         get
//         {
//             if (index < 0 || index >= _count)
//                 throw new IndexOutOfRangeException($"Индекс {index} вне диапазона [0, {_count - 1}]");

//             return _items[index];
//         }
//         set
//         {
//             if (index < 0 || index >= _count)
//                 throw new IndexOutOfRangeException($"Индекс {index} вне диапазона [0, {_count - 1}]");

//             _items[index] = value;
//         }
//     }

//     public IEnumerator<T> GetEnumerator()
//     {
//         for (int i = 0; i < _count; i++)
//         {
//             yield return _items[i];
//         }
//     }
// }

// public class MyDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
// {
//     private TKey[] _keys;
//     private TValue[] _values;
//     private int _count;
    
//     public MyDictionary(int capacity = 4)
//     {
//         _keys = new TKey[capacity];
//         _values = new TValue[capacity];
//         _count = 0;
//     }
    
//     public int Count
//     {
//         get { return _count; }
//     }
    
//     public void Add(TKey key, TValue value)
//     {
//         // Проверка на конфликт ключей
//         for (int i = 0; i < _count; i++)
//         {
//             if (_keys[i].Equals(key))
//                 throw new ArgumentException($"Ключ '{key}' уже существует");
//         }
        
//         // Увеличиваем capacity
//         if (_count == _keys.Length)
//         {
//             int newCapacity = _keys.Length * 2;
//             Array.Resize(ref _keys, newCapacity);
//             Array.Resize(ref _values, newCapacity);
//         }
        
//         _keys[_count] = key;
//         _values[_count] = value;
//         _count++;
//     }
    
//     public TValue this[TKey key]
//     {
//         get
//         {
//             for (int i = 0; i < _count; i++)
//             {
//                 if (_keys[i].Equals(key))
//                     return _values[i];
//             }
//             throw new KeyNotFoundException($"Ключ '{key}' не найден");
//         }
//         set
//         {
//             // Ищем ключ
//             for (int i = 0; i < _count; i++)
//             {
//                 if (_keys[i].Equals(key))
//                 {
//                     _values[i] = value;
//                     return;
//                 }
//             }
            
//             // нет конфликта
//             Add(key, value);
//         }
//     }
    
//     public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
//     {
//         for (int i = 0; i < _count; i++)
//         {
//             yield return new KeyValuePair<TKey, TValue>(_keys[i], _values[i]);
//         }
//     }
// }



// class Program
// {
//     static void Main()
//     {
//         // Задание 1
//         MyMatrix.InputRange();

//         MyMatrix matrix = new MyMatrix(3, 4);
//         matrix.Fill();
//         matrix.Show();

//         Console.WriteLine();

//         matrix.ShowPartialy(0, 1, 1, 3);

//         Console.WriteLine();

//         Console.WriteLine("Изменяем размер матрицы на 4x5:");
//         matrix.ChangeSize(4, 5);
//         matrix.Show();

//         Console.WriteLine();

//         Console.WriteLine("Использование индексатора:");
//         Console.WriteLine($"matrix[0,0] = {matrix[0, 0]}");

//         Console.WriteLine();

//         Console.WriteLine("Перезаполняем матрицу:");
//         matrix.Fill();
//         matrix.Show();

//         // Задание 2
//         Console.WriteLine("=== Создание списка чисел ===");
//         MyList<int> numbers = new MyList<int>();
//         numbers.Add(1);
//         numbers.Add(2);
//         numbers.Add(3);
//         numbers.Add(4);
//         numbers.Add(5);

//         Console.WriteLine($"Количество элементов: {numbers.Count}");

//         Console.WriteLine("\n=== Использование индексатора ===");
//         Console.WriteLine($"Элемент с индексом 0: {numbers[0]}");
//         Console.WriteLine($"Элемент с индексом 3: {numbers[3]}");

//         numbers[1] = 25;
//         Console.WriteLine($"После изменения numbers[1] = {numbers[1]}");


//         Console.WriteLine("\n=== Создание списка строк ===");
//         MyList<string> words = new MyList<string>();
//         words.Add("Hello");
//         words.Add("World");
//         words.Add("!");

//         foreach (var num in numbers)
//         {
//             Console.Write(num + " ");
//         }
//         Console.WriteLine();

//         Console.WriteLine("\n=== Проверка обработки ошибок ===");
//         try
//         {
//             Console.WriteLine($"Попытка получить numbers[10]: {numbers[10]}");
//         }
//         catch (IndexOutOfRangeException ex)
//         {
//             Console.WriteLine($"Ошибка: {ex.Message}");
//         }

//         // Задание 3
//         Console.WriteLine("=== Создание словаря ===");
//         MyDictionary<string, int> ages = new MyDictionary<string, int>();
        
//         // Добавляем элементы
//         ages.Add("Анна", 25);
//         ages.Add("Иван", 30);
//         ages.Add("Мария", 28);
        
//         Console.WriteLine($"Всего элементов: {ages.Count}");
        
//         Console.WriteLine("\n=== Использование индексатора ===");
//         Console.WriteLine($"Возраст Анны: {ages["Анна"]}");
//         Console.WriteLine($"Возраст Ивана: {ages["Иван"]}");
        
//         ages["Мария"] = 29;
//         Console.WriteLine($"Новый возраст Марии: {ages["Мария"]}");
        
//         ages["Петр"] = 35;
//         Console.WriteLine($"Возраст Петра: {ages["Петр"]}");
//         Console.WriteLine($"Теперь элементов: {ages.Count}");
        
//         Console.WriteLine("\n=== Перебор всех элементов ===");
//         foreach (var pair in ages)
//         {
//             Console.WriteLine($"{pair.Key}: {pair.Value} лет");
//         }
        
//         try
//         {
//             ages.Add("Анна", 26); // Попытка добавить существующий ключ
//         }
//         catch (ArgumentException ex)
//         {
//             Console.WriteLine($"Ошибка: {ex.Message}");
//         }

//     }
// }