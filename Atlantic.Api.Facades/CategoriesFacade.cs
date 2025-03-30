using System;
using System.Net;
using System.Threading.Tasks;
using Atlantic.Api.Data.EcommerceDataContext.Repositories.Interfaces;
using Atlantic.Api.Facades.Core;
using Atlantic.Api.Facades.Interfaces;
using Atlantic.Api.Facades.Validators;
using Atlantic.Api.Models.Context.Products;
using Atlantic.Api.Models.Responses;

namespace Atlantic.Api.Facades
{
    public class CategoriesFacade : BaseFacade, ICategoriesFacade
    {
        private IValidatorHelper _validatorHelper;
        private ICategoriesRepository _categoriesRepository;

        public CategoriesFacade(
                CommonDependenciesFacade commonDependenciesFacade,
                ICategoriesRepository categoriesRepository,
                IValidatorHelper validatorHelper
            )
            : base(commonDependenciesFacade)
        {
            _categoriesRepository = categoriesRepository;
            _validatorHelper = validatorHelper;
        }

        public ListCategoriesResponse GetAll(int page, int pageSize, string term)
        {
             return _categoriesRepository.GetAll(page, pageSize, term);
        }

        public async Task<BaseResponse> InsertCategoryAsync(Category category)
        {
            try
            {
                var validator = new CategoryValidador().Validate(category);
                var validate = _validatorHelper.Validate(validator);
                if (validate != null)
                    return validate;

                category.updatedDate = DateTime.Now;
                category.createdDate = DateTime.Now;

                var result = await _categoriesRepository.InsertAsync(category);

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
