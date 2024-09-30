using Domain.Functions.Files.InterfacesAbstract;
using System;
using System.Collections.Generic;

namespace Infrastructure.Repositories
{
    public class RepositoryJson<T> where T : class
    {
        private readonly JSONFile<T> _jsonFile;

        public RepositoryJson(string path)
        {
            _jsonFile = new JSONFile<T>(path);
            _jsonFile.Read();
        }

        public T? GetModel()
        {
            return _jsonFile.GetModel();
        }

        
    }
}
