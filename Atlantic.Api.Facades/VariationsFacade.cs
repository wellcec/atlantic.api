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
    public class VariationsFacade : BaseFacade, IVariationsFacade
    {
        private IValidatorHelper _validatorHelper;
        private IVariationsRepository _variationsRepository;

        public VariationsFacade(
                CommonDependenciesFacade commonDependenciesFacade,
                IVariationsRepository variationsRepository,
                IValidatorHelper validatorHelper
            )
            : base(commonDependenciesFacade)
        {
            _variationsRepository = variationsRepository;
            _validatorHelper = validatorHelper;
        }

        public ListVariationsResponse GetAll(int page, int pageSize, string term)
        {
            return _variationsRepository.GetAll(page, pageSize, term);
        }

        public async Task<BaseResponse> InsertVariationAsync(Variation variation)
        {
            try
            {
                var validator = new VariationValidator().Validate(variation);
                var validate = _validatorHelper.Validate(validator);
                if (validate != null)
                    return validate;

                variation.createdDate = DateTime.Now;

                var result = await _variationsRepository.InsertAsync(variation);

                return new BaseResponse() { Code = HttpStatusCode.Created, Result = result };
            }
            catch (Exception ex)
            {
                Logger.Error("Error on insert product. Error: {E}", ex.Message);
                return new BaseResponse() { Code = HttpStatusCode.InternalServerError, Message = ex.Message };
            }
        }

        public async Task<BaseResponse> DeleteAsync(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return new BaseResponse() { Code = HttpStatusCode.BadRequest, Message = "Id must not be empty" };
                }

                var idVariation = new MongoDB.Bson.ObjectId(id);

                var result = await _variationsRepository.DeleteAsync(idVariation);

                return new BaseResponse() { Code = HttpStatusCode.OK, Result = result };
            }
            catch (Exception ex)
            {
                Logger.Error("Error on delete variation. Error: {E}", ex.Message);
                return new BaseResponse() { Code = HttpStatusCode.InternalServerError, Message = ex.Message };
            }
        }
    }
}
