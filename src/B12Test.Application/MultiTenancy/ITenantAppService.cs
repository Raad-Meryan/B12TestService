using Abp.Application.Services;
using B12Test.MultiTenancy.Dto;

namespace B12Test.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

