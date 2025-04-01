using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Atlantic.Api.Data.EcommerceDataContext.Repositories.Interfaces;
using Atlantic.Api.Facades.Core;
using Atlantic.Api.Facades.Interfaces;
using Atlantic.Api.Facades.Validators;
using Atlantic.Api.Models.Context.Products;
using Atlantic.Api.Models.DTOs;
using Atlantic.Api.Models.Requests;
using Atlantic.Api.Models.Responses;

namespace Atlantic.Api.Facades
{
    public class ProductsFacade : BaseFacade, IProductsFacade
    {
        private IProductsRepository _productsRepository;

        public ProductsFacade(
                CommonDependenciesFacade commonDependenciesFacade,
                IProductsRepository productsRepository
            )
            : base(commonDependenciesFacade)
        {
            _productsRepository = productsRepository;
        }

        public ListProductsResponse GetAll(FilterProductsDTO filter)
        {
            return _productsRepository.GetAll(filter);
        }

        public async Task<BaseResponse> GetByIdAsync(string id)
        {
            var idProduct = new MongoDB.Bson.ObjectId(id);
            var products = await _productsRepository.GetByIdAsync(idProduct);

            if (products.Count == 0)
            {
                return new BaseResponse()
                {
                    Code = HttpStatusCode.NotFound,
                    Message = "Produto não encontrado"
                };
            }

            return new BaseResponse()
            {
                Code = HttpStatusCode.OK,
                Result = products.First()
            };
        }

        public async Task<BaseResponse> InsertProductAsync(ProductDTO product)
        {
            try
            {
                var validator = new ProductValidador().Validate(product);
                var validate = ValidatorHelper.Validate(validator);
                if (validate != null)
                    return validate;

                var productToAdd = new Product()
                {
                    title = product.title,
                    subtitle = product.subtitle,
                    value = product.value,
                    valueUnique = product.valueUnique,
                    height = product.height,
                    images = product.images,
                    shipping = product.shipping,
                    weight = product.weight,
                    width = product.width,
                    tags = product.tags,
                    length = product.length,
                    status = product.status,
                    variations = product.variations.Select(v => new Variation()
                    {
                        id = new MongoDB.Bson.ObjectId(v.id),
                        name = v.name,
                        image = v.image,
                        color = v.color
                    }).ToList(),
                    createdDate = DateTime.Now,
                    updatedDate = DateTime.Now,
                    categories = product.categories.Select(c => new Category()
                    {
                        id = new MongoDB.Bson.ObjectId(c.id),
                        name = c.name,
                        subCategories = c.subCategories,
                    }).ToList()
                };

                var result = await _productsRepository.InsertProductAsync(productToAdd);

                return new BaseResponse() { Code = HttpStatusCode.Created, Result = result };
            }
            catch (Exception ex)
            {
                Logger.Error("Error on insert product. Error: {E}", ex.Message);
                return new BaseResponse() { Code = HttpStatusCode.InternalServerError, Message = ex.Message };
            }
        }

        public async Task<BaseResponse> DeleteProductAsync(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return new BaseResponse() { Code = HttpStatusCode.BadRequest, Message = "Id must not be empty" };
                }

                var idProduct = new MongoDB.Bson.ObjectId(id);

                var result = await _productsRepository.DeleteAsync(idProduct);

                return new BaseResponse() { Code = HttpStatusCode.OK, Result = result };
            }
            catch (Exception ex)
            {
                Logger.Error("Error on delete product. Error: {E}", ex.Message);
                return new BaseResponse() { Code = HttpStatusCode.InternalServerError, Message = ex.Message };
            }
        }
    }
}
