using System;
using System.Xml.Serialization;
using AnimalLibrary;
using System.IO;


namespace AnimalDeserialization
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("XML Десериализация Animal\n");
            
            string fileName = "../CSLab_7_AnimalSerialization/animal.xml";
            
            if (!File.Exists(fileName))
            {
                Console.WriteLine($"Файл {fileName} не найден!");
                return 1;
            }
            
            // XML Deserialization
            XmlSerializer serializer = new XmlSerializer(typeof(Lion)); //for lion
            
            Animal animal; // for all inherited classes
            using (FileStream stream = new FileStream(fileName, FileMode.Open))
            {
                animal = (Animal)serializer.Deserialize(stream);
            }
            
            Console.WriteLine("Объект успешно десериализован!\n");
            Console.WriteLine("Данные объекта:");
            Console.WriteLine($"Тип: {animal.GetType().Name}");
            Console.WriteLine($"Имя: {animal.Name}");
            Console.WriteLine($"Страна: {animal.Country}");
            Console.WriteLine($"Прячется: {animal.HideFromOtherAnimals}");
            Console.WriteLine($"Классификация: {animal.WhatAnimal}");
            animal.SayHello();
            Console.WriteLine($"Любимая еда: {animal.GetFavoriteFood()}");
        }
    }
}