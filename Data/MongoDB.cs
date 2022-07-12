using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using RestauratesAvaliacoes.Api.Data.Schemas;
using RestauratesAvaliacoes.Api.Domain.Entities;
using RestauratesAvaliacoes.Api.Domain.Enums;

namespace RestauratesAvaliacoes.Api.Data
{
    public class MongoDB
    {
        public IMongoDatabase DB { get; }
        //configurações da classe
        public MongoDB(IConfiguration configuration)
        {
            try
            {
                var client = new MongoClient(configuration["ConnectionString"]);
                DB = client.GetDatabase(configuration["NomeBanco"]);
                MapClasses();
            }
            catch (Exception ex)
            {
                throw new MongoException("Não foi possivel se conectar ao MongoDB", ex);
            }
        }
        //mapeamento da classe para o bd
        private void MapClasses()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(RestauranteSchema)))
            {
                BsonClassMap.RegisterClassMap<RestauranteSchema>(i =>
                {
                    i.AutoMap();
                    i.MapIdMember(c => c.Id);
                    i.MapMember(c => c.Cozinha).SetSerializer(new EnumSerializer<ECozinha>(BsonType.Int32));
                    i.SetIgnoreExtraElements(true);
                });
            }
        }
    }
}
