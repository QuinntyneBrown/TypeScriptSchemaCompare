using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TypeScriptSchemaCompare.Core.Interfaces;
using TypeScriptSchemaCompare.SharedKernal;

namespace TypeScriptSchemaCompare.Core
{

    public class GetTypeScriptModelsPageRequest: IRequest<GetTypeScriptModelsPageResponse>
    {
        public int PageSize { get; set; }
        public int Index { get; set; }
    }
    public class GetTypeScriptModelsPageResponse: ResponseBase
    {
        public int Length { get; set; }
        public List<TypeScriptModelDto> Entities { get; set; }
    }
    public class GetTypeScriptModelsPageHandler: IRequestHandler<GetTypeScriptModelsPageRequest, GetTypeScriptModelsPageResponse>
    {
        private readonly ISchemaCompareDbContext _context;
        private readonly ILogger<GetTypeScriptModelsPageHandler> _logger;
    
        public GetTypeScriptModelsPageHandler(ISchemaCompareDbContext context, ILogger<GetTypeScriptModelsPageHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<GetTypeScriptModelsPageResponse> Handle(GetTypeScriptModelsPageRequest request, CancellationToken cancellationToken)
        {
            var query = from typeScriptModel in _context.TypeScriptModels
                select typeScriptModel;
            
            var length = await _context.TypeScriptModels.AsNoTracking().CountAsync();
            
            var typeScriptModels = await query.Page(request.Index, request.PageSize).AsNoTracking()
                .Select(x => x.ToDto()).ToListAsync();
            
            return new ()
            {
                Length = length,
                Entities = typeScriptModels
            };
        }
        
    }

}
