using EShop.Infra.Commnad.User;
using EShop.Infra.Events.User;
using EShop.Infra.Security;

namespace EShop.User.DataProvider.Extensions
{
    public static class CryptoExtension
    {
        public static CreateUser SetPassword(this CreateUser userCreated, IEncrypter encrypter) 
        {
            var salt = encrypter.GetSalt();
            userCreated.Password = encrypter.GetHash(userCreated.Password, salt);
            return userCreated;
        }

        public static bool ValidatePassword(this UserCreated userCreated, UserLogin userLogin, IEncrypter encrypter) 
        { 
            var password = encrypter.GetHash(userLogin.Password, encrypter.GetSalt());
            return userCreated.Password.Equals(password);
        }
    }
}
