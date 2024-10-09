using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainGeneral.Interfaces.Repository.DataAccess;
namespace Domain.Interfaces.Wrapper
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
       
         void Save();
    }
}
