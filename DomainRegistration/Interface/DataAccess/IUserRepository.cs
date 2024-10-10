

using System;
using DomainGeneral.Interfaces.Repository.DataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccess.ModelsDB;

namespace Registration.Domain.Interfaces.DataAccess
{
    public interface IUserRepository : IRepositoryBase<User>
    {
    }
}
