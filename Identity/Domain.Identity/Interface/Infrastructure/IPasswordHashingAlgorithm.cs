﻿namespace DomainGeneral
{
    public interface IPasswordHashingAlgorithm
    {
        string Hash(string password);
        public bool Verify(string enteredPassword, string hashedPassword);
    }
}