using System.Threading.Tasks;
using Abp.Application.Services;
using B12Test.Authorization.Accounts.Dto;

namespace B12Test.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
