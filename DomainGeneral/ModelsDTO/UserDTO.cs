namespace DomainGeneral.ModelsDTO
{
    public class Userdto
    {
        public string UserName { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string? Patronymic { get; set; }

        public string? Password { get; set; }

       /* public DateTime BirthDate { get; set; }*/

        public string Email { get; set; }

        public bool Male { get; set; }


    }


}
