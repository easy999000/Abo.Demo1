using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Abo.Demo1.Web.Pages;

public class IndexModel : Demo1PageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
