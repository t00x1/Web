using System;
using System.IO;
using System.Text;
using DomainGeneral;

namespace InfrastructureGeneral
{
    public class FileContentStreamReader : IFileContent
    {
        public string ReadFile(string relativePath) 
        {
            if (string.IsNullOrWhiteSpace(relativePath))
            {
                throw new ArgumentNullException(nameof(relativePath), "Путь не может быть пустым или null.");
            }

            if (relativePath.IndexOfAny(Path.GetInvalidPathChars()) >= 0)
            {
                throw new ArgumentException("Путь содержит недопустимые символы.", nameof(relativePath));
            }

            string fullPath = Path.GetFullPath(relativePath);

            if (fullPath.Length >= 260) 
            {
                throw new PathTooLongException("Путь слишком длинный.");
            }

            if (!File.Exists(fullPath))
            {
                throw new FileNotFoundException($"Файл по пути {fullPath} не найден.", fullPath);
            }

            try
            {
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