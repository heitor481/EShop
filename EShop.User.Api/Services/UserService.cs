using EShop.Infra.Commnad.User;
using EShop.Infra.Events.User;
using EShop.User.Api.Repositories;
using System.Threading.Tasks;

namespace EShop.User.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserCreated> CreateUser(CreateUser input)
        {
            return await _userRepository.CreateUser(input);
        }

        public async Task<UserCreated> GetUSer(string username)
        {
            return await _userRepository.GetUserById(username);
        }
    }
}
