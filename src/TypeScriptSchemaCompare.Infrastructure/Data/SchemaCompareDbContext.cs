using TypeScriptSchemaCompare.Core;
using TypeScriptSchemaCompare.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace TypeScriptSchemaCompare.Infrastructure.Data
{
    public class SchemaCompareDbContext: DbContext, ISchemaCompareDbContext
    {
        public DbSet<TypeScriptModel> TypeScriptModels { get; private set; }
        public SchemaCompareDbContext(DbContextOptions options)
            :base(options) { }

    }
}
