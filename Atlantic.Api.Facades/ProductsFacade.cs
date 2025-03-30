using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Atlantic.Api.Data.EcommerceDataContext.Repositories.Interfaces;
using Atlantic.Api.Facades.Core;
using Atlantic.Api.Facades.Interfaces;
using Atlantic.Api.Models.Context.Products;
using Atlantic.Api.Models.Responses;
using Atlantic.Api.Services.Interfaces;

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

        public async Task<BaseResponse> InsertProductAsync(Product product)
        {
            try
            {
                var result = await _productsRepository.InsertProductAsync(product);

                return new BaseResponse() { Code = HttpStatusCode.Created, Result = result };
            }
            catch (Exception ex)
            {
                Logger.Error("Error on insert product. Error: {E}", ex.Message);
                return new BaseResponse() { Code = HttpStatusCode.InternalServerError, Message = ex.Message };
            }
        }
    }
}
