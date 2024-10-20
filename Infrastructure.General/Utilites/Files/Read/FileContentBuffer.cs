using System;
using System.IO;
using System.Text;
using DomainGeneral;

namespace InfrastructureGeneral
{
    public class FileContentBuffer : IFileContent
    {
        private readonly int _bufferSize;

        public FileContentBuffer(int bufferSize = 1024)
        {
            _bufferSize = bufferSize;
        }

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

            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string fullPath = Path.GetFullPath(Path.Combine(basePath, relativePath));

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
                StringBuilder contentBuilder = new StringBuilder();

                using (var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                using (var reader = new StreamReader(stream, Encoding.UTF8, true, _bufferSize, true))
                {
                    char[] buffer = new char[_bufferSize];
                    int bytesRead;

                    while ((bytesRead = reader.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        contentBuilder.Append(buffer, 0, bytesRead);
                    }
                }

                return contentBuilder.ToString();
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