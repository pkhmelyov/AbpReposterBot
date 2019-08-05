using System.Collections.Generic;
using pkhmelyov.AbpReposterBot.Roles.Dto;

namespace pkhmelyov.AbpReposterBot.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<RoleListDto> Roles { get; set; }

        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
