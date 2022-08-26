using EShop.Infra.Commnad.User;
using EShop.Infra.Events.User;
using EShop.Infra.Security;
using EShop.User.Api.Extensions;
using EShop.User.Api.Repositories;
using System.Threading.Tasks;

namespace EShop.User.Api.Services
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
            var user = await GetUSer(input.Username);

            if (user != null)
            {
                throw new System.Exception("User is taken");
            }

            input.SetPassword(_encrypter);
            return await _userRepository.CreateUser(input);
        }

        public async Task<UserCreated> GetUSer(string username)
        {
            return await _userRepository.GetUserById(username);
        }
    }
}
