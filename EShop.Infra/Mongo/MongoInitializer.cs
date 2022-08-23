using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Infra.Mongo
{
	public class MongoInitializer : IDatabaseInitializer
	{
		private bool _initialize;
		private IMongoDatabase _database;

		public MongoInitializer(IMongoDatabase database)
		{
			_database = database;
		}

		public async Task Initialize()
		{
			if (_initialize)
				return;

			var conventionPack = new ConventionPack
			{
				new IgnoreExtraElementsConvention(true),
				new CamelCaseElementNameConvention(),
				new EnumRepresentationConvention(MongoDB.Bson.BsonType.String)
			};
			ConventionRegistry.Register("EShop",conventionPack, c => true);

			_initialize = true;

			await Task.CompletedTask;
		}
	}
}
