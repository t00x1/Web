using Domain.Interfaces;
using Domain.Models;
/*using DataAccess.Repositories;*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(Inspireo repositoryConext) : base(repositoryConext) { }
    }
}
