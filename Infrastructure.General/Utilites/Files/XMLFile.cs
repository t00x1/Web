using DomainGeneral;
using System;
using System.IO;
using System.Xml.Serialization;

namespace InfrastructureGeneral
{
    public class XMLFile : IStructFile
    {
        public XMLFile()
        {
        }

        public T Get<T>(string xmlFile) where T : class
        {
            if (string.IsNullOrEmpty(xmlFile))
            {
                throw new ArgumentException($"{nameof(xmlFile)} равен null.");
            }

            try
            {
                using (var reader = new StringReader(xmlFile))
                {
                    var serializer = new XmlSerializer(typeof(T));
                    var result = serializer.Deserialize(reader) as T;

                    if (result == null)
                    {
                        throw new InvalidOperationException($"Десериализация объекта {typeof(T).Name} вернула null.");
                    }

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Ошибка при десериализации", ex);
            }
        }

        /*public void Write(T model)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                using (var writer = new StringWriter())
                {
                    serializer.Serialize(writer, model);
                    File.WriteAllText(Path, writer.ToString());
                }
            }
            catch (Exception ex)
            {
                LogError("Ошибка при записи в файл", ex);
            }
        }*/
    }
}