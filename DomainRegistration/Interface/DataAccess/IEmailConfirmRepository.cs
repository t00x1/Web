using DataAccess.ModelsDB;
using DataAccessGeneral.Repository;
using DomainGeneral.Interfaces.Repository.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainRegistration.Interface.DataAccess
{
    public interface IEmailConfirmRepository : IRepositoryBase<EmailConfirmation>
    {

    }
}
