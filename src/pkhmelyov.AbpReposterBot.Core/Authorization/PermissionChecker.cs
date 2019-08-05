using Abp.Authorization;
using pkhmelyov.AbpReposterBot.Authorization.Roles;
using pkhmelyov.AbpReposterBot.Authorization.Users;

namespace pkhmelyov.AbpReposterBot.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
