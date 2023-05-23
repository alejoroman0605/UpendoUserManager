using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Upendo.Modules.UpendoUserManaged.Models.DnnModel;
using static Telerik.Web.UI.OrgChartStyles;
using DotNetNuke.Common;
using Upendo.Modules.UpendoUserManaged.Data;

namespace Upendo.Modules.UpendoUserManaged.Utility
{
    public class Functions
    {
        public static IEnumerable<Users> GetUsers()
        {
            ModuleDbContext _context = new ModuleDbContext();
            var users = _context.Users.Where(s=>s.IsDeleted==false).ToList();

            return users;
        }

        public static IEnumerable<Roles> ObtenerRolesDelUsuario(int id)
        {
            ModuleDbContext _context = new ModuleDbContext();
            var roles = _context.UserRoles.Where(s=>s.UserId == id).ToList();
            var rolesInUser = new List<Roles>();
            foreach (var item in roles)
            {
                rolesInUser.Add(item.Role);
            }
            return rolesInUser;
        }
    }
}