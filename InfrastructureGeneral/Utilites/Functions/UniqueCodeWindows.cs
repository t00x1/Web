using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainGeneral.Infrastructure.Utilities.Functions;
namespace Infrastructure.Utilities.Functions
{
    public class UniqueCodeWindows : ICode
    {
        public UniqueCodeWindows() 
        {
            
        }
        public string GenerateCode() => Guid.NewGuid().ToString() + "-" +DateTime.UtcNow.ToString("yyyyMMddHHmmssfff");
        

    }
}
