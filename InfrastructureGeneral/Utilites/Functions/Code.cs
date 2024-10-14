using Infrastructure.Utilities.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainGeneral.Infrastructure.Utilities.Functions;
namespace InfrastructureGeneral.Utilites.Functions
{
    public  class Code : ICode
    {
        public  string GenerateCode() => new Random().Next().ToString();

        public  string GenerateCode(int length = 6)
        {
            if (length <= 0)
            {
                throw new ArgumentException("Length must be more");
            }

            
            Random random = new Random();
           
            var code = random.Next((int)Math.Pow(10, length - 1), (int)Math.Pow(10, length)).ToString();

            return code;
        }



    }
}
