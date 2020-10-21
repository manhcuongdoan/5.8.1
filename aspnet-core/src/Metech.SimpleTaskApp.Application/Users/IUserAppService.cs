using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Metech.SimpleTaskApp.Roles.Dto;
using Metech.SimpleTaskApp.Users.Dto;

namespace Metech.SimpleTaskApp.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);

        Task<bool> ChangePassword(ChangePasswordDto input);
    }
}
