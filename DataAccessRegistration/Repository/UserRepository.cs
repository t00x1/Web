using DataAccess.ModelsDB;


namespace Registration.DataAccess.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(InspireoContext repositoryConetext) : base(repositoryConetext) { }
    }
}
