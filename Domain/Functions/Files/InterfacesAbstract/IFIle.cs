using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Domain.Functions.Files.InterfacesAbstract
{
    public interface IFile 
    {
        public bool CheckExtension(ref string extension);
        public Task<bool> Upload();
    }
}
