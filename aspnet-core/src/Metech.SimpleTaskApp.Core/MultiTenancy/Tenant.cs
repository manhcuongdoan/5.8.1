using Abp.MultiTenancy;
using Metech.SimpleTaskApp.Authorization.Users;

namespace Metech.SimpleTaskApp.MultiTenancy
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
