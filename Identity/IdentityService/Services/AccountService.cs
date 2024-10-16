using Grpc.Core;
using Microsoft.Extensions.Logging;

using DomainGeneral;
using DomainIdentity;
namespace IdentityService.Services
{
    public class AccountService : Account.AccountBase
    {
        private readonly IUserLogic _userLogic;
        private readonly ILogger<AccountService> _logger;

        public AccountService(IUserLogic userLogic, ILogger<AccountService> logger)
        {
            _userLogic = userLogic;
            _logger = logger;
        }

        public override async Task<RegistrationResponde> Registration(UserDataRequest request, ServerCallContext context)
        {
            // Проверка входных данных
            if (request == null)
            {
                _logger.LogError("Received null UserDataRequest");
                return new RegistrationResponde
                {
                    Success = false,
                    Message = "User data cannot be null."
                };
            }

            try
            {
               
                var userDto = MapToUserDto(request);

                // Создание пользователя
                await _userLogic.Create(userDto);

                // Возвращаем успешный ответ
                return new RegistrationResponde
                {
                    Success = true,
                    Message = "Operation successful"
                };
            }
            catch (Exception ex)
            {
                // Логирование ошибки и возвращение сообщения об ошибке
                _logger.LogError(ex, "Error in Registration method");
                return new RegistrationResponde
                {
                    Success = false,
                    Message = "An error occurred during registration."
                };
            }
        }

        private Userdto MapToUserDto(UserDataRequest request)
        {
            return new Userdto
            {
                UserName = request.Username,
                Name = request.Name,
                Surname = request.Surname,
                Patronymic = request.Patronymic,
                Password = request.Password,
                Email = request.Email,
                Male = request.Male
            };
        }
    }
}