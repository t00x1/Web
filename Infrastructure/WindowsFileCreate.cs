using Infrastructure.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class WindowsFileCreate : IFileOperation
    {
        public async Task SaveFileFromStream(Stream stream, string extension, string name, string path = "/")
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"server: Директория была создана {path}");
                    Console.ResetColor();
                };
                var filePath = Path.Combine(path, name + extension);

            
                using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                
                    await stream.CopyToAsync(fileStream);

                }
                

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                throw;  
            }

        }
    }
}
