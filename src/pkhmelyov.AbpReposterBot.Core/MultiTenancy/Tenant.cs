using Abp.MultiTenancy;
using pkhmelyov.AbpReposterBot.Authorization.Users;

namespace pkhmelyov.AbpReposterBot.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
