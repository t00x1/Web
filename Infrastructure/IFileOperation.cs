using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IFileOperation
    {
        public Task<bool> SaveFileFromStream(Stream stream, string path, string name);

    }
}
