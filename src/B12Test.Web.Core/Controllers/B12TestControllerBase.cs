using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace B12Test.Controllers
{
    public abstract class B12TestControllerBase: AbpController
    {
        protected B12TestControllerBase()
        {
            LocalizationSourceName = B12TestConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
