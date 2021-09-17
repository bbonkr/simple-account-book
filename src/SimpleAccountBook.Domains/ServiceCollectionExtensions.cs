using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAccountBook.Domains
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainsDependencies(this IServiceCollection services)
        {

            return services;
        }
    }
}
