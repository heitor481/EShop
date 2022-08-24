using System;
using System.Collections.Generic;
using System.Text;

namespace EShop.Infra.EventBus
{
    public class RabbitMQOptions
    {
        public RabbitMQOptions()
        {

        }

        public RabbitMQOptions(string connectionString, string username, string passWord)
        {
            ConnectionString = connectionString;
            Username = username;
            PassWord = passWord;
        }

        public string ConnectionString { get; set; }

        public string Username { get; set; }

        public string PassWord { get; set; }
    }
}
