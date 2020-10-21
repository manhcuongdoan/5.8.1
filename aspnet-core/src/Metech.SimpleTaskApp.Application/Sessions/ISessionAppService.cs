using System.Threading.Tasks;
using Abp.Application.Services;
using Metech.SimpleTaskApp.Sessions.Dto;

namespace Metech.SimpleTaskApp.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
