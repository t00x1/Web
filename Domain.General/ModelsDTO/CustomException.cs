using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainGeneral
{
   
        public class CustomException
        {
            public string Message { get; set; }
            public string StackTrace { get; set; }
     

            public CustomException(Exception ex)
            {
                Message = ex.Message;
                StackTrace = ex.StackTrace;
                
            }
        }
    
}
