
using Domain.Functions.Files.InterfacesAbstract;

using Domain.ModelOfSettings;
using System;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Repositories;
using Domain.error;
using Infrastructure;
using businessLogic.Services;
using Domain.Models;
using Domain.Interfaces;
using Infrastructure.Utilities;

namespace businessLogic.Service
{
    public class ImageService : IImageService
    {
        private IRepositoryWrapper _repositoryWrapper;
        private readonly string[] allowedExtension = { ".png", ".jpg", ".jpeg" };
        public ImageService(IRepositoryWrapper repositoryWrapper) {
            _repositoryWrapper = repositoryWrapper;
        }
        public bool CheckExtension(ref string extension)
        {
            extension = extension.ToLower();
            return allowedExtension.Contains(extension);
        }
       
       
        public long? MaxLength { get; } = new RepositoryJson<SettingsModel>("./Csettings.json").GetModel().MaxLengthOfImage;
        string? _extension;
        public async Task UploadImageAsync(ImageUploadDto file, string path)
        {
            try
            {
               _extension = Path.GetExtension(file.FileName);
                string newName = new CodeWindows().GenerateCode();
                Image image = new Image
                {
                    Directory = Path.Combine(path, newName + _extension)
                };
                Console.WriteLine(_extension);
                if (file == null ||   _extension == null || !CheckExtension(ref _extension))
                {

                    throw new Exception("Некорректный формат файла");
                    

                }
                if(file.Size > MaxLength ||  file.Size == 0)
                {
                    throw new Exception("Файл слишком большой файла");
                }
                var fileCreator = new WindowsFileCreate();
                await fileCreator.SaveFileFromStream(file.Content, _extension, newName, path );
                await _repositoryWrapper.Image.Create(image);
                _repositoryWrapper.Save();



            }
            catch (Exception ex) {
                throw;
            }




            

        }
        }

    }

 