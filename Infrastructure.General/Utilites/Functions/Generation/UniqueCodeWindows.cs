using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainGeneral;
namespace InfrastructureGeneral
{
    public class UniqueCodeWindows : ICode
    {
        public UniqueCodeWindows() 
        {
            
        }
        public string GenerateCode() => Guid.NewGuid().ToString() + "-" +DateTime.UtcNow.ToString("yyyyMMddHHmm");
        

    }
}
