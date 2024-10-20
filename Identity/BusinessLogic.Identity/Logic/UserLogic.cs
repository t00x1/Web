
using DataAccess.ModelsDB;
using DomainGeneral;

using DomainIdentity;

using InfrastructureGeneral;
using System.Linq.Expressions;
using System.Runtime;


namespace BusinessLogicIdentity
{
    public class UserLogic : IUserLogic
    {

        readonly private IRepositoryWrapper _repositoryWrapper;
        readonly private SettingWrapper _settings;
        readonly private IFileContent _fileContent;
        readonly private IPasswordHashingAlgorithm _passwordHashingAlgorithm;
        public UserLogic(IRepositoryWrapper repositoryWrapper, SettingWrapper settings, IFileContent fileContent,IPasswordHashingAlgorithm passwordHashingAlgorithm )

        {
           _settings = settings ?? throw new ArgumentNullException(nameof(settings));
            _fileContent = fileContent ?? throw new ArgumentNullException(nameof(fileContent));
            _repositoryWrapper = repositoryWrapper ?? throw new ArgumentNullException(nameof(repositoryWrapper));
            _passwordHashingAlgorithm = passwordHashingAlgorithm ?? throw new ArgumentNullException(nameof(passwordHashingAlgorithm));
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
                    Password = _passwordHashingAlgorithm.Hash(model.Password),
                  
                    
                    Avatar = null,
                  
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
                string HTML =  _fileContent.ReadFile(@"../../../../../Domain.General/Email/CodeEmailFormRegistration.html");
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
               
                throw(ex);
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
