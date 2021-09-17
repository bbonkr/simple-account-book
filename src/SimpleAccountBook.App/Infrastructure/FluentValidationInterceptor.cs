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
                var error = new ApiErrorModel
                {
                    Instance = actionContext.ActionDescriptor.DisplayName,
                    Path = actionContext.HttpContext.Request.Path,
                    Method = actionContext.HttpContext.Request.Method,
                    Code = $"{HttpStatusCode.BadRequest}",
                    Message = result.Errors.FirstOrDefault()?.ErrorMessage,
                    InnerErrors = result.Errors.Select(x => {
                        return new ErrorModel
                        {
                            Code = x.ErrorCode,
                            Message = x.ErrorMessage,
                        };
                    }).ToList(),
                };

                throw new HttpStatusException<ErrorModel>(HttpStatusCode.BadRequest, error.Message, error);
            }
            return result;
        }

        public IValidationContext BeforeAspNetValidation(ActionContext actionContext, IValidationContext commonContext)
        {
            return commonContext;
        }
    }
}
