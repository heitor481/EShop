using EShop.Infra.Commnad.User;
using EShop.Infra.Events.User;
using EShop.Infra.Security;

namespace EShop.User.DataProvider.Extensions
{
    public static class CryptoExtension
    {
        public static CreateUser SetPassword(this CreateUser user, IEncrypter encrypter) 
        {
            var salt = encrypter.GetSalt();
            user.Password = encrypter.GetHash(user.Password, salt);
            return user;
        }

        public static bool ValidatePassowrd(this UserCreated user, IEncrypter encrypter, UserCreated savedUser) 
        { 
            return savedUser.Password.Equals(encrypter.GetHash(savedUser.Password, encrypter.GetSalt()));
        }
    }
}
