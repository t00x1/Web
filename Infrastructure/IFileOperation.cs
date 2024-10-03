using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IFileOperation
    {
        public Task SaveFileFromStream(Stream stream, string extension, string name, string path);

    }
}
