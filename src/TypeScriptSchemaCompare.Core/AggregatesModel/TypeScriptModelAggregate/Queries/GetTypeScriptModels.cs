using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TypeScriptSchemaCompare.Core.Interfaces;
using TypeScriptSchemaCompare.SharedKernal;

namespace TypeScriptSchemaCompare.Core
{

    public class GetTypeScriptModelsRequest: IRequest<GetTypeScriptModelsResponse> { }
    public class GetTypeScriptModelsResponse: ResponseBase
    {
        public List<TypeScriptModelDto> TypeScriptModels { get; set; }
    }
    public class GetTypeScriptModelsHandler: IRequestHandler<GetTypeScriptModelsRequest, GetTypeScriptModelsResponse>
    {
        private readonly ISchemaCompareDbContext _context;
        private readonly ILogger<GetTypeScriptModelsHandler> _logger;
    
        public GetTypeScriptModelsHandler(ISchemaCompareDbContext context, ILogger<GetTypeScriptModelsHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<GetTypeScriptModelsResponse> Handle(GetTypeScriptModelsRequest request, CancellationToken cancellationToken)
        {
            return new () {
                TypeScriptModels = await _context.TypeScriptModels.AsNoTracking().ToDtosAsync(cancellationToken)
            };
        }
        
    }

}
