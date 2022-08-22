namespace EShop.Infra.Mongo
{
    public class MongoConfig
    {
        public MongoConfig(string connectionString, string database)
        {
            ConnectionString = connectionString;
            Database = database;
        }

        public string ConnectionString { get; set; }

        public string Database { get; set; }
    }
}
