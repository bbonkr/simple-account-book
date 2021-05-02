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

namespace SimpleAccountBook.App
{
    [ApiVersion(DefaultValues.ApiVersion)]
    [ApiController]
    [Area(DefaultValues.AreaName)]
    [Route(DefaultValues.RouteTemplate)]
    [ApiExceptionHandlerFilter]
    public class CodesController : ApiControllerBase
    {
        public CodesController(CodeDomainService codeDomainService, IMediator mediator)
        {
            this.codeDomainService = codeDomainService;
            this.mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(HttpStatusException))]
        public async Task<IActionResult> GetCodes([FromQuery] GetCodeQueryFilter filter)
        {
            //var items = await codeDomainService.GetCodesAsync();
            var items = await mediator.Send(new GetCodesQueryRequestModel(filter));

            return StatusCode(HttpStatusCode.OK, items);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(HttpStatusException))]
        public async Task<IActionResult> GetSubcodes(Guid id)
        {
            var items = await codeDomainService.GetSubcodesAsync(id);

            return StatusCode(HttpStatusCode.OK, items);
        }

        [HttpGet]
        [Route("{code}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(HttpStatusException))]
        public async Task<IActionResult> GetSubcodes(string code)
        {
            var items = await codeDomainService.GetSubcodesAsync(code);

            return StatusCode(HttpStatusCode.OK, items);
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
