using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SimpleAccountBook.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleAccountBook.Domains.Shared
{
    public abstract class RequestHandlerWithDatabaseContextBase<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        public RequestHandlerWithDatabaseContextBase(
            ApplicationDbContext dbContext,
            IMapper mapper,
            IMediator mediator,
            ILogger logger)
        {
            DbContext = dbContext;
            Mapper = mapper;
            Mediator = mediator;
            Logger = logger;
        }
                
        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);

        protected ApplicationDbContext DbContext { get; }
        protected IMapper Mapper {  get; }
        protected IMediator Mediator {  get; }

        protected ILogger Logger {  get; }
    }
}
