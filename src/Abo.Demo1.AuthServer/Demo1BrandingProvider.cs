using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Abo.Demo1;

[Dependency(ReplaceServices = true)]
public class Demo1BrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Demo1";
}
