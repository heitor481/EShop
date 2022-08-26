using EShop.Infra.Commnad.User;
using EShop.Infra.EShopConts;
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


        public UserController(IBusControl busControl)
        {
            _busControl = busControl;
        }


        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUser input) 
        {
            var url = new Uri(EShopConst.RabbitMQConnection + "/create_user");
            var bus = await _busControl.GetSendEndpoint(url);
            await bus.Send(input);
            return Ok("User created");
        }
    }
}
