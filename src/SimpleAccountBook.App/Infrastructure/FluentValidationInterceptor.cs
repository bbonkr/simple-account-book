using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using kr.bbon.Core;
using kr.bbon.Core.Models;
using Microsoft.AspNetCore.Mvc;
using SimpleAccountBook.App.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace SimpleAccountBook.App
{
    public class FluentValidationInterceptor : IValidatorInterceptor
    {
        public ValidationResult AfterAspNetValidation(ActionContext actionContext, IValidationContext validationContext, ValidationResult result)
        {
            if (!result.IsValid)
            {
                var error = new ErrorModel(
                    result.Errors.FirstOrDefault()?.ErrorMessage, 
                    Code: $"{HttpStatusCode.BadRequest}", 
                    InnerErrors: result.Errors.Select(x => new ErrorModel(x.ErrorMessage, Code: x.ErrorCode, Reference: x.PropertyName)).ToList());

                throw new ApiException(HttpStatusCode.BadRequest, error.Message, error);
            }
            return result;
        }

        public IValidationContext BeforeAspNetValidation(ActionContext actionContext, IValidationContext commonContext)
        {
            return commonContext;
        }
    }
}
