// using System.Collections.Generic;

// public class Matrix
// {
//     private double[,] matrix;
//     public int String { get; }
//     public int Columns { get; }

//     public Matrix(int rows, int columns, double minValue, double maxValue)
//     {
//         if (rows <= 0 || columns <= 0)
//             throw new ArgumentException("Отрицательное число строк или столбцов");

//         String = rows;
//         Columns = columns;
//         matrix = new double[rows, columns];
//         RandomVal(minValue, maxValue);
//     }

//     private void RandomVal(double minValue, double maxValue)
//     {
//         Random random = new Random();
//         for (int i = 0; i < String; i++)
//         {
//             for (int j = 0; j < Columns; j++)
//             {
//                 matrix[i, j] = minValue + (maxValue - minValue) * random.NextDouble();
//             }
//         }
//     }

//     public double this[int row, int column]
//     {
//         get
//         {
//             if (row < 0 || row >= String || column < 0 || column >= Columns)
//                 throw new IndexOutOfRangeException("Out of range");
//             return matrix[row, column];
//         }
//         set
//         {
//             if (row < 0 || row >= String || column < 0 || column >= Columns)
//                 throw new IndexOutOfRangeException("Out of range");
//             matrix[row, column] = value;
//         }
//     }

//     public static Matrix operator +(Matrix a, Matrix b)
//     {
//         if (a.String != b.String || a.Columns != b.Columns)
//             throw new ArgumentException("Unlike strings or columns");

//         Matrix result = new Matrix(a.String, a.Columns, 0, 0);

//         for (int i = 0; i < a.String; i++)
//         {
//             for (int j = 0; j < a.Columns; j++)
//             {
//                 result[i, j] = a[i, j] + b[i, j];
//             }
//         }
//         return result;
//     }

//     public static Matrix operator -(Matrix a, Matrix b)
//     {
//         if (a.String != b.String || a.Columns != b.Columns)
//             throw new ArgumentException("Unlike strings or columns");

//         Matrix result = new Matrix(a.String, a.Columns, 0, 0);
//         for (int i = 0; i < a.String; i++)
//         {
//             for (int j = 0; j < a.Columns; j++)
//             {
//                 result[i, j] = a[i, j] - b[i, j];
//             }
//         }
//         return result;
//     }

//     public static Matrix operator *(Matrix a, Matrix b)
//     {
//         if (a.Columns != b.String)
//             throw new ArgumentException("Number of strings in first matrix unlike nubmer of columns in second matrix");

//         Matrix result = new Matrix(a.String, b.Columns, 0, 0);

//         for (int i = 0; i < a.String; i++)
//         {
//             for (int j = 0; j < b.Columns; j++)
//             {
//                 double sum = 0;
//                 for (int k = 0; k < a.Columns; k++)
//                 {
//                     sum += a[i, k] * b[k, j];
//                 }
//                 result[i, j] = sum;
//             }
//         }
//         return result;
//     }

//     public static Matrix operator *(Matrix matrix, double scalar)
//     {
//         Matrix result = new Matrix(matrix.String, matrix.Columns, 0, 0);
        
//         for (int i = 0; i < matrix.String; i++)
//         {
//             for (int j = 0; j < matrix.Columns; j++)
//             {
//                 result[i, j] = matrix[i, j] * scalar;
//             }
//         }
//         return result;
//     }


//     public static Matrix operator *(double scalar, Matrix matrix)
//     {
//         return matrix * scalar;
//     }

//     public static Matrix operator /(Matrix matrix, double scalar)
//     {
//         if (scalar == 0)
//             throw new DivideByZeroException("Division by zero");
//             Matrix result = new Matrix(matrix.String, matrix.Columns, 0, 0);
//         for (int i = 0; i < matrix.String; i++)
//         {
//             for (int j = 0; j < matrix.Columns; j++)
//             {
//                 result[i, j] = matrix[i, j] / scalar;
//             }
//         }
//         return result;
//     }

//     public void Print()
//     {
//         for (int i = 0; i < String; i++)
//         {
//             for (int j = 0; j < Columns; j++)
//             {
//                 Console.Write($"{matrix[i, j]:F2}\t");
//             }
//             Console.WriteLine();
//         }
//     }
// }

// // Класс Car с авто-свойствами
// public class Car
// {
//     public string Name { get; set; }
//     public int ProductionYear { get; set; }
//     public int MaxSpeed { get; set; }

//     public Car(string name, int productionYear, int maxSpeed)
//     {
//         Name = name;
//         ProductionYear = productionYear;
//         MaxSpeed = maxSpeed;
//     }

//     public override string ToString()
//     {
//         return $"{Name} ({ProductionYear}), Макс. скорость: {MaxSpeed} км/ч";
//     }
// }

// // Класс для сравнения автомобилей с различными критериями сортировки
// public class CarComparer : IComparer<Car>
// {
//     public enum SortBy
//     {
//         Name,
//         ProductionYear,
//         MaxSpeed
//     }

//     private SortBy _sortCriteria;

//     public CarComparer(SortBy sortCriteria)
//     {
//         _sortCriteria = sortCriteria;
//     }

//     public int Compare(Car? x, Car? y)
//     {
//         if (x == null && y == null) return 0;
//         if (x == null) return -1;
//         if (y == null) return 1;

//         return _sortCriteria switch
//         {
//             SortBy.Name => string.Compare(x.Name, y.Name, StringComparison.Ordinal),
//             SortBy.ProductionYear => x.ProductionYear.CompareTo(y.ProductionYear),
//             SortBy.MaxSpeed => x.MaxSpeed.CompareTo(y.MaxSpeed),
//             _ => throw new ArgumentException("Неизвестный критерий сортировки")
//         };
//     }
// }




// class Program
// {
//     static void Main()
//     {
//         Console.WriteLine("Введите минимальное значение для случайных чисел:");
//         double minValue = double.Parse(Console.ReadLine());

//         Console.WriteLine("Введите максимальное значение для случайных чисел:");
//         double maxValue = double.Parse(Console.ReadLine());

//         Matrix matrix1 = new Matrix(2, 3, minValue, maxValue);

//         Console.WriteLine("\nМатрица 1:");
//         matrix1.Print();

//         Console.WriteLine("\nУмножение матрицы 1 на число 2:");
//         Matrix scaled = matrix1 * 2;
//         scaled.Print();

//         Console.WriteLine("\nДеление матрицы 1 на число 2:");
//         Matrix divided = matrix1 / 2;
//         divided.Print();

//         // Демонстрация индексатора
//         Console.WriteLine($"\nЭлемент [0,0] матрицы 1: {matrix1[0, 0]:F2}");
//         Console.WriteLine("Изменение элемента [0,0] на 10.0");
//         matrix1[0, 0] = 10.0;
//         Console.WriteLine($"Новое значение элемента [0,0]: {matrix1[0, 0]:F2}");

//         // Создание массива автомобилей
//         Car[] cars = {
//             new Car("Toyota Camry", 2020, 210),
//             new Car("BMW X5", 2018, 250),
//             new Car("Audi A4", 2022, 240),
//         };

//         Console.WriteLine("Исходный массив автомобилей:");
//         PrintCars(cars);

//         // Сортировка по названию
//         Console.WriteLine("\n--- СОРТИРОВКА ПО НАЗВАНИЮ ---");
//         Array.Sort(cars, new CarComparer(CarComparer.SortBy.Name));
//         PrintCars(cars);

//         // Сортировка по году выпуска
//         Console.WriteLine("\n--- СОРТИРОВКА ПО ГОДУ ВЫПУСКА ---");
//         Array.Sort(cars, new CarComparer(CarComparer.SortBy.ProductionYear));
//         PrintCars(cars);

//         // Сортировка по максимальной скорости
//         Console.WriteLine("\n--- СОРТИРОВКА ПО МАКСИМАЛЬНОЙ СКОРОСТИ ---");
//         Array.Sort(cars, new CarComparer(CarComparer.SortBy.MaxSpeed));
//         PrintCars(cars);


//         // Альтернативный способ с использованием лямбда-выражений
//         Console.WriteLine("\n--- СОРТИРОВКА ПО ГОДУ (ЛЯМБДА) ---");
//         Array.Sort(cars, (x, y) => x.ProductionYear.CompareTo(y.ProductionYear));
//         PrintCars(cars);

//         // Демонстрация с List
//         Console.WriteLine("\n--- РАБОТА СО СПИСКОМ ---");
//         List<Car> carList = new List<Car>(cars);

//         carList.Sort(new CarComparer(CarComparer.SortBy.Name));
//         Console.WriteLine("Список отсортирован по названию:");
//         foreach (var car in carList)
//         {
//             Console.WriteLine($"  {car}");
//         }
//     }

//     static void PrintCars(Car[] cars)
//     {
//         for (int i = 0; i < cars.Length; i++)
//         {
//             Console.WriteLine($"{i + 1}. {cars[i]}");
//         }
//     }
// }
