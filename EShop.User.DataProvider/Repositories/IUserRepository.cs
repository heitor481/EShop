using EShop.Infra.Commnad.User;
using EShop.Infra.Events.User;
using System.Threading.Tasks;

namespace EShop.User.DataProvider.Repositories
{
    public interface IUserRepository
    {
        Task<UserCreated> CreateUser(CreateUser input);

        Task<UserCreated> GetUserById(string id);
    }
}
