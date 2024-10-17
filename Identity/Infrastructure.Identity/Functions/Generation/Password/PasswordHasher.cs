using DomainGeneral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureGeneral
{
    public class PasswordHasher
    {
        private readonly IPasswordHashingAlgorithm _hashingAlgorithm;
        public PasswordHasher(IPasswordHashingAlgorithm hashingAlgorithm)
        {
            _hashingAlgorithm = hashingAlgorithm;
        }
        public string HashPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password cannot be null, empty, or consist only of white-space characters", nameof(password));
            }

            return _hashingAlgorithm.Hash(password);
        }
        public bool VerifyPassword(string enteredPassword, string storedHashedPassword)
        {
            if (string.IsNullOrWhiteSpace(enteredPassword) || string.IsNullOrWhiteSpace(storedHashedPassword))
            {
                throw new ArgumentException("Passwords cannot be null, empty, or consist only of white-space characters");
            }

            return _hashingAlgorithm.Verify(enteredPassword, storedHashedPassword);
        }
    }
}
