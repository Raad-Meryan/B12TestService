using System.Threading.Tasks;
using B12Test.Configuration.Dto;

namespace B12Test.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
