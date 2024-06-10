using System.Threading.Tasks;

namespace Abo.Demo1.Data;

public interface IDemo1DbSchemaMigrator
{
    Task MigrateAsync();
}
