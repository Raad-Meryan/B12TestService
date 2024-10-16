using System.Threading.Tasks;
using Abp.Application.Services;
using B12Test.Sessions.Dto;

namespace B12Test.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
