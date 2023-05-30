using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Upendo.Modules.UpendoUserManaged.Models.DnnModel;
using static Telerik.Web.UI.OrgChartStyles;
using DotNetNuke.Common;
using Upendo.Modules.UpendoUserManaged.Data;
using Upendo.Modules.UpendoUserManaged.ViewModels;
using DotNetNuke.Entities.Users;

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
        public static List<RolesViewModel> GetRoles()
        {
            ModuleDbContext _context = new ModuleDbContext();
            List<RolesViewModel> roles = new List<RolesViewModel>();
            var rolesDnn = _context.Roles.ToList();
            foreach (var item in rolesDnn)
            {
                var rolViewModel = new RolesViewModel
                {
                    PortalId = item.PortalId,
                    RoleName = item.RoleName,
                    RoleId = item.RoleId
                };
                roles.Add(rolViewModel);
            }
            return roles;
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