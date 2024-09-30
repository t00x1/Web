using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businessLogic.Services
{
    public interface IImageService
    {
        public void UploadImageAsync(ImageUploadDto file);
    }
}
