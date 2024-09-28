﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IImageService
    {
        Task CreateNewImage(Image Model);
        Task EditImage(int id);
        Task<Image> GetImage(int id);
       
    }
}
