using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainGeneral;

namespace InfrastructureGeneral
{
    public class BCryptPasswordHashingAlgorithm : IPasswordHashingAlgorithm
    {
        private readonly int _workFactor;

        public BCryptPasswordHashingAlgorithm(int workFactor = 12)
        {
            _workFactor = workFactor; 
        }

        public string Hash(string password)
        {
           
            string salt = BCrypt.Net.BCrypt.GenerateSalt(_workFactor);
           
            return BCrypt.Net.BCrypt.HashPassword(password, salt);
        }


        public bool Verify(string enteredPassword, string hashedPassword)
        {
           
            return BCrypt.Net.BCrypt.Verify(enteredPassword, hashedPassword);
        }
    }

}
