using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainGeneral.Utilites.Functions;

namespace InfrastructureGeneral.Utilites.Functions
{
    public class PasswordHasher : IPasswordHasher
    {
        public string Generate(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password cannot be null, empty, or consist only of white-space characters");
            }

            return BCrypt.Net.BCrypt.EnhancedHashPassword(password);
        }
        public bool VerifyPassword(string enteredPassword, string storedHashedPassword)
        {

            return BCrypt.Net.BCrypt.Verify(enteredPassword, storedHashedPassword);
        }
    }

}
