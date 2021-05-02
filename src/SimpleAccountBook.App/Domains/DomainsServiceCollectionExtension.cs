using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using SimpleAccountBook.App.Domains.Codes;

namespace SimpleAccountBook.App
{
    public static class DomainsServiceCollectionExtension
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<CodeDomainService>();

            return services;
        }
    }
}
