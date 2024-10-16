using DataAccess.ModelsDB;


using DomainIdentity;
using InfrastructureGeneral;
using DataAccessGeneral;
namespace DataAccessIdentity

{
    public class EmailConfirmRepository : RepositoryBase<EmailConfirmation>, IEmailConfirmRepository
    {
        public EmailConfirmRepository(InspireoContext repositoryContext) : base(repositoryContext)
        {
            
        }
    }
}
