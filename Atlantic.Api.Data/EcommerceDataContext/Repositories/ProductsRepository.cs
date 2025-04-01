using Atlantic.Api.Data.EcommerceDataContext.Repositories.Interfaces;
using Atlantic.Api.Models.Context.Products;
using Atlantic.Api.Models.DTOs;
using Atlantic.Api.Models.Requests;
using Atlantic.Api.Models.Responses;
using Atlantic.Api.Models.UI;
using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Atlantic.Api.Data.EcommerceDataContext.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly IMongoCollection<Product> Products;
        private readonly IMapper _mapper;

        public ProductsRepository(IMongoClient mongoClient, IOptions<MongoDbSettings> settings, IMapper mapper)
        {
            _mapper = mapper;
            var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
            Products = database.GetCollection<Product>("Products");
        }

        public ListProductsResponse GetAll(FilterProductsDTO filterDTO)
        {
            var filterBuilder = Builders<Product>.Filter;
            var filters = new List<FilterDefinition<Product>>();

            if (!string.IsNullOrEmpty(filterDTO.term))
            {
                filters.Add(filterBuilder.Regex(x => x.title, new BsonRegularExpression(filterDTO.term, "i")));
            }

            if (!string.IsNullOrEmpty(filterDTO.categoryId))
            {
                filters.Add(filterBuilder.ElemMatch<Category>("categories", Builders<Category>.Filter.Eq("id", new ObjectId(filterDTO.categoryId))));
            }
            else if (!string.IsNullOrEmpty(filterDTO.nameSubcategory))
            {
                filters.Add(
                    filterBuilder.ElemMatch<Category>("categories", Builders<Category>.Filter.ElemMatch<SubCategory>("subCategories", Builders<SubCategory>.Filter.Eq("name", filterDTO.nameSubcategory)))
                );
            }
            else if (filterDTO.tags != null && filterDTO.tags.Length > 0)
            {
                filters.Add(filterBuilder.In("tags", filterDTO.tags));
            }

            if (filterDTO.minValue.HasValue)
            {
                filters.Add(filterBuilder.Gte(x => x.value, filterDTO.minValue.Value));
            }

            if (filterDTO.maxValue.HasValue)
            {
                filters.Add(filterBuilder.Lte(x => x.value, filterDTO.maxValue.Value));
            }

            var filter = filters.Count > 0 ? filterBuilder.And(filters) : filterBuilder.Empty;

            var list = filterDTO.asc
                        ? Products.Find(filter).SortBy(x => x.value)
                        : Products.Find(filter).SortByDescending(x => x.value);

            var products = list.Skip((filterDTO.page - 1) * filterDTO.pageSize)
                               .Limit(filterDTO.pageSize)
                               .ToList();

            var count = Products.CountDocuments(filter);

            return new ListProductsResponse
            {
                Page = filterDTO.page,
                PageSize = filterDTO.pageSize,
                Data = _mapper.Map<List<ProductDTO>>(products),
                Count = (int)count
            };
        }

        public async Task<List<ProductDTO>> GetByIdAsync(ObjectId id)
        {
            var result = await Products.Find(x => x.id == id).ToListAsync();
            return _mapper.Map<List<ProductDTO>>(result);
        }

        public async Task<Product> InsertProductAsync(Product product)
        {
            await Products.InsertOneAsync(product);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<long> UpdateAsync(ObjectId id, Product product)
        {
            var filter = Builders<Product>.Filter.Eq("id", id);
            var result = await Products.ReplaceOneAsync(filter, product);
            return result.ModifiedCount;
        }

        public async Task<long> DeleteAsync(ObjectId id)
        {
            var result = await Products.DeleteOneAsync(x => x.id == id);
            return result.DeletedCount;
        }

        public async Task<List<Product>> GeyByCategoryIdAsync(ObjectId categoryId)
        {
            var filter = Builders<Product>.Filter.ElemMatch<Category>("categories", Builders<Category>.Filter.Eq("id", categoryId));
            var products = await Products.FindAsync(filter);
            return products.ToList();
        }
    }
}