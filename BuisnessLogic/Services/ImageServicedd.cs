/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Repositories;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Interfaces;
using Domain.Models;

namespace businessLogic.Services
{
    public class ImageService : IImageService
    {


       
        private IRepositoryWrapper _repositoryWrapper;
        public async Task CreateNewImage(Image Model)
        {
            await _repositoryWrapper.Image.Create(Model);
            _repositoryWrapper.Save();
        }
        public async Task EditImage(int id)
        {
            var Image = await _repositoryWrapper.Image.FindByCondition(x => x.IdOfImage == id);
            await _repositoryWrapper.Image.Update(Image.First());


            _repositoryWrapper.Save();
        }
        public async Task<Image> GetImage(int id)
        {

            var Img = await _repositoryWrapper.Image.FindByCondition(x => x.IdOfImage == id);
            return Img.First();
        }
    }
}
*/