using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleAccountBook.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleAccountBook.App
{
    /// <summary>
    /// Adds transaction to the processing pipeline
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public class DBContextTransactionPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull
    {
        private readonly ApplicationDbContext dbContext;

        public DBContextTransactionPipelineBehavior(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            TResponse? result = default(TResponse);

            try
            {
                dbContext.BeginTransaction();

                result = await next();

                dbContext.CommitTransaction();
            }
            catch (Exception)
            {
                dbContext.RollbackTransaction();
                throw;
            }

            return result;
        }
    }
}
