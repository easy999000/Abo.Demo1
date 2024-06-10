using Volo.Abp.Modularity;

namespace Abo.Demo1;

public abstract class Demo1ApplicationTestBase<TStartupModule> : Demo1TestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
