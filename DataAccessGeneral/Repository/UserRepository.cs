using DataAccess.ModelsDB;
using DomainGeneral.Interfaces.Repository.DataAccess;
namespace DataAccess.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(InspireoContext repositoryConetext) : base(repositoryConetext) { }
    }
}
