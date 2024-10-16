using System;
using System.IO;
using System.Text;

namespace InfrastructureGeneral
{
    public class FileContent
    {
        public string ReadFile(string relativePath)
        {
            // Проверка входного параметра
            if (string.IsNullOrWhiteSpace(relativePath))
            {
                throw new ArgumentNullException(nameof(relativePath), "Путь не может быть пустым или null.");
            }

            // Получение базового пути, который корректен для всех платформ
            string basePath = AppDomain.CurrentDomain.BaseDirectory;

            // Получаем полный путь, комбинируя базовый и относительный пути
            string fullPath = Path.Combine(basePath, relativePath);
            Console.WriteLine(fullPath);

            // Проверяем, существует ли файл
            if (!File.Exists(fullPath))
            {
                throw new FileNotFoundException($"Файл по пути {fullPath} не найден.");
            }

            try
            {
                // Чтение файла с использованием StreamReader
                using (var reader = new StreamReader(fullPath, Encoding.UTF8))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new UnauthorizedAccessException("Доступ к файлу запрещён.", ex);
            }
            catch (IOException ex)
            {
                throw new IOException("Ошибка при чтении файла.", ex);
            }
        }
    }
}
