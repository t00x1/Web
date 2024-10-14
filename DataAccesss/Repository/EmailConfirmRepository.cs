using DataAccess.ModelsDB;
using DataAccessGeneral.Repository;
using Registration.Domain.Interfaces.DataAccess;
using DomainRegistration.Interface.DataAccess;
namespace Registration.DataAccess.Repositories

{
    public class EmailConfirmRepository : RepositoryBase<EmailConfirmation>, IEmailConfirmRepository
    {
        public EmailConfirmRepository(InspireoContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
