using DomainGeneral;
using System;
using System.IO;
using System.Text;
using System.Text.Json;

namespace InfrastructureGeneral
{
    public class JSONFile<T> : IStructFile<T> where T : class
    {
        public JSONFile(string path)
        {
            _path = path;
        }
        public T Model { get; private set; }
        private string _path;


        public void Read()
        {
            try
            {
                FileContent fileContent = new FileContent();

                Model = JsonSerializer.Deserialize<T>(fileContent.ReadFile(_path));
            }
            
            catch (Exception ex)
            {
                throw;
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
