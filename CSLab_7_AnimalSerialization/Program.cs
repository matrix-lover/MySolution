using System;
using System.Xml.Serialization;
using AnimalLibrary;
using System.IO;


namespace AnimalSerialization
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("XML Сериализация Animal\n");

            Lion lion = new Lion("Африка", "Симба", true);

            Console.WriteLine("Создан объект:");
            Console.WriteLine($"Тип: {lion.GetType().Name}");
            Console.WriteLine($"Имя: {lion.Name}");
            Console.WriteLine($"Страна: {lion.Country}");
            Console.WriteLine($"Прячется: {lion.HideFromOtherAnimals}");
            Console.WriteLine($"Классификация: {lion.WhatAnimal}");

            //XML serialization
            XmlSerializer serializer = new XmlSerializer(typeof(Lion));

            string fileName = "animal.xml";
            using (FileStream stream = new FileStream(fileName, FileMode.Create))
            {
                serializer.Serialize(stream, lion);
            }

            Console.WriteLine($"\nОбъект сериализован в файл: {fileName}\n");

            //XML visualization
            Console.WriteLine("Содержимое XML:");
            Console.WriteLine(File.ReadAllText(fileName));

            Console.WriteLine("\n=== Демонстрация десериализации ===");
            using (FileStream stream = new FileStream(fileName, FileMode.Open))
            {
                Lion deserializedLion = (Lion)serializer.Deserialize(stream);
                Console.WriteLine($"Десериализован: {deserializedLion.Name}");
                Console.Write("Приветствие: ");
                deserializedLion.SayHello();
            }

        }
    }
}
