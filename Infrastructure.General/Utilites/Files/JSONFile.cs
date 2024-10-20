using DomainGeneral;
using System;
using System.IO;
using System.Text;
using System.Text.Json;

namespace InfrastructureGeneral
{
    public class JSONFile : IStructFile 
    {
        public JSONFile()
        {

          
        
        }
  
       


        public T Get<T>(string JsonFile) where T : class
        {
            if (string.IsNullOrEmpty(JsonFile))
            {
                throw new ArgumentException($"{nameof(JsonFile)} равен null.");
            }

            try
            {
            
                T result = JsonSerializer.Deserialize<T>(JsonFile);

                if (result == null)
                {
                    throw new InvalidOperationException($"Десериализация объекта {typeof(T).Name} вернула null.");
                }

                return result;
            }
            catch (Exception ex)
            {
                
                throw new InvalidOperationException($"Ошибка при десериализация", ex);
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

      
    }
}
