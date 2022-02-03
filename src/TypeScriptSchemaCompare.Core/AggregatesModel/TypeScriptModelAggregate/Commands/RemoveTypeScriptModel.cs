using FluentValidation;
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

    public class RemoveTypeScriptModelRequest: IRequest<RemoveTypeScriptModelResponse>
    {
        public Guid TypeScriptModelId { get; set; }
    }
    public class RemoveTypeScriptModelResponse: ResponseBase
    {
        public TypeScriptModelDto TypeScriptModel { get; set; }
    }
    public class RemoveTypeScriptModelHandler: IRequestHandler<RemoveTypeScriptModelRequest, RemoveTypeScriptModelResponse>
    {
        private readonly ISchemaCompareDbContext _context;
        private readonly ILogger<RemoveTypeScriptModelHandler> _logger;
    
        public RemoveTypeScriptModelHandler(ISchemaCompareDbContext context, ILogger<RemoveTypeScriptModelHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<RemoveTypeScriptModelResponse> Handle(RemoveTypeScriptModelRequest request, CancellationToken cancellationToken)
        {
            var typeScriptModel = await _context.TypeScriptModels.FindAsync(request.TypeScriptModelId);
            
            _context.TypeScriptModels.Remove(typeScriptModel);
            
            await _context.SaveChangesAsync(cancellationToken);
            
            return new ()
            {
                TypeScriptModel = typeScriptModel.ToDto()
            };
        }
        
    }

}
