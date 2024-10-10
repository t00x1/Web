using DataAccess.ModelsDB;
using DataAccessGeneral.Repository;
using Registration.Domain.Interfaces.DataAccess;
namespace Registration.DataAccess.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(InspireoContext repositoryConetext) : base(repositoryConetext) { }
    }
}
