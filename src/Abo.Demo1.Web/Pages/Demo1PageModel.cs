using Abo.Demo1.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Abo.Demo1.Web.Pages;

public abstract class Demo1PageModel : AbpPageModel
{
    protected Demo1PageModel()
    {
        LocalizationResourceType = typeof(Demo1Resource);
    }
}
