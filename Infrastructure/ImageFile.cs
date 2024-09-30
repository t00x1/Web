using Domain.Functions.Files.InterfacesAbstract;

using Domain.ModelOfSettings;
using System;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Domain.error;
using Infrastructure;
/*C: \Users\sasha\Desktop\Web\Infrastructure\ImageFile.cs*/
namespace businessLogic.functions.files.releases
{
    public class ImageFile : IFile
    {
        private readonly IFormFile File;
        private long? _maxImageLength;
        private readonly string[] allowedExtension = { ".png", ".jpg", ".jpeg" };

        public ImageFile(IFormFile file)
        {
            File = file;
        }

        private long? GetMaxImageLength()
        {
            if (_maxImageLength.HasValue)
            {
                return _maxImageLength;
            }

            try
            {
                IStructFile<SettingsModel> settings = new JSONFile<SettingsModel>("./Csettings.json");
                settings.Read();

                _maxImageLength = settings.GetModel().MaxLengthOfImage;
                Console.WriteLine($"Восстановленное значение MaxLengthOfImage: {_maxImageLength}");
                return _maxImageLength;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при десериализации: {ex.Message}");
                return null;
            }
        }

        public bool CheckExtension(ref string extension)
        {
            extension = extension.ToLower();
            return allowedExtension.Contains(extension);
        }

        public async Task<bool> Upload()
        {
            if (File == null || File.Length == 0)
                throw new Exception("Файл не был загружен или пуст.");

            Console.WriteLine(File.FileName);
            string filepath = "../../Images";

            try
            {
                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);
                    Console.WriteLine("Directory was created");
                }

                string Ext = Path.GetExtension(File.FileName);
                long? maxLength = GetMaxImageLength();

                if (!CheckExtension(ref Ext) || File.Length > maxLength)
                {
                    throw new Exception("Некорректный формат файла или превышен максимальный размер.");
                }

                if (!maxLength.HasValue)
                {
                    throw new Exception("Неверная конфигурация сервера");
                }

                filepath = Path.Combine(filepath, Guid.NewGuid().ToString() + Ext);

                using (var stream = new FileStream(filepath, FileMode.Create))
                {
                    await File.CopyToAsync(stream);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке файла: {ex.Message}");
                throw; //ээээ пускай
            }
        }

    }
}
/*
using Domain.Functions.Files.InterfacesAbstract;
using Domain.ModelOfSettings;
using Microsoft.AspNetCore.Http;

namespace businessLogic.Services
{
    public class ImageService
    {
        private readonly IFile _fileRepository;
        private readonly IStructFile<SettingsModel> _settingsRepository;

        public ImageService(IFile fileRepository, IStructFile<SettingsModel> settingsRepository)
        {
            _fileRepository = fileRepository;
            _settingsRepository = settingsRepository;
        }

        public async Task<bool> UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new Exception("Файл не был загружен или пуст.");
            }

            string extension = Path.GetExtension(file.FileName).ToLower();
            if (!_fileRepository.CheckExtension(ref extension))
            {
                throw new Exception("Неподдерживаемый формат файла.");
            }

            _settingsRepository.Read();
            var maxFileSize = _settingsRepository.GetModel()?.MaxLengthOfImage;

            if (maxFileSize.HasValue && file.Length > maxFileSize.Value)
            {
                throw new Exception("Размер файла превышает допустимый.");
            }

            return await _fileRepository.Upload();
        }
    }
}
*/