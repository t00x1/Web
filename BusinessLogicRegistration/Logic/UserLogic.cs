
using DataAccess.ModelsDB;
using DomainGeneral.ModelsDTO;
using DomainGeneral.Infrastructure.Utilities.Functions;
using Registration.Domain.Interfaces.Service;
using Registration.Domain.Interfaces.Wrapper;
using InfrastructureGeneral.Utilites.Functions;
using Infrastructure.Utilities.Functions;
using System.Linq.Expressions;
using InfrastructureGeneral.Email;
using DomainGeneral.Email;

using InfrastructureGeneral.Utilites.Files;
using InfrastructureGeneral.Utilites.Functions.Password;
using System.Diagnostics;
using DomainRegistration.Interface.DataAccess;
using InfrastructureGeneral.Settings;
using System.Runtime;


namespace Registration.BusinessLogic.Service
{
    public class UserLogic : IUserLogic
    {

        private IRepositoryWrapper _repositoryWrapper;
        private SettingsModel _settings;

        public UserLogic(IRepositoryWrapper repositoryWrapper, SettingRead settings)

        {
            _settings = settings.Settings;
            
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
        
        public async Task Create(Userdto model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            try
            {
                var user = new User()
                {
                    IdOfUser = new UniqueCodeWindows().GenerateCode(),
                    UserName = model.UserName.Trim(),
                    Name = model.Name,
                    Surname = model.Surname,
                    Patronymic = model.Patronymic,
                    Password = new PasswordHasher(new BCryptPasswordHashingAlgorithm()).HashPassword(model.Password),
                  
                    
                    Avatar = null,
                    /*BirthDate = model.BirthDate,*/
                    Email = model.Email,
                   
                    Male = model.Male,
                    UpdatedAt = DateTime.UtcNow,
                    DeletedAt = null
                    
                };
                Expression<Func<User, bool>> predicate = x => x.UserName == user.UserName;
                var allUsers = await _repositoryWrapper.User.FindByCondition(predicate);
                if (allUsers.Count > 0)
                {
                    throw new Exception("Пользователь с таким именем уже существует.");
                }


                string code = new Code().GenerateCode(6);

                DateTime expiresCodeAt = DateTime.Now.AddMinutes(5);
                string HTML = await File.ReadAllTextAsync(@"../DomainGeneral/Email/CodeEmailFormRegistration.html");
                HTML = HTML.Replace("{Code}", code).Replace("{Valid}", expiresCodeAt.ToString("HH:mm"));
                new EmailYandex("InspireoService@yandex.ru", "gufhmplnvuingqli").SendCode(model.Email, HTML, "Подтвердите почту");

                await _repositoryWrapper.Email.Create(new EmailConfirmation()
                {
                    IdReq = new UniqueCodeWindows().GenerateCode(),
                    IdOfUser = user.IdOfUser,
                    Code = code,
                    Expire = expiresCodeAt,

                });



                await _repositoryWrapper.User.Create(user);
                await _repositoryWrapper.Save();
            }
            
            catch (Exception ex)
            {
               
                throw;
            }
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
