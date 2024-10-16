using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using B12Test.Configuration.Dto;

namespace B12Test.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : B12TestAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
