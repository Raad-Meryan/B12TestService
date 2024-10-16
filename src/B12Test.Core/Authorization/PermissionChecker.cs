using Abp.Authorization;
using B12Test.Authorization.Roles;
using B12Test.Authorization.Users;

namespace B12Test.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
