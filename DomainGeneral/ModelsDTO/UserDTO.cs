namespace DomainGeneral.ModelsDTO
{
    public class UserDTO
    {
        public string IdOfUser { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string? Patronymic { get; set; }

        public string? Password { get; set; }

        public string? Bio { get; set; }

        public bool Admin { get; set; }

        public string? Avatar { get; set; }

        public DateTime BirthDate { get; set; }

        public string? Email { get; set; }

        public string? Location { get; set; }

        public bool Male { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }
    }


}
