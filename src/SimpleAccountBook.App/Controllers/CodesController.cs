using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using kr.bbon.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc;
using kr.bbon.AspNetCore;
using System.Net;
using MediatR;
using SimpleAccountBook.Domains.Codes.Queries;
using Microsoft.AspNetCore.Http;
using SimpleAccountBook.Domains.Codes.Models;

using SimpleAccountBook.Domains.Codes.Commands;
using Microsoft.Extensions.Logging;

namespace SimpleAccountBook.App
{
    [ApiVersion(DefaultValues.ApiVersion)]
    [ApiController]
    [Area(DefaultValues.AreaName)]
    [Route(DefaultValues.RouteTemplate)]
    public class CodesController : ApiControllerBase
    {
        public CodesController(
            IMediator mediator,
            ILogger<CodesController> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<CodesResponseModel> GetCodes([FromQuery] GetCodesQueryFilter filter)
        {
            var items = await mediator.Send(new GetCodesQuery(filter));

            return items;
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<CodeModel> GetCodeDetails(Guid id)
        {
            var result = await mediator.Send(new GetCodeQuery(new GetCodeQueryFilter(id)));

            return result;
        }

        [HttpGet]
        [Route("{code}")]
        public async Task<CodeModel> GetCodeDetails(string code)
        {
            var result = await mediator.Send(new GetCodeQuery(new GetCodeQueryFilter(code)));

            return result;
        }


        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<CodeModel> InsertAsync([FromBody]  CodeInsertRequestModel model)
        {
            var result = await mediator.Send(new InsertCodeCommand(model));

            return result;
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<CodeModel> UpdateAsync([FromBody] CodeUpdateRequestModel model)
        {
            var result = await mediator.Send(new UpdateCodeCommand(model));

            return result;
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = await mediator.Send(new DeleteCodeCommand(new CodeDeleteRequestModel { Id = id }));

            return result;
        }

        private readonly IMediator mediator;
        private readonly ILogger logger;
    }
}
