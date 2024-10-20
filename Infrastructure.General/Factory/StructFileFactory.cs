using DomainGeneral;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace InfrastructureGeneral
{
    public class StructFileFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public StructFileFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IStructFile GetStructFile(string fileType)
        {
            switch (fileType.ToLower())
            {
                case "json":
                    return _serviceProvider.GetService<JSONFile>();
                case "xml":
                    return _serviceProvider.GetService<XMLFile>();
                default:
                    throw new ArgumentException("Неподдерживаемый тип файла.");
            }
        }
    }
}