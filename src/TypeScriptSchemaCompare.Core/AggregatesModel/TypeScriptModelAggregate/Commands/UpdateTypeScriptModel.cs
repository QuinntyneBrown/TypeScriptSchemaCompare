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

    public class UpdateTypeScriptModelValidator: AbstractValidator<UpdateTypeScriptModelRequest>
    {
        public UpdateTypeScriptModelValidator()
        {
            RuleFor(request => request.TypeScriptModel).NotNull();
            RuleFor(request => request.TypeScriptModel).SetValidator(new TypeScriptModelValidator());
        }
    
    }
    public class UpdateTypeScriptModelRequest: IRequest<UpdateTypeScriptModelResponse>
    {
        public TypeScriptModelDto TypeScriptModel { get; set; }
    }
    public class UpdateTypeScriptModelResponse: ResponseBase
    {
        public TypeScriptModelDto TypeScriptModel { get; set; }
    }
    public class UpdateTypeScriptModelHandler: IRequestHandler<UpdateTypeScriptModelRequest, UpdateTypeScriptModelResponse>
    {
        private readonly ISchemaCompareDbContext _context;
        private readonly ILogger<UpdateTypeScriptModelHandler> _logger;
    
        public UpdateTypeScriptModelHandler(ISchemaCompareDbContext context, ILogger<UpdateTypeScriptModelHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<UpdateTypeScriptModelResponse> Handle(UpdateTypeScriptModelRequest request, CancellationToken cancellationToken)
        {
            var typeScriptModel = await _context.TypeScriptModels.SingleAsync(x => x.TypeScriptModelId == request.TypeScriptModel.TypeScriptModelId);
            
            await _context.SaveChangesAsync(cancellationToken);
            
            return new ()
            {
                TypeScriptModel = typeScriptModel.ToDto()
            };
        }
        
    }

}
