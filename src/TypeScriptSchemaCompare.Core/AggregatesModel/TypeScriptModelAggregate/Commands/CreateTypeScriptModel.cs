using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TypeScriptSchemaCompare.Core.Interfaces;
using TypeScriptSchemaCompare.SharedKernal;

namespace TypeScriptSchemaCompare.Core
{

    public class CreateTypeScriptModelValidator: AbstractValidator<CreateTypeScriptModelRequest>
    {
        public CreateTypeScriptModelValidator()
        {
            RuleFor(request => request.TypeScriptModel).NotNull();
            RuleFor(request => request.TypeScriptModel).SetValidator(new TypeScriptModelValidator());
        }
    
    }
    public class CreateTypeScriptModelRequest: IRequest<CreateTypeScriptModelResponse>
    {
        public TypeScriptModelDto TypeScriptModel { get; set; }
    }
    public class CreateTypeScriptModelResponse: ResponseBase
    {
        public TypeScriptModelDto TypeScriptModel { get; set; }
    }
    public class CreateTypeScriptModelHandler: IRequestHandler<CreateTypeScriptModelRequest, CreateTypeScriptModelResponse>
    {
        private readonly ISchemaCompareDbContext _context;
        private readonly ILogger<CreateTypeScriptModelHandler> _logger;
    
        public CreateTypeScriptModelHandler(ISchemaCompareDbContext context, ILogger<CreateTypeScriptModelHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<CreateTypeScriptModelResponse> Handle(CreateTypeScriptModelRequest request, CancellationToken cancellationToken)
        {
            var typeScriptModel = new TypeScriptModel();
            
            _context.TypeScriptModels.Add(typeScriptModel);
            
            await _context.SaveChangesAsync(cancellationToken);
            
            return new ()
            {
                TypeScriptModel = typeScriptModel.ToDto()
            };
        }
        
    }

}
