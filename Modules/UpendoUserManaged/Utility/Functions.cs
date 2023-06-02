using System.Collections.Generic;
using System.Linq;
using Upendo.Modules.UpendoUserManaged.Models.DnnModel;
using Upendo.Modules.UpendoUserManaged.Data;
using DotNetNuke.Entities.Users;
using DotNetNuke.Security.Roles;
using Upendo.Modules.UpendoUserManaged.ViewModels;

namespace Upendo.Modules.UpendoUserManaged.Utility
{
    public class Functions
    {
        public static IEnumerable<Users> GetUsers(string filter, int portalId)
        {
            ModuleDbContext _context = new ModuleDbContext();
            if (filter == "All")
            {
                var users = _context.Users.ToList();
                return users;
            }
            if (filter == "Deleted")
            {
                var items = new List<Users>();
                var deletedUsers = UserController.GetDeletedUsers(portalId).ToArray();
                foreach (UserInfo u in deletedUsers)
                {
                    items.Add(MakeUser(u));
                }
                return items;
            }
            if (filter == "Unauthorized")
            {
                var items = new List<Users>();
                var deletedUsers = UserController.GetUnAuthorizedUsers(portalId).ToArray();
                foreach (UserInfo u in deletedUsers)
                {
                    items.Add(MakeUser(u));
                }
                return items;
            }
            if (filter == "SuperUsers")
            {
                var users = _context.Users.Where(u => u.IsSuperUser == true).ToList();
                return users;
                //var items = new List<Users>();
                ////(bool includeDeleted, bool superUsersOnly, int portalId)
                //var users = UserController.GetUsers(false, true, portalId).ToArray();
                //foreach (UserInfo u in users)
                //{
                //    items.Add(MakeUser(u));
                //}
                //return items;
            }
            else
            {
                var users = new List<Users>();
                var getUsers = UserController.GetUsers(portalId).ToArray();
                foreach (UserInfo u in getUsers)
                {
                    users.Add(MakeUser(u));
                }
                return users;
            }
        }
        public static List<RolesViewModel> GetRolesByUser(int portalId, int itemId)
        {
            var roles = RoleController.Instance.GetRoles(portalId);
            var rolesViewModel = new List<RolesViewModel>();
            var userInfo = UserController.GetUserById(portalId, itemId);

            foreach (var item in roles)
            {
                if (item.Status == RoleStatus.Approved)
                {
                    var rolViewModel = new RolesViewModel()
                    {
                        RoleId = item.RoleID,
                        RoleName = item.RoleName,
                        PortalId = item.PortalID,
                        HasRole = false,
                        Index = 1,
                    };
                    if (userInfo.Roles.FirstOrDefault(r => r == item.RoleName) != null)
                    {
                        rolViewModel.HasRole = true;
                        rolViewModel.Index = 2;
                    }
                    rolesViewModel.Add(rolViewModel);
                }
            }
            var result = rolesViewModel.OrderByDescending(r => r.Index).ToList();
            return result;
        }
        public static Users MakeUser(UserInfo u)
        {
            var user = new Users()
            {
                UserId = u.UserID,
                Username = u.Username,
                DisplayName = u.DisplayName,
                Email = u.Email,
                IsSuperUser = u.IsSuperUser,
                IsDeleted = u.IsDeleted,
            };
            return user;
        }
    }
}