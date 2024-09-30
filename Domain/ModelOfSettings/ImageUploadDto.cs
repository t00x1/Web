using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ModelOfSettings
{
    public class ImageUploadDto
    {
        public string FileName { get; set; }
        public Stream Content { get; set; }
        public long Size { get; set; }
    }
}
