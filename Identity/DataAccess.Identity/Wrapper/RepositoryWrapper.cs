using DataAccess.ModelsDB;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DomainIdentity;
using DomainGeneral;

namespace DataAccessIdentity
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private InspireoContext _repoContext;
        private IUserRepository _user;
        private EmailConfirmRepository _emailConfirmRepository;
        
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
        public IEmailConfirmRepository Email
        {
            get
            {
                if (_emailConfirmRepository == null)
                {
                    _emailConfirmRepository = new EmailConfirmRepository(_repoContext);
                    return _emailConfirmRepository;
                }
                return _emailConfirmRepository;
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
