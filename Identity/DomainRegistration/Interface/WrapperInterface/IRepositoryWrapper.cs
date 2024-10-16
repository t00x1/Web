using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainGeneral.Interfaces.Repository.DataAccess;
using DomainRegistration.Interface.DataAccess;
using Registration.Domain.Interfaces.DataAccess;
namespace Registration.Domain.Interfaces.Wrapper
{
    public interface IRepositoryWrapper
    {
       public IUserRepository User { get; }
        public IEmailConfirmRepository Email { get; }

        Task Save();
    }
}
