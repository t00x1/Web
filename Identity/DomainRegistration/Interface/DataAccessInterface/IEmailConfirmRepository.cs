using DataAccess.ModelsDB;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainGeneral.Interfaces.Repository.DataAccess;
namespace DomainRegistration.Interface.DataAccess
{
    public interface IEmailConfirmRepository : IRepositoryBase<EmailConfirmation>
    {

    }
}
