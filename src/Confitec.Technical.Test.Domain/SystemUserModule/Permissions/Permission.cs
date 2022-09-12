using Confitec.Technical.Test.Infra.Crosscutting.Auth;

namespace Confitec.Technical.Test.Domain.SystemUserModule.Permissions
{
    public class Permission : Entity
    {
        public string Role { get; private set; }
        public virtual int SystemUserId { get; private set; }

        public SystemUser SystemUser { get; set; }

        public Permission()
        { }

        public static IList<Permission> AllPermissions()
        {
            return new List<Permission>()
            {
                new Permission()
                {
                    ID = 1,
                    Role = Roles.CanManageSystemUsers,
                    SystemUserId = 1
                },
                new Permission()
                {
                    ID = 2,
                    Role = Roles.CanManageObjects,
                    SystemUserId = 1
                },
                new Permission()
                {
                    ID = 3,
                    Role = Roles.CanChangeGeneralSettings,
                    SystemUserId = 1
                }
            };
        }
    }
}
