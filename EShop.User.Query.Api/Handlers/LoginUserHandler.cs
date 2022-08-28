using EShop.Infra.Authentication;
using EShop.Infra.Commnad.User;
using EShop.User.DataProvider.Extensions;
using EShop.User.DataProvider.Services;
using MassTransit;
using System.Threading.Tasks;

namespace EShop.User.Query.Api.Handlers
{
    using EShop.Infra.Security;
    public class LoginUserHandler : IConsumer<UserLogin>
    {
        private readonly IUserService _userService;
        private readonly IEncrypter _encrypter;
        private readonly IAuthenticationHandler _authenticationHandler;

        public LoginUserHandler(IUserService userService, IEncrypter encrypter, IAuthenticationHandler authenticationHandler)
        {
            _userService = userService;
            _encrypter = encrypter;
            _authenticationHandler = authenticationHandler;
        }

        public async Task Consume(ConsumeContext<UserLogin> context)
        {
            var user = await _userService.GetUSer(context.Message.Username);

            if (user != null) 
            {
                var isAllowed = user.ValidatePassword(context.Message, _encrypter);

                if (isAllowed) 
                {
                    var token = _authenticationHandler.Create(user.Id);
                    await context.RespondAsync<JwtAuthToken>(token);
                }
            }

            await context.RespondAsync(null);
        }
    }
}
