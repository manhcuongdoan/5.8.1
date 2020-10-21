using Abp.Authorization;
using Metech.SimpleTaskApp.Authorization.Roles;
using Metech.SimpleTaskApp.Authorization.Users;

namespace Metech.SimpleTaskApp.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
