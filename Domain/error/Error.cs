using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.error
{
    public class Codes
    {
        public enum ErrorCode
        {
            None = 0,
            FileNotFound = 404,
            InvalidFile = 400,
            ServerError = 500,
            EmptyFile = 1001
        }

    }
}
