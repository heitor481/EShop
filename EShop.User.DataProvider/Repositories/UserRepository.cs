using EShop.Infra.Commnad.User;
using EShop.Infra.Events.User;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Threading.Tasks;

namespace EShop.User.DataProvider.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoDatabase _mongoDatabase;
        private readonly IMongoCollection<CreateUser> _mongoCollection;

        public UserRepository(IMongoDatabase mongoDatabase)
        {
            _mongoDatabase = mongoDatabase;
            _mongoCollection = _mongoDatabase.GetCollection<CreateUser>("User");
        }

        public async Task<UserCreated> CreateUser(CreateUser input)
        {
            await _mongoCollection.InsertOneAsync(input);
            return new UserCreated()
            {
                Username = input.Username,
                Id = input.Id,
            };
        }

        public async Task<UserCreated> GetUserById(string username)
        {
            var user = await _mongoCollection.AsQueryable().FirstOrDefaultAsync(x => x.Username == username);
            return new UserCreated() { Id = user?.Id, Username = user?.Username, Password = user.Password };
        }
    }
}
