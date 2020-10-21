using System.Threading.Tasks;
using Abp.Application.Services;
using Metech.SimpleTaskApp.Authorization.Accounts.Dto;

namespace Metech.SimpleTaskApp.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
