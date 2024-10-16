using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using DataAccess.ModelsDB;
using DomainGeneral.ModelsDTO;
namespace Registration.Domain.Interfaces.Service
{
    public interface IUserLogic
    {
        Task<List<User>> GetAll();

        Task<User> GetById(string id);
        Task Create(Userdto model);
        Task Update(User model);
        Task Delete(string id);
    }
}
