using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Utilities
{
    public class CodeWindows : ICode
    {
        public CodeWindows() 
        {
            
        }
        public string GenerateCode() // можно будет потом врапер сдеать
        {
            return Guid.NewGuid().ToString();
        }

    }
}
