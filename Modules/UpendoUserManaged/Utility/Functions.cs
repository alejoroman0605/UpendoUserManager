using System.Collections.Generic;
using System.Linq;
using Upendo.Modules.UpendoUserManaged.Models.DnnModel;
using Upendo.Modules.UpendoUserManaged.Data;
using DotNetNuke.Entities.Users;
using DotNetNuke.Security.Roles;

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

        public static IEnumerable<Roles> GetUserRoles(int id)
        {
            ModuleDbContext _context = new ModuleDbContext();
            var roles = _context.UserRoles.Where(s => s.UserId == id).ToList();
            var rolesInUser = new List<Roles>();
            foreach (var item in roles)
            {
                rolesInUser.Add(item.Role);
            }
            return rolesInUser;
        }
        public static List<RoleInfo> GetRolesByPortal(int portalId)
        {
            var items = new List<RoleInfo>();
            var roles= RoleController.GetRoleGroups(portalId);
            foreach (RoleInfo r in roles)
            {
                items.Add(r);
            }
            return items;
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