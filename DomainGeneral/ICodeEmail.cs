using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainGeneral.Email
{
    public interface ICodeEmail
    {



        public void SendCode( string emailIn,  string HTML,  string subject);
        
        
    }
}
