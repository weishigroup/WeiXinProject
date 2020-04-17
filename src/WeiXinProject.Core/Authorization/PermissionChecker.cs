using Abp.Authorization;
using WeiXinProject.Authorization.Roles;
using WeiXinProject.Authorization.Users;

namespace WeiXinProject.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
