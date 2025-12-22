// public class Vehicle
// {
//     private readonly decimal _price;
//     private double _speed;
//     private readonly int _year;

//     public decimal Price { get; }
//     public double Speed
//     {
//         get
//         {
//             return _speed;
//         }
//         set
//         {
//             if (value is >= 0 and < 700)
//             {
//                 _speed = value;
//             }
//         }
//     }

//     public Vehicle(decimal price, double speed, int year)
//     {
//         _price = price;
//         _speed = speed;
//         _year = year;
//         Console.WriteLine($"Характеристики машины: цена - {price}, скорость - {speed}, год - {year}");

//     }
//     public virtual void Info()
//     {
//         Console.WriteLine($"цена - {Price}");
//         Console.WriteLine($"скорость - {Speed}");
//         Console.WriteLine($"год - {_year}");
//     }
// }

// public class Car(decimal price, double speed, int year) : Vehicle(price, speed, year)
// {
//     public override void Info()
//     {
//         Console.WriteLine($"Характеристики машины:");
//         base.Info();
//     }
// }

// class Program
// {
//     static void Main()
//     {
//     }
// }