using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
     public class ImageUploadDto
    {
        public string FileName { get; set; }
        public byte[] Content { get; set; }
        public long Size { get; set; }
    }
}
