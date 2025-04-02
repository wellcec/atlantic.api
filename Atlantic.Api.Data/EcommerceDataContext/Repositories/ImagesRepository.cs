using Atlantic.Api.Data.EcommerceDataContext.Repositories.Interfaces;
using Atlantic.Api.Models.Context.Products;
using Atlantic.Api.Models.DTOs;
using Atlantic.Api.Models.UI;
using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Atlantic.Api.Data.EcommerceDataContext.Repositories
{
    public class ImagesRepository : IImagesRepository
    {
        private readonly IMongoCollection<Image> Images;
        private readonly IMapper _mapper;

        public ImagesRepository(IMongoClient mongoClient, IOptions<MongoDbSettings> settings, IMapper mapper)
        {
            _mapper = mapper;
            var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
            Images = database.GetCollection<Image>("Images");
        }

        public List<ImageDTO> GetAll()
        {
            var list = Images.Find(_ => true).ToList();
            return _mapper.Map<List<ImageDTO>>(list);
        }

        public async Task<ImageDTO> GetByIdAsync(ObjectId id)
        {
            var result = await Images.Find(x => x.id == id).ToListAsync();
            return _mapper.Map<ImageDTO>(result.First());
        }

        public async Task<ImageDTO> InsertAsync(Image item)
        {
            await Images.InsertOneAsync(item);
            return _mapper.Map<ImageDTO>(item);
        }

        public async Task<long> DeleteAsync(ObjectId id)
        {
            var result = await Images.DeleteOneAsync(x => x.id == id);
            return result.DeletedCount;
        }

        public async Task<long> DeleteAllAsync()
        {
            var result = await Images.DeleteManyAsync(FilterDefinition<Image>.Empty);
            return result.DeletedCount;
        }
    }
}