using Atlantic.Api.Models.Responses;
using FluentValidation.Results;

namespace Atlantic.Api.Facades.Validators
{
    public interface IValidatorHelper
    {
        BaseResponse Validate(ValidationResult results);
    }
}
