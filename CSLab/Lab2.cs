
// #if PRODUCTION
// using System.Security.Cryptography;
// using System.Text;

// namespace CSLab;

// public class Pupil(string name, int age)
// {
//     public int Age { get; set; } = age;
//     public string Name { get; set; } = name;

//     public virtual string ShowStudent()
//     {
//         return $"({Name}, {Age})";
//     }
//     public virtual void Study() { Console.WriteLine("Ученик учится"); }
//     public virtual void Read() { Console.WriteLine("Ученик читает"); }
//     public virtual void Write() { Console.WriteLine("Ученик пишет"); }
//     public virtual void Relax() { Console.WriteLine("Ученик отдыхает"); }
// }

// public class ExcelentPupil(string name, int age) : Pupil(name, age)
// {
//     public override void Study() { Console.WriteLine("Ученик-отличник учится"); }
//     public override void Read() { Console.WriteLine("Ученик-отличник читает"); }
//     public override void Write() { Console.WriteLine("Ученик-отличник пишет"); }
//     public override void Relax() { Console.WriteLine("Ученик-отличник отдыхает"); }
// }

// public class GoodPupil(string name, int age) : Pupil(name, age)
// {
//     public override void Study() { Console.WriteLine("Ученик-хорошист учится"); }
//     public override void Read() { Console.WriteLine("Ученик-хорошист читает"); }
//     public override void Write() { Console.WriteLine("Ученик-хорошист пишет"); }
//     public override void Relax() { Console.WriteLine("Ученик-хорошист отдыхает"); }
// }
// public class BadPupil(string name, int age) : Pupil(name, age)
// {
//     public override void Study() { Console.WriteLine("Ученик-троечник учится"); }
//     public override void Read() { Console.WriteLine("Ученик-троечник читает"); }
//     public override void Write() { Console.WriteLine("Ученик-троечник пишет"); }
//     public override void Relax() { Console.WriteLine("Ученик-троечник отдыхает"); }
// }
// public class Classroom(string name, params Pupil[] pupils)
// {
//     private readonly Pupil[] _pupils = pupils;
//     public string _name = name;

//     public Classroom(Pupil[] pupils) => _pupils = pupils

//     public static void ShowStudents(Pupil[] pupils)
//     {
//         Console.WriteLine("Класс учеников:");
//         for (int i = 0; i < pupils.Length; i++)
//         {
//             Console.WriteLine(pupils[i]);
//         }
//     }
// }

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

// public class Plane(decimal price, double speed, int year, int passengers, int hight) : Vehicle(price, speed, year)
// {
//     private int _passengers = passengers;

//     public double Hight { get; set; } = hight;

//     public int Passengers
//     {
//         get
//         {
//             return _passengers;
//         }
//         set
//         {
//             if (value >= 0)
//             {
//                 _passengers = value;
//             }
//         }
//     }

//     public override void Info()
//     {
//         Console.WriteLine($"Характеристики самолета:");
//         base.Info();
//         Console.WriteLine($"пассажиры - {Passengers}");
//         Console.WriteLine($"высота - {Hight}");
//     }
// }

// public class Ship(decimal price, double speed, int year, int passengers, int homePort) : Vehicle(price, speed, year)
// {
//     private int _passengers = passengers;

//     public double HomePort { get; set; } = homePort;

//     public int Passengers
//     {
//         get
//         {
//             return _passengers;
//         }
//         set
//         {
//             if (value >= 0)
//             {
//                 _passengers = value;
//             }
//         }
//     }

//     public override void Info()
//     {
//         Console.WriteLine($"Характеристики самолета:");
//         base.Info();
//         Console.WriteLine($"пассажиры - {Passengers}");
//         Console.WriteLine($"Порт приписки - {HomePort}");
//     }
// }

// public class DocumentWorker
// {
//     public virtual void OpenDocument()
//     {
//         Console.WriteLine("Документ открыт");
//     }

//     public virtual void EditDocument()
//     {
//         Console.WriteLine("Редактирование документа доступно в версии Pro");
//     }

//     public virtual void SaveDocument()
//     {
//         Console.WriteLine("Сохранение документа доступно в версии Pro");
//     }
// }

// // Безопасный метод сравнения
// public static class SecureComparer
// {
//     public static bool SecureCompare(string? a, string? b)
//     {
//         if (a == null) throw new ArgumentException("Значение null у a");
//         if (a == null) throw new ArgumentException("Значение nul у b");
//         return CryptographicOperations.FixedTimeEquals(
//             Encoding.UTF8.GetBytes(a),
//             Encoding.UTF8.GetBytes(b)
//         );
//     }
// }
// public class ProDocumentWorker : DocumentWorker
// {
//     //Massive of keys
//     private static string[] keys = { "b4ofpefF", "fppengk$083", "06m0jfYJlrn" };
//     //Compare method
//     public static bool KeyComparator(string? input)
//     {
//         for (int i = 0; i < keys.Length; ++i)
//         {
//             if (SecureComparer.SecureCompare(input, keys[i]))
//             {
//                 return true;
//             }
//         }
//         return false;
//     }

//     public override void OpenDocument()
//     {
//         base.OpenDocument();
//     }

//     public override void EditDocument()
//     {
//         Console.WriteLine("Документ отредактирован");
//     }

//     public override void SaveDocument()
//     {
//         Console.WriteLine("Документ сохранен в старом формате, сохранение в остальных форматах доступно в версии Expert");
//     }
// }


// public class ExpertDocumentWorker : DocumentWorker
// {
//     //Massive of keys
//     private static string[] keys = { "@)%*Ijjffie*HHFG", "K:C$#@#rger!GBG", ";g'prH*U6834t5" };
//     //Compare method
//     public static bool KeyComparator(string? input)
//     {
//         for (int i = 0; i < keys.Length; ++i)
//         {
//             if (SecureComparer.SecureCompare(input, keys[i]))
//             {
//                 return true;
//             }
//         }
//         return false;
//     }

//     public override void OpenDocument()
//     {
//         base.OpenDocument();
//     }

//     public override void EditDocument()
//     {
//         Console.WriteLine("Документ отредактирован");
//     }

//     public override void SaveDocument()
//     {
//         Console.WriteLine("Документ сохранен в новом формате");
//     }
// }
// class Program
// {
//     public static void Main()
//     {
//         DocumentWorker worker = GetDocumentWorker();

//         worker.OpenDocument();
//         worker.EditDocument();
//         worker.SaveDocument();
//     }

//         private static DocumentWorker GetDocumentWorker()
//     {
//         Console.WriteLine("Input version of DocumentWorker:");
//         string? inputVersion = Console.ReadLine();
//         //Pro
//         if (string.Equals(inputVersion, "Pro", StringComparison.OrdinalIgnoreCase))
//         {
//             Console.WriteLine("Input kewy for Pro version:");
//             string? inputKey = Console.ReadLine();
//             if (ProDocumentWorker.KeyComparator(inputKey))
//             {
//                 var worker = new ProDocumentWorker();
//                 Console.WriteLine("Pro версия активирована!");
//                 return worker;
//             }
//             else
//             {
//                 Console.WriteLine("Недействительный ключ, создается базовая версия");
//                 return new DocumentWorker();

//             }
//         }
//         //Expert
//         else if (string.Equals(inputVersion, "Expert", StringComparison.OrdinalIgnoreCase))
//         {
//             Console.WriteLine("Input kewy for Expert version:");
//             string? inputKey = Console.ReadLine();
//             if (ExpertDocumentWorker.KeyComparator(inputKey))
//             {
//                 var worker = new ExpertDocumentWorker();
//                 Console.WriteLine("Expert версия активирована!");
//                 return worker;
//             }
//             else
//             {
//                 Console.WriteLine("Недействительный ключ, создается базовая версия");
//                 return new DocumentWorker();
//             }
//         }//Base
//         else
//         {
//             return new DocumentWorker();
//         }
    
// }
// #endif