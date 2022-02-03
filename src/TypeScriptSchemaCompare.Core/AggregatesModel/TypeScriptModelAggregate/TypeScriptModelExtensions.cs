using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace TypeScriptSchemaCompare.Core
{
    public static class TypeScriptModelExtensions
    {
        public static TypeScriptModelDto ToDto(this TypeScriptModel typeScriptModel)
        {
            return new ()
            {
                TypeScriptModelId = typeScriptModel.TypeScriptModelId
            };
        }
        
        public static async Task<List<TypeScriptModelDto>> ToDtosAsync(this IQueryable<TypeScriptModel> typeScriptModels, CancellationToken cancellationToken)
        {
            return await typeScriptModels.Select(x => x.ToDto()).ToListAsync(cancellationToken);
        }
        
        public static List<TypeScriptModelDto> ToDtos(this IEnumerable<TypeScriptModel> typeScriptModels)
        {
            return typeScriptModels.Select(x => x.ToDto()).ToList();
        }
        
    }
}
