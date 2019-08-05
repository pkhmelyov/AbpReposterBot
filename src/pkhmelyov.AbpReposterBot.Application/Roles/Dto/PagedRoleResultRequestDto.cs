using Abp.Application.Services.Dto;

namespace pkhmelyov.AbpReposterBot.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

