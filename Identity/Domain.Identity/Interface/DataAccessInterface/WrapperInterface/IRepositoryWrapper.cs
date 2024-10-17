using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainIdentity
{
    public interface IRepositoryWrapper
    {
       public IUserRepository User { get; }
        public IEmailConfirmRepository Email { get; }

        Task Save();
    }
}
