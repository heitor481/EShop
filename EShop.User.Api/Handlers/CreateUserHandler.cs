using EShop.Infra.Commnad.User;
using EShop.User.Api.Services;
using MassTransit;
using System.Threading.Tasks;

namespace EShop.User.Api.Handlers
{
    public class CreateUserHandler : IConsumer<CreateUser>
    {
        private readonly IUserService _userService;

        public CreateUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task Consume(ConsumeContext<CreateUser> context)
        {
            await _userService.CreateUser(context.Message);
            await Task.CompletedTask;
        }
    }
}
