using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;

namespace TypeScriptSchemaCompare.Core.Interfaces
{
    public interface ISchemaCompareDbContext
    {
        DbSet<TypeScriptModel> TypeScriptModels { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        
    }
}
