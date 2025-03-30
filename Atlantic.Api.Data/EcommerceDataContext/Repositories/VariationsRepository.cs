using Atlantic.Api.Data.EcommerceDataContext.Repositories.Interfaces;
using Atlantic.Api.Models.Context.Products;
using Atlantic.Api.Models.DTOs;
using Atlantic.Api.Models.Responses;
using Atlantic.Api.Models.UI;
using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Atlantic.Api.Data.EcommerceDataContext.Repositories
{
    public class VariationsRepository : IVariationsRepository
    {
        private readonly IMongoCollection<Variation> Variations;
        private readonly IMapper _mapper;

        public VariationsRepository(IMongoClient mongoClient, IOptions<MongoDbSettings> settings, IMapper mapper)
        {
            _mapper = mapper;
            var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
            Variations = database.GetCollection<Variation>("Variations");
        }

        public ListVariationsResponse GetAll(int page, int pageSize, string? term)
        {
            var list = term == null ? Variations.Find(_ => true) : Variations.Find(x => x.name.Contains(term));

            var variations = list.Skip((page - 1) * pageSize)
                                 .Limit(pageSize)
                                 .ToList();

            var count = Variations.CountDocuments(_ => true);

            return new ListVariationsResponse
            {
                Page = page,
                PageSize = pageSize,
                Data = _mapper.Map<List<VariationDTO>>(variations),
                Count = (int)count
            };
        }

        public async Task<Variation> InsertAsync(Variation item)
        {
            await Variations.InsertOneAsync(item);
            return _mapper.Map<VariationDTO>(item);
        }

        public async Task<long> DeleteAsync(string id)
        {
            var result = await Variations.DeleteOneAsync(x => x.id == new ObjectId(id));
            return result.DeletedCount;
        }
    }
}