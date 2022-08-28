using EShop.Infra.Authentication;
using EShop.Infra.Commnad.User;
using EShop.Infra.EShopConts;
using EShop.Infra.Events.Product;
using EShop.Infra.Events.User;
using EShop.Infra.Queries.Product;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EShop.ApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IBusControl _busControl;
        private readonly IRequestClient<UserLogin> _requestClient;


        public UserController(IBusControl busControl, IRequestClient<UserLogin> requestClient)
        {
            _busControl = busControl;
            _requestClient = requestClient;
        }


        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUser input) 
        {
            var url = new Uri(EShopConst.RabbitMQConnection + "/create_user");
            var bus = await _busControl.GetSendEndpoint(url);
            await bus.Send(input);
            return Ok("User created");
        }

        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> Login(UserLogin input) 
        {
            var userLoginInfo = new UserLogin() { Username = input.Username, Password = input.Password };
            var token = await _requestClient.GetResponse<JwtAuthToken>(userLoginInfo);
            return Ok(token.Message);
        }
    }
}
