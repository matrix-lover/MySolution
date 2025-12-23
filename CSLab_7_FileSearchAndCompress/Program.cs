using System.IO;
using System.IO.Compression;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Поиск файла и сжатие ===\n");
            
        Console.Write("Введите путь для поиска(Enter - автоматически текущая)): ");
        string searchPath = Console.ReadLine();
        
        if (string.IsNullOrEmpty(searchPath))
            searchPath = Directory.GetCurrentDirectory();
        
        if (!Directory.Exists(searchPath))
        {
             Console.WriteLine($"Папка '{searchPath}' не существует!");
            return;
        }

        Console.Write("Введите имя файла для поиска: ");
        string fileName = Console.ReadLine();
            
        if (string.IsNullOrEmpty(fileName))
        {
            Console.WriteLine("Имя файла не указано!");
            return;
        }
        
        string[] files = Directory.GetFiles(searchPath, fileName, SearchOption.AllDirectories);

        if (files.Length == 0)
        {
            Console.WriteLine("Текстовые файлы не найдены");
            return;
        }
        
        string selectedFile = files[0];
        Console.WriteLine($"Найден файл: {selectedFile}");
        
        //Output
        Console.WriteLine("\nСодержимое файла:");
        using (FileStream fs = new FileStream(selectedFile, FileMode.Open))
        using (StreamReader reader = new StreamReader(fs))
        {
            Console.WriteLine(reader.ReadToEnd());
        }
        
        string compressedFile = selectedFile + ".gz";
        using (FileStream sourceStream = new FileStream(selectedFile, FileMode.Open))
        using (FileStream targetStream = File.Create(compressedFile))
        using (GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress))
        {
            sourceStream.CopyTo(compressionStream);
        }
        
        Console.WriteLine($"\nФайл сжат: {compressedFile}");
    }
}
