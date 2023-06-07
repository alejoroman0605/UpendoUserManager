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
        public static DataTableResponse<Users> GetUsers(int take, int skip, string filter, int? goToPage, int portalId, string search, string orderBy, string order)
        {
            take = take == 0 ? 10 : take;
            int goToPageValue = goToPage == null ? default : goToPage.Value;

            if (goToPage != null && goToPage != 0)
            {
                skip = take * goToPageValue;
            }
            if (goToPage == 1)
            {
                skip = 0;
            }

            ModuleDbContext _context = new ModuleDbContext();
            if (filter == "All")
            {
                var users = _context.Users.ToList();
                var usersTotal = users.Count();
                return ListOfUsers(users, usersTotal, take, skip, goToPageValue, search, orderBy, order);
            }
            if (filter == "Deleted")
            {
                var users = new List<Users>();
                var deletedUsers = UserController.GetDeletedUsers(portalId).ToArray();
                foreach (UserInfo u in deletedUsers)
                {
                    users.Add(MakeUser(u));
                }
                var usersTotal = users.Count();
                return ListOfUsers(users, usersTotal, take, skip, goToPageValue, search, orderBy, order);
            }
            if (filter == "Unauthorized")
            {
                var users = new List<Users>();
                var unauthorizedUsers = UserController.GetUnAuthorizedUsers(portalId).ToArray();
                foreach (UserInfo u in unauthorizedUsers)
                {
                    users.Add(MakeUser(u));
                }
                var usersTotal = users.Count();
                return ListOfUsers(users, usersTotal, take, skip, goToPageValue, search, orderBy, order);
            }
            if (filter == "SuperUsers")
            {
                var users = _context.Users.Where(u => u.IsSuperUser == true).ToList();
                var usersTotal = users.Count();
                return ListOfUsers(users, usersTotal, take, skip, goToPageValue, search, orderBy, order);
            }
            else
            {
                var getUsers = UserController.GetUsers(portalId).ToArray();
                var users = new List<Users>();
                foreach (UserInfo u in getUsers)
                {
                    users.Add(MakeUser(u));
                }
                var usersTotal = users.Count();
                return ListOfUsers(users, usersTotal, take, skip, goToPageValue, search, orderBy, order);
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
                FirstName = u.FirstName,
                LastName = u.LastName,
                Username = u.Username,
                DisplayName = u.DisplayName,
                Email = u.Email,
                IsSuperUser = u.IsSuperUser,
                IsDeleted = u.IsDeleted,
            };
            return user;
        }
        public static DataTableResponse<Users> ListOfUsers(List<Users> users, int usersTotal, int take, int skip, int goToPageValue, string search, string orderBy, string order)
        {
            if (!string.IsNullOrEmpty(search))
            {
                users = users.Where(e => string.Concat(e.FirstName, e.DisplayName, e.Email, e.Username).Contains(search)).ToList();
                usersTotal = users.Count();
            }
            users = users.Skip(skip).Take(take).ToList();
            var pagesTotal = (usersTotal / take) == 0 ? 1 : (usersTotal / take);
            if (!string.IsNullOrEmpty(orderBy))
            {
                switch (orderBy)
                {
                    case "Username":
                        users = order == "desc" ? users.OrderByDescending(x => x.Username).ToList() : users.OrderBy(x => x.Username).ToList();
                        break;
                    case "DisplayName":
                        users = order == "desc" ? users.OrderByDescending(x => x.DisplayName).ToList() : users.OrderBy(x => x.DisplayName).ToList();
                        break;
                    case "Email":
                        users = order == "desc" ? users.OrderByDescending(x => x.Email).ToList() : users.OrderBy(x => x.Email).ToList();
                        break;
                }
            }
            return new DataTableResponse<Users>() { Take = take, Skip = skip, PagesTotal = pagesTotal, RecordsTotal = usersTotal, GoToPage = goToPageValue, Search = search, OrderBy = orderBy, Order = order, Data = users };
        }
    }
}