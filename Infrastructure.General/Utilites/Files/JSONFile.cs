using DomainGeneral;
using System;
using System.IO;
using System.Text;
using System.Text.Json;

namespace InfrastructureGeneral
{
    public class JSONFile : IStructFile 
    {
        public JSONFile(IFileContent fileContent)
        {

          
            _fileContent = fileContent;
        }
        private IFileContent _fileContent ;
       
       


        public T Read<T>(string path) where T : class
{
    try
    {
        string fileContent = _fileContent.ReadFile(path);
        return JsonSerializer.Deserialize<T>(fileContent);
        
    }
    catch (Exception ex)
    {
        throw new InvalidOperationException("Ошибка при чтении файла", ex);
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
