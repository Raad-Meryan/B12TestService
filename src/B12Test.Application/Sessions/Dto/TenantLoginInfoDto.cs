using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using B12Test.MultiTenancy;

namespace B12Test.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
