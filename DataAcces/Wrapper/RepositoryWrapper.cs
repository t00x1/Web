﻿using DataAccess.Interfaces;
using DataAccess.Models;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private Inspireo _repoContext;
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
        public RepositoryWrapper(Inspireo repositoryConext) 
        {
            _repoContext = repositoryConext;

        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
