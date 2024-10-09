using Domain.Interfaces;
using DomainGeneral.Interfaces.Repository.DataAccess;
using DataAccess.Repository;
using DataAccess.ModelsDB;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Domain.Interfaces.Wrapper;
namespace DataAccess.Wrapper
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

        public  void Save()
        {
             _repoContext.SaveChanges();
        }
    }
}
