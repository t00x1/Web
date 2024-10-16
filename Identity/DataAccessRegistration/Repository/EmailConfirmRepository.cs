using DataAccess.ModelsDB;
using Registration.DataAccess.Repositories;
using Registration.Domain.Interfaces.DataAccess;
using DomainRegistration.Interface.DataAccess;
using DataAccessGeneral.Repository;
namespace Registration.DataAccess.Repositories

{
    public class EmailConfirmRepository : RepositoryBase<EmailConfirmation>, IEmailConfirmRepository
    {
        public EmailConfirmRepository(InspireoContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
