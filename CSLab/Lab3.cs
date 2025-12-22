
// namespace CSLab;

// public struct Vector
// {
//     public readonly double X;
//     public readonly double Y;
//     public readonly double Z;

//     public Vector(double x, double y, double z)
//     {
//         X = x;
//         Y = y;
//         Z = z;
//     }

//     public double VecLength => Math.Sqrt(X * X + Y * Y + Z * Z);

//     // Операторы сложения и вычитания
//     public static Vector operator +(Vector a, Vector b)
//         => new Vector(a.X + b.X, a.Y + b.Y, a.Z + b.Z);

//     public static Vector operator -(Vector a, Vector b)
//         => new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);

//     public static Vector operator -(Vector v)
//         => new Vector(-v.X, -v.Y, -v.Z);

//     // Скалярное произведение
//     public double Dot(Vector other)
//     {
//         return X * other.X + Y * other.Y + Z * other.Z;
//     }
//     public static double operator *(Vector a, Vector b)
//         => a.Dot(b);

//     // Векторное произведение
//     public Vector Cross(Vector other) => new Vector(
//         Y * other.Z - Z * other.Y,
//         Z * other.X - Z * other.X,
//         X * other.Y - Y * other.X
//     );

//     public static Vector CrossProduct(Vector a, Vector b) => a.Cross(b);

//     // Операторы умножения
//     public static Vector operator *(Vector v, double scalar)
//         => new Vector(v.X * scalar, v.Y * scalar, v.Z * scalar);
//     public static Vector operator *(double scalar, Vector v)
//         => v * scalar;

//     // Логические операторы
//     public static bool operator ==(Vector a, Vector b)
//         => Math.Abs(a.VecLength - b.VecLength) < double.Epsilon;

//     public static bool operator !=(Vector a, Vector b)
//         => !(a == b);

//     public static bool operator <(Vector a, Vector b)
//         => a.VecLength < b.VecLength;

//     public static bool operator >(Vector a, Vector b)
//         => a.VecLength > b.VecLength;

//     public static bool operator <=(Vector a, Vector b)
//         => a.VecLength <= b.VecLength;

//     public static bool operator >=(Vector a, Vector b)
//         => a.VecLength >= b.VecLength;

//     //Equals и GetHashCode
//     public bool Equals(Vector other)
//         => this == other;

//     public override int GetHashCode()
//         => HashCode.Combine(X, Y, Z);

//     public override bool Equals(object? obj)
//         => obj is Vector other && this == other;
// }

// public class Car : IEquatable<Car>
// {
//     public string Name { get; }
//     public string Engine { get; }
//     public double MaxSpeed { get; }

//     public Car(string name, string engine, double maxSpeed)
//     {
//         Name = name;
//         Engine = engine;
//         MaxSpeed = maxSpeed;
//     }

//     public bool Equals(Car other)
//     {
//         return this.Name == other.Name;
//     }

//     public override string ToString()
//     {
//         return $"{Name}";
//     }
// }

// public class CarsCatalog
// {
//     Car[] catalog;

//     public CarsCatalog(Car[] cars) => catalog = cars;
//     // Индексатор
//     public string this[int index]
//     {
//         get => $"Модель: {catalog[index].Name}, Двигатель: {catalog[index].Name}";
//     }
// }

// public class Currency
// {
//     public decimal Value { get; set; }
//     public virtual string Name{ get;}

//     public Currency(decimal value)
//     {
//         Value = value;
//     }
// }

// public class CurrencyUSD : Currency
// {
//     public override string Name => "USD";

//     public CurrencyUSD(decimal value) : base(value) { }

//     public static explicit operator decimal(CurrencyUSD val)
//     {
//         return val.Value;
//     }
//     // USD -> EUR
//     public static explicit operator CurrencyEUR(CurrencyUSD usd)
//     {
//         decimal rate = 0.85M;
//         return new CurrencyEUR((decimal)usd * rate);
//     }
//     // USD -> RUB
//     public static explicit operator CurrencyRUB(CurrencyUSD usd)
//     {
//         decimal rate = 82.36M;
//         return new CurrencyRUB((decimal)usd * rate);
//     }
// }

// public class CurrencyEUR : Currency
// {
//     public override string Name => "EUR";

//     public CurrencyEUR(decimal value) : base(value) { }

//     public static explicit operator decimal(CurrencyEUR val)
//     {
//         return val.Value;
//     }
//     // EUR -> USD
//     public static explicit operator CurrencyUSD(CurrencyEUR eur)
//     {
//         decimal rate = 1.17M;
//         return new CurrencyUSD((decimal)eur * rate);
//     }
//     // EUR -> RUB
//     public static explicit operator CurrencyRUB(CurrencyEUR eur)
//     {
//         decimal rate = 96.70M;
//         return new CurrencyRUB((decimal)eur * rate);
//     }
// }

// public class Convertor
// {
//     public Currency Convert(Currency currency, string nameOfnewCurr)
//     {
//         if (nameOfnewCurr == "USD")
//         {
//             return new CurrencyUSD(4);
//         }

//         return new CurrencyUSD(4);
//     }
// }

// public class CurrencyRUB : Currency
// {
//     public override string Name => "RUB";

//     public CurrencyRUB(decimal value) : base(value) { }

//     public static explicit operator decimal(CurrencyRUB val)
//     {
//         return val.Value;
//     }
//     // RUB -> USD
//     public static explicit operator CurrencyUSD(CurrencyRUB eur)
//     {
//         decimal rate = 0.01M;
//         return new CurrencyUSD((decimal)eur * rate);
//     }
//     // RUB -> EUR
//     public static explicit operator CurrencyEUR(CurrencyRUB eur)
//     {
//         decimal rate = 0.012M;
//         return new CurrencyEUR((decimal)eur * rate);
//     }
// }



// class Program
// {
//     static void Main()
//     {

//         Vector v1 = new Vector(1, 2, 3);
//         Vector v2 = new Vector(4, 5, 6);

//         // Сложение
//         Vector sum = v1 + v2;
//         Console.WriteLine($"Сложение: {sum}");

//         // Умножение на скаляр
//         Vector scaled = v1 * 2.5;
//         Console.WriteLine($"Умножение на скаляр: {scaled}");

//         // Скалярное произведение
//         double dotProduct = v1 * v2;
//         Console.WriteLine($"Скалярное произведение: {dotProduct:F2}");

//         // Векторное произведение
//         Vector crossProduct = Vector.CrossProduct(v1, v2);
//         Console.WriteLine($"Векторное произведение: {crossProduct}");

//         // Логические операторы
//         Console.WriteLine($"v3 == v4: {v1 == v2}"); // False
//         Console.WriteLine($"v3 < v4: {v1 < v2}"); // True
//         Console.WriteLine($"v3 > v4: {v1 > v2}"); // False

//         // Проверка на равенство
//         Vector v3 = new Vector(3, 4, 0); // Длина = 5
//         Vector v4 = new Vector(0, 5, 0); // Длина = 5
//         Console.WriteLine($"Векторы с одинаковой длиной равны: {v3 == v4}");
//         CurrencyEUR eur1 = new CurrencyEUR(990);
//         Console.WriteLine($"В евро: {eur1}");
//         CurrencyRUB y = (CurrencyRUB)eur1;
//         Console.WriteLine($"В рублях: {y}");
//     }
// }