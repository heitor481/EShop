namespace EShop.Infra.Security
{
    public interface IEncrypter
    {
        string GetSalt();

        string GetHash(string value, string salt);
    }
}
