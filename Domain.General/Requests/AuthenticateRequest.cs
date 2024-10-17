using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainGeneral
{
    public class AuthenticateRequest
    {
        [Required]
        [MaxLength(30)]
        public string Username { get; set; }
        [Required]
        [MaxLength(64)]
        public string Password { get; set; }
    }
}
