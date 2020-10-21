using Abp.Application.Services;
using Metech.SimpleTaskApp.MultiTenancy.Dto;

namespace Metech.SimpleTaskApp.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

