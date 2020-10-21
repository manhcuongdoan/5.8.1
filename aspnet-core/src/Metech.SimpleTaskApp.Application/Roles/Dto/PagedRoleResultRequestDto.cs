using Abp.Application.Services.Dto;

namespace Metech.SimpleTaskApp.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

