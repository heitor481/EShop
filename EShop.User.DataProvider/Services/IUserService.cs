using EShop.Infra.Commnad.User;
using EShop.Infra.Events.User;
using System.Threading.Tasks;

namespace EShop.User.DataProvider.Services
{
    public interface IUserService
    {
        Task<UserCreated> GetUSer(string username);
        Task<UserCreated> CreateUser(CreateUser input);
    }
}
