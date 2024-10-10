
using DataAccess.ModelsDB;
using DomainGeneral.ModelsDTO;
using DomainGeneral.Infrastructure.Utilities.Functions;
using Registration.Domain.Interfaces.Service;
using Registration.Domain.Interfaces.Wrapper;
using InfrastructureGeneral.Utilites.Functions;
using Infrastructure.Utilities.Functions;


namespace Registration.BusinessLogic.Service
{
    public class UserService : IUserService
    {
       
        private IRepositoryWrapper _repositoryWrapper;

        public UserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<User>> GetAll()
        {
            return await _repositoryWrapper.User.FindAll();
        }


        public async Task<User> GetById(string id)
        {
            var user = await _repositoryWrapper.User
                .FindByCondition(x => x.IdOfUser == id);
            return user.First();
        }

        public async Task Create(UserDTO model)
        {
          
            var user = new User()
            {
                IdOfUser = new UniqueCodeWindows().GenerateCode(),
                UserName = model.UserName,
                Name = model.Name,
                Surname = model.Surname,
                Patronymic = model.Patronymic,
                Password = model.Password,
                Bio = model.Bio,
                Admin = model.Admin,
                Avatar = null,
                BirthDate = model.BirthDate,
                Email = model.Email,
                Location = model.Location,
                Male = model.Male,
                UpdatedAt = DateTime.UtcNow, 
                DeletedAt = null
            };

           
            await _repositoryWrapper.User.Create(user);

       
            await _repositoryWrapper.Save();
        }

        public async Task Update(User model)
        {
            await _repositoryWrapper.User.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(string id)
        {
            var user = await _repositoryWrapper.User
                .FindByCondition(x => x.IdOfUser == id);

            await _repositoryWrapper.User.Delete(user.First());
            _repositoryWrapper.Save();
        }

    }
}
