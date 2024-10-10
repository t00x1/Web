using DomainGeneral.Interfaces.Infrastructure.Utilites.Files;
using System;
using System.IO;
using System.Text;
using System.Text.Json;

namespace InfrastructureGeneral.Utilites.Files
{
    public class JSONFile<T> : IStructFile<T> where T : class
    {
        public JSONFile(string path)
        {
            Path = path;
        }

        public string Path { get; }

        public T Model { get; private set; }

        public void Read()
        {
            StringBuilder result = new StringBuilder();

            try
            {
                using (var reader = new StreamReader(Path, Encoding.UTF8))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        result.Append(line);
                    }
                }

                Model = JsonSerializer.Deserialize<T>(result.ToString());
            }
            catch (FileNotFoundException ex)
            {
                LogError($"Файл не найден: {Path}", ex);
            }
            catch (IOException ex)
            {
                LogError("Ошибка при чтении файла", ex);
            }
            catch (JsonException ex)
            {
                LogError("Ошибка при десериализации JSON", ex);
            }
            catch (Exception ex)
            {
                LogError("Произошла ошибка", ex);
            }
        }

        /*public void Write(T model)
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(model);
                File.WriteAllText(Path, jsonString);
            }
            catch (Exception ex)
            {
                LogError("Ошибка при записи в файл", ex);
            }
        }*/

        public T? GetModel() => Model; // Метод для получения модели

        private void LogError(string message, Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{message}: {ex.Message}");
            Console.ResetColor();
        }
    }
}
