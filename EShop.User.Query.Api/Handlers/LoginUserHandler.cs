using EShop.Infra.Commnad.User;
using EShop.Infra.Queries.User;
using EShop.Infra.Security;
using EShop.User.DataProvider.Extensions;
using EShop.User.DataProvider.Services;
using MassTransit;
using System.Threading.Tasks;

namespace EShop.User.Query.Api.Handlers
{
    public class LoginUserHandler : IConsumer<UserLogin>
    {
        private readonly IUserService _userService;
        private readonly IEncrypter _encrypter;

        public LoginUserHandler(IUserService userService, IEncrypter encrypter)
        {
            _userService = userService;
            _encrypter = encrypter;
        }

        public async Task Consume(ConsumeContext<UserLogin> context)
        {
            var user = await _userService.GetUSer(context.Message.Username);

            if (user != null) 
            {
                var isAllowed = user.ValidatePassowrd(_encrypter, user);

                if (isAllowed) 
                {
                    
                }
            }

            await context.RespondAsync(user);
        }
    }
}
