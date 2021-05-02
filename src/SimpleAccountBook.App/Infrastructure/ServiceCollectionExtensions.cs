using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

using SimpleAccountBook.Domains;

namespace SimpleAccountBook.App
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAutoMapperProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(DomainsPlaceHolder).GetTypeInfo().Assembly);

            return services;
        }

        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(typeof(DomainsPlaceHolder).GetTypeInfo().Assembly);

            return services;
        }
    }
}
