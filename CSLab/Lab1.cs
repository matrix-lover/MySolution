
// namespace CSLab;

// class DatatipesLimit()
// {
//     public static void TipesLimits()
//     {
//         Console.WriteLine("Типы Данных и их величины\n");
//         Console.WriteLine($"int от {int.MinValue} до {int.MaxValue}");
//         Console.WriteLine($"uint от {uint.MinValue} до {uint.MaxValue}");
//         Console.WriteLine($"short от {short.MinValue} до {short.MaxValue}");
//         Console.WriteLine($"ushort от {ushort.MinValue} до {ushort.MaxValue}");
//         Console.WriteLine($"long от {long.MinValue} до {long.MaxValue}");
//         Console.WriteLine($"ulong от {ulong.MinValue} до {ulong.MaxValue}");
//         Console.WriteLine($"decimal от {decimal.MinValue} до {decimal.MaxValue}");
//         Console.WriteLine($"float от {float.MinValue} до {float.MaxValue}");
//         Console.WriteLine($"double от {double.MinValue} до {double.MaxValue}");
//     }
// }

// public class Rectangle
// {
//     private readonly double _sideA;
//     private readonly double _sideB;

//     public double Area => CalculateArea();
//     public double Perimeter => CalculatePerimeter();

//     public Rectangle(double sideA, double sideB)
//     {
//         if (sideA > 0 && sideB > 0)
//         {
//             _sideA = sideA;
//             _sideB = sideB;
//         }
//         else if (sideA == 0 || sideB == 0)
//         {
//             throw new ArgumentException("Сторона не может быть равна нулю");
//         }
//         else
//         {
//             throw new ArgumentOutOfRangeException("Сторона должна быть положительной");
//         }
//     }

//     private double CalculateArea()
//     {
//         return _sideA * _sideB;
//     }

//     private double CalculatePerimeter()
//     {
//         return (_sideA + _sideB) * 2;
//     }
// }

// public class Point
// {
//     private int _x;
//     private int _y;
//     public int X { get => _x; }
//     public int Y { get => _y; }

//     public Point(int x, int y)
//     {
//         _x = x;
//         _y = y;
//     }

//     public override string ToString()
//     {
//         return $"({X}, {Y})";
//     }

//     public static double LengthSide(Point a, Point b)
//     {
//         return Math.Sqrt(Math.Pow((a.X - b.X), 2) + Math.Pow((a.Y - b.Y), 2));
//     }
// }

// public class Figure
// {
//     private Point _point_1;
//     private Point _point_2;
//     private Point _point_3;
//     private Point? _point_4;
//     private Point? _point_5;

//     public string? Name { get; set; }
//     public Point P1 { get => _point_1; }
//     public Point P2 { get => _point_2; }
//     public Point P3 { get => _point_3; }
//     public Point? P4 { get => _point_4; }
//     public Point? P5 { get => _point_5; }

//     //Five points
//     public Figure(Point point_1, Point point_2, Point point_3, Point? point_4, Point? point_5)
//     {
//         _point_1 = point_1;
//         _point_2 = point_2;
//         _point_3 = point_3;
//         _point_4 = point_4;
//         _point_5 = point_5;
//     }
//     //Four points
//     public Figure(Point point_1, Point point_2, Point point_3, Point? point_4)
//         : this(point_1, point_2, point_3, point_4, null){}
//     //Three points
//     public Figure(Point point_1, Point point_2, Point point_3)
//         : this(point_1, point_2, point_3, null, null){}
//     //Perimeter
//     public double PerimeterCalculator()
//     {
//         double perimeter = Point.LengthSide(P1, P2);
//         perimeter += Point.LengthSide(P2, P3);

//         if (P4 == null)
//         {
//             perimeter += Point.LengthSide(P1, P3);
//             return perimeter;
//         }

//         perimeter += Point.LengthSide(P3, P4);

//         if (P5 == null)
//         {
//             perimeter += Point.LengthSide(P1, P4);
//             return perimeter;
//         }

//         perimeter += Point.LengthSide(P4, P5);
//         perimeter += Point.LengthSide(P1, P5);
//         return perimeter;
//     }
//     //Method for inputing more than one point
//     public static Point EnterPoint(int PNumber)
//     {
//         Console.WriteLine($"\nТочка {PNumber}");

//         Console.WriteLine($"Введите x:");
//         string? string_x = Console.ReadLine();

//         Console.WriteLine($"Введите y:");
//         string? string_y = Console.ReadLine();

//         int x = Convert.ToInt32(string_x);
//         int y = Convert.ToInt32(string_y);

//         return new Point(x, y);
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         //Number 1:
//         DatatipesLimit.TipesLimits();

//         //Number 2:
//         Console.WriteLine("Напишите длины сторон прямоугольника: ");
//         string? string_a = Console.ReadLine();
//         string? string_b = Console.ReadLine();

//         double a = Convert.ToDouble(string_a);
//         double b = Convert.ToDouble(string_b);

//         Rectangle rectangle1 = new Rectangle(a, b);

//         Console.WriteLine($"Площадь: {rectangle1.Area}");
//         Console.WriteLine($"Периметр: {rectangle1.Perimeter}");

//         //Number 3:
//         Console.WriteLine("Напишите координаты от трех до пяти точек");
//         Console.WriteLine("Введите координаты точек (от 3 до 5):");

//         Point p1 = Figure.EnterPoint(1);
//         Point p2 = Figure.EnterPoint(2);
//         Point p3 = Figure.EnterPoint(3);
//         Point? p4 = null;
//         Point? p5 = null;

//         Console.Write("Ввести 4-ю точку? (y/n): ");
//         if (Console.ReadLine() == "y")
//         {
//             p4 = Figure.EnterPoint(4);

//             Console.Write("Ввести 5-ю точку? (y/n): ");
//             if (Console.ReadLine() == "y")
//             {
//                 p5 = Figure.EnterPoint(5);
//             }
//         }
        
//         Figure figure = new Figure(p1, p2, p3, p4, p5);
//         Console.Write("Введите название фигуры: ");
//         figure.Name = Console.ReadLine();

//         Console.WriteLine($"Название: {figure.Name}");
//         Console.WriteLine($"Периметр: {figure.PerimeterCalculator()}");
//     }
// }