


using DataAccess.ModelsDB;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Registration.Domain.Interfaces.DataAccess;
using Registration.Domain.Interfaces.Wrapper;
using Registration.DataAccess.Repositories;

namespace Registration.DataAccess.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private InspireoContext _repoContext;
        private IUserRepository _user;
        
        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext);
                    return _user;
                }
                return _user;
            }
        }
       
        public RepositoryWrapper(InspireoContext repositoryConext)
        {
            _repoContext = repositoryConext;

        }

        public  async Task Save()
        {
           await  _repoContext.SaveChangesAsync();
        }
    }
}
