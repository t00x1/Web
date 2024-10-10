using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainGeneral.Interfaces.Repository.DataAccess;
using Registration.Domain.Interfaces.DataAccess;
namespace Registration.Domain.Interfaces.Wrapper
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
       
         Task Save();
    }
}
