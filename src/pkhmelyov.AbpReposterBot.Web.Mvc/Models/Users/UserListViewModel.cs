using System.Collections.Generic;
using pkhmelyov.AbpReposterBot.Roles.Dto;
using pkhmelyov.AbpReposterBot.Users.Dto;

namespace pkhmelyov.AbpReposterBot.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
