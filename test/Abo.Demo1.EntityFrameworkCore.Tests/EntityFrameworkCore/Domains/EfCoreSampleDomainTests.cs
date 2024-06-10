using Abo.Demo1.Samples;
using Xunit;

namespace Abo.Demo1.EntityFrameworkCore.Domains;

[Collection(Demo1TestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<Demo1EntityFrameworkCoreTestModule>
{

}
