using System.Collections.Generic;
using System.Net;
using Atlantic.Api.Models.Responses;
using FluentValidation.Results;

namespace Atlantic.Api.Facades.Validators
{
    public class ValidatorHelper : IValidatorHelper
    {
        public ValidatorHelper() 
        { 
        
        }

        public BaseResponse Validate(ValidationResult results)
        {
            if (!results.IsValid)
            {
                var validations = new List<string>();

                foreach (var failure in results.Errors)
                {
                    validations.Add(failure.ErrorMessage);
                }

                return new BaseResponse() { Code = HttpStatusCode.BadRequest, Result = validations };
            }

            return null;
        }
    }
}
