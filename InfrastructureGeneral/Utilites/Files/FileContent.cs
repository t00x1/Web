using InfrastructureGeneral.Utilites.Functions;
using System;
using System.IO;
using System.Text;

namespace InfrastructureGeneral.Utilites.Files
{
    public class FileContent
    {
        public string ReadFile(string path)
        {
            // Проверка входного параметра
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException(nameof(path), "Путь не может быть пустым или null.");
            }

            string fullPath = Path.GetFullPath(path);
            Console.WriteLine("Полный путь к файлу: " + fullPath);

            try
            {
                // Чтение файла с использованием StreamReader
                using (var reader = new StreamReader(fullPath, Encoding.UTF8))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException("Файл не найден.", ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new UnauthorizedAccessException("Доступ к файлу запрещён.", ex);
            }
            catch (DirectoryNotFoundException ex)
            {
                throw new DirectoryNotFoundException("Директория не найдена.", ex);
            }
            catch (PathTooLongException ex)
            {
                throw new PathTooLongException("Путь к файлу слишком длинный.", ex);
            }
            catch (IOException ex)
            {
                throw new IOException("Ошибка при чтении файла.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Неизвестная ошибка при чтении файла.", ex);
            }
        }
    }
}
