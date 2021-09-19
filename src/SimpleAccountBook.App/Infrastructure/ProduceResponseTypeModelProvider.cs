using kr.bbon.AspNetCore.Models;
using kr.bbon.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleAccountBook.App
{
    public class ProduceResponseTypeModelProvider : IApplicationModelProvider
    {
        public int Order => 3;

        public void OnProvidersExecuted(ApplicationModelProviderContext context)
        {
        }

        public void OnProvidersExecuting(ApplicationModelProviderContext context)
        {
            foreach (ControllerModel controller in context.Result.Controllers)
            {
                foreach (ActionModel action in controller.Actions)
                {
                    var actionMethodReturnType = action.ActionMethod.ReturnType;

                    Type actualReturnType = default(Type);

                    if (actionMethodReturnType == typeof(Task) || actionMethodReturnType.BaseType == typeof(Task))
                    {
                        if ((action.ActionMethod.ReturnType.GenericTypeArguments?.Length ?? 0) > 0)
                        {
                            var firstGenericType = action.ActionMethod.ReturnType.GenericTypeArguments[0];

                            if (firstGenericType != typeof(IActionResult))
                            {
                                actualReturnType = firstGenericType;
                            }
                        }
                    }
                    else if (actionMethodReturnType != typeof(IActionResult))
                    {
                        actualReturnType = actionMethodReturnType;
                    }

                    if (actualReturnType != default(Type))
                    {
                        var firstGenericType = actualReturnType;

                        var errorType = typeof(ErrorModel);
                        var apiReturnType = typeof(ApiResponseModel<>);

                        var okReturnType = actualReturnType;
                        
                        var errorReturnType = apiReturnType.MakeGenericType(errorType);

                        var has200 = false;
                        var has400 = false;
                        var has500 = false;

                        foreach (var p in action.Filters.Where(x => x is ProducesResponseTypeAttribute))
                        {
                            if (p is ProducesResponseTypeAttribute producesResponseTypeAttribute)
                            {
                                var statusCode = producesResponseTypeAttribute.StatusCode;
                                if (!has200 && 200 <= statusCode && statusCode < 300)
                                {
                                    has200 = true;
                                    if (producesResponseTypeAttribute.Type == null)
                                    {
                                        producesResponseTypeAttribute.Type = actualReturnType;
                                    }
                                    continue;
                                }

                                if (!has400 && 400 <= statusCode && statusCode < 500)
                                {
                                    has400 = true;
                                    if (producesResponseTypeAttribute.Type == null)
                                    {
                                        producesResponseTypeAttribute.Type = errorReturnType;
                                    }
                                    continue;
                                }

                                if (!has500 && 500 <= statusCode && statusCode < 600)
                                {
                                    has500 = true;
                                    if (producesResponseTypeAttribute.Type == null)
                                    {
                                        producesResponseTypeAttribute.Type = errorReturnType;
                                    }
                                    continue;
                                }
                            }
                        }

                        if (!has200)
                        {
                            action.Filters.Add(new ProducesResponseTypeAttribute(okReturnType, StatusCodes.Status200OK));
                        }
                        if (!has400)
                        {
                            action.Filters.Add(new ProducesResponseTypeAttribute(errorReturnType, StatusCodes.Status400BadRequest));
                        }
                        if (!has500)
                        {
                            action.Filters.Add(new ProducesResponseTypeAttribute(errorReturnType, StatusCodes.Status500InternalServerError));
                        }

                    }
                }
            }
        }
    }

}
