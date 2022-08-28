using Microsoft.AspNetCore.Authentication;
using System;

namespace EShop.Infra.Authentication
{
    public interface IAuthenticationHandler
    {
        JwtAuthToken Create(string userId);
    }
}
