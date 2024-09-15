
using DataAccess.Repositories;
using System;
using DataAccess.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.Wrapper
{
    public interface IRepositoryWrapper
    {
        IUserRepository User {  get; }
        void Save();
    }
}
