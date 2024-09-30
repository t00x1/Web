using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class WindowsFileCreate : IFileOperation
    {
        public async Task<bool> SaveFileFromStream(Stream stream, string path, string name)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                };
                var filePath = Path.Combine(path, Guid.NewGuid().ToString()  + name);

            
                using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                
                    await stream.CopyToAsync(fileStream);

                }
                Console.WriteLine("Норм");
                return true;

            }
            catch(Exception ex)
            {
                Console.WriteLine("Ошибка");
                return false;
            }
        }
    }
}
