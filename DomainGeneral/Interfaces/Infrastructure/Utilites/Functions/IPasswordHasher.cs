namespace DomainGeneral.Utilites.Functions
{
    public interface IPasswordHasher
    {
        string Generate(string password);
        bool VerifyPassword(string enteredPassword, string storedHashedPassword);
    }
}