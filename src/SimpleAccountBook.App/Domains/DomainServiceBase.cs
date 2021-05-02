using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using kr.bbon.AspNetCore;
using kr.bbon.AspNetCore.Models;

namespace SimpleAccountBook.App.Domains
{
    public abstract class DomainServiceBase
    {
        protected void ThrowHttpStatusException(HttpStatusCode statusCode, string message)
        {
            var error = new ErrorModel
            {
                Code = $"{statusCode}",
                Message = message,
            };

            throw new HttpStatusException<ErrorModel>(statusCode, message, error);
        }
    }
}
