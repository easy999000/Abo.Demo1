using Volo.Abp.Modularity;

namespace Abo.Demo1;

[DependsOn(
    typeof(Demo1DomainModule),
    typeof(Demo1TestBaseModule)
)]
public class Demo1DomainTestModule : AbpModule
{

}
