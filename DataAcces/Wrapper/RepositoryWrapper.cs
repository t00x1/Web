using Domain.Interfaces;
using Domain.Models;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private Inspireo _repoContext;
        private IUserRepository _user;
        private IImageRepository _image;
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
        public IImageRepository Image
        {
            get
            {
                if (_image == null)
                {
                    _image = new ImageRepository(_repoContext);
                    return _image;
                }
                return _image;

            }
        }
        public RepositoryWrapper(Inspireo repositoryConext)
        {
            _repoContext = repositoryConext;

        }

        public  void Save()
        {
             _repoContext.SaveChanges();
        }
    }
}
