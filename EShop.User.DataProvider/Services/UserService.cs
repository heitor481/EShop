using EShop.Infra.Commnad.User;
using EShop.Infra.Events.User;
using EShop.Infra.Security;
using EShop.User.DataProvider.Extensions;
using EShop.User.DataProvider.Repositories;
using System.Threading.Tasks;

namespace EShop.User.DataProvider.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncrypter _encrypter;

        public UserService(IUserRepository userRepository, IEncrypter encrypter)
        {
            _userRepository = userRepository;
            _encrypter = encrypter;
        }

        public async Task<UserCreated> CreateUser(CreateUser input)
        {
            input.SetPassword(_encrypter);
            return await _userRepository.CreateUser(input);
        }

        public async Task<UserCreated> GetUSer(string username)
        {
            return await _userRepository.GetUserById(username);
        }
    }
}
