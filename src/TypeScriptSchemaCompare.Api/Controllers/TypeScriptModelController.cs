using System.Net;
using System.Threading;
using System.Threading.Tasks;
using TypeScriptSchemaCompare.Core;
using MediatR;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace TypeScriptSchemaCompare.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class TypeScriptModelController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<TypeScriptModelController> _logger;

        public TypeScriptModelController(IMediator mediator, ILogger<TypeScriptModelController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [SwaggerOperation(
            Summary = "Get TypeScriptModel by id.",
            Description = @"Get TypeScriptModel by id."
        )]
        [HttpGet("{typeScriptModelId:guid}", Name = "getTypeScriptModelById")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetTypeScriptModelByIdResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetTypeScriptModelByIdResponse>> GetById([FromRoute]Guid typeScriptModelId, CancellationToken cancellationToken)
        {
            var request = new GetTypeScriptModelByIdRequest() { TypeScriptModelId = typeScriptModelId };
        
            var response = await _mediator.Send(request, cancellationToken);
        
            if (response.TypeScriptModel == null)
            {
                return new NotFoundObjectResult(request.TypeScriptModelId);
            }
        
            return response;
        }
        
        [SwaggerOperation(
            Summary = "Get TypeScriptModels.",
            Description = @"Get TypeScriptModels."
        )]
        [HttpGet(Name = "getTypeScriptModels")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetTypeScriptModelsResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetTypeScriptModelsResponse>> Get(CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetTypeScriptModelsRequest(), cancellationToken);
        }
        
        [SwaggerOperation(
            Summary = "Create TypeScriptModel.",
            Description = @"Create TypeScriptModel."
        )]
        [HttpPost(Name = "createTypeScriptModel")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateTypeScriptModelResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateTypeScriptModelResponse>> Create([FromBody]CreateTypeScriptModelRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "----- Sending command: {CommandName}: ({@Command})",
                nameof(CreateTypeScriptModelRequest),
                request);
        
            return await _mediator.Send(request, cancellationToken);
        }

        [SwaggerOperation(
            Summary = "Compare TypeScriptModels",
            Description = @"Compare TypeScriptModels"
        )]
        [HttpPost("compare", Name = "compare")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CompareResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CompareResponse>> Compare([FromBody] CompareRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "----- Sending command: {CommandName}: ({@Command})",
                nameof(CreateTypeScriptModelRequest),
                request);

            return await _mediator.Send(request, cancellationToken);
        }

        [SwaggerOperation(
            Summary = "Get TypeScriptModel Page.",
            Description = @"Get TypeScriptModel Page."
        )]
        [HttpGet("page/{pageSize}/{index}", Name = "getTypeScriptModelsPage")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetTypeScriptModelsPageResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetTypeScriptModelsPageResponse>> Page([FromRoute]int pageSize, [FromRoute]int index, CancellationToken cancellationToken)
        {
            var request = new GetTypeScriptModelsPageRequest { Index = index, PageSize = pageSize };
        
            return await _mediator.Send(request, cancellationToken);
        }
        
        [SwaggerOperation(
            Summary = "Update TypeScriptModel.",
            Description = @"Update TypeScriptModel."
        )]
        [HttpPut(Name = "updateTypeScriptModel")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateTypeScriptModelResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateTypeScriptModelResponse>> Update([FromBody]UpdateTypeScriptModelRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                nameof(UpdateTypeScriptModelRequest),
                nameof(request.TypeScriptModel.TypeScriptModelId),
                request.TypeScriptModel.TypeScriptModelId,
                request);
        
            return await _mediator.Send(request, cancellationToken);
        }
        
        [SwaggerOperation(
            Summary = "Delete TypeScriptModel.",
            Description = @"Delete TypeScriptModel."
        )]
        [HttpDelete("{typeScriptModelId:guid}", Name = "removeTypeScriptModel")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveTypeScriptModelResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveTypeScriptModelResponse>> Remove([FromRoute]Guid typeScriptModelId, CancellationToken cancellationToken)
        {
            var request = new RemoveTypeScriptModelRequest() { TypeScriptModelId = typeScriptModelId };
        
            _logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                nameof(RemoveTypeScriptModelRequest),
                nameof(request.TypeScriptModelId),
                request.TypeScriptModelId,
                request);
        
            return await _mediator.Send(request, cancellationToken);
        }
        
    }
}
