using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TypeScriptSchemaCompare.Core.Interfaces;
using TypeScriptSchemaCompare.SharedKernal;

namespace TypeScriptSchemaCompare.Core
{

    public class GetTypeScriptModelByIdRequest: IRequest<GetTypeScriptModelByIdResponse>
    {
        public Guid TypeScriptModelId { get; set; }
    }
    public class GetTypeScriptModelByIdResponse: ResponseBase
    {
        public TypeScriptModelDto TypeScriptModel { get; set; }
    }
    public class GetTypeScriptModelByIdHandler: IRequestHandler<GetTypeScriptModelByIdRequest, GetTypeScriptModelByIdResponse>
    {
        private readonly ISchemaCompareDbContext _context;
        private readonly ILogger<GetTypeScriptModelByIdHandler> _logger;
    
        public GetTypeScriptModelByIdHandler(ISchemaCompareDbContext context, ILogger<GetTypeScriptModelByIdHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<GetTypeScriptModelByIdResponse> Handle(GetTypeScriptModelByIdRequest request, CancellationToken cancellationToken)
        {
            return new () {
                TypeScriptModel = (await _context.TypeScriptModels.AsNoTracking().SingleOrDefaultAsync(x => x.TypeScriptModelId == request.TypeScriptModelId)).ToDto()
            };
        }
        
    }

}
