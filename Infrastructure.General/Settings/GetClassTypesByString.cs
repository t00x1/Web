using System;
using System.Reflection;

namespace InfrastructureGeneral
{
    public class GetClassTypesByString
    {
        public object GetProperty<T>(T instance, string propertyName) where T : class
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            PropertyInfo property = typeof(T).GetProperty(propertyName);
            if (property == null)
            {
                throw new ArgumentException($"Свойство '{propertyName}' не найдено в типе '{typeof(T).Name}'.");
            }

            return property.GetValue(instance);
        }
    }
}