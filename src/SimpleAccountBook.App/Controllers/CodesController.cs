using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using kr.bbon.AspNetCore.Mvc;
using kr.bbon.AspNetCore.Filters;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using kr.bbon.AspNetCore;
using SimpleAccountBook.App.Domains.Codes;
using System.Net;
using MediatR;
using SimpleAccountBook.Domains.Codes.Queries;
using kr.bbon.Core;
using Microsoft.AspNetCore.Http;
using SimpleAccountBook.Domains.Codes.Models;
using kr.bbon.AspNetCore.Models;
using kr.bbon.EntityFrameworkCore.Extensions;
using CodeModel = SimpleAccountBook.Domains.Codes.Models.CodeModel;
using SimpleAccountBook.App.Models;

namespace SimpleAccountBook.App
{
    [ApiVersion(DefaultValues.ApiVersion)]
    [ApiController]
    [Area(DefaultValues.AreaName)]
    [Route(DefaultValues.RouteTemplate)]
    public class CodesController : ApiControllerBase
    {
        public CodesController(CodeDomainService codeDomainService, IMediator mediator)
        {
            this.codeDomainService = codeDomainService;
            this.mediator = mediator;
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
        public async Task<CodeModel> GetSubcodes(Guid id)
        {
            var result = await mediator.Send(new GetCodeQuery(new GetCodeQueryFilter
            {
                Id = id,
            }));

            return result;
        }

        [HttpGet]
        [Route("{code}")]
        public async Task<CodeModel> GetSubcodes(string code)
        {
            var result = await mediator.Send(new GetCodeQuery(new GetCodeQueryFilter
            {
                Code = code,
            }));

            return result;
        }


        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesErrorResponseType(typeof(HttpStatusException))]
        public async Task<IActionResult> InsertAsync(InsertCodeModel model)
        {
            if (ModelState.IsValid)
            {
                var item = await codeDomainService.InsertAsync(model);

                return StatusCode(HttpStatusCode.Created, item);
            }
            else
            {
                return StatusCode(HttpStatusCode.BadRequest, ModelState.Values.FirstOrDefault().Errors.FirstOrDefault().ErrorMessage);
            }
        }

        [HttpPatch]
        [Route("{id:guid}")]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesErrorResponseType(typeof(HttpStatusException))]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateCodeModel model)
        {
            if (id != model.Id)
            {
                return StatusCode(HttpStatusCode.BadRequest, "Invalid request body.");
            }

            if (ModelState.IsValid)
            {
                var item = await codeDomainService.UpdateAsync(model);

                return StatusCode(HttpStatusCode.Created, item);
            }
            else
            {
                return StatusCode(HttpStatusCode.BadRequest, ModelState.Values.FirstOrDefault().Errors.FirstOrDefault().ErrorMessage);
            }
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesErrorResponseType(typeof(HttpStatusException))]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await codeDomainService.DeleteAsync(id);

            return StatusCode(HttpStatusCode.Accepted, result);
        }

        private readonly CodeDomainService codeDomainService;
        private readonly IMediator mediator;
    }
}
