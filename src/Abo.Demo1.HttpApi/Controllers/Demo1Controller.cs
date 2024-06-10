using Abo.Demo1.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Abo.Demo1.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class Demo1Controller : AbpControllerBase
{
    protected Demo1Controller()
    {
        LocalizationResource = typeof(Demo1Resource);
    }
}
