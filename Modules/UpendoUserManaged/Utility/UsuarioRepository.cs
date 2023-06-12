using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Upendo.Modules.UpendoUserManaged.Models.DnnModel;
using static Telerik.Web.UI.OrgChartStyles;
using DotNetNuke.Common;
using Upendo.Modules.UpendoUserManaged.Data;
using DotNetNuke.UI.UserControls;
using System.Data.Entity;
using System.Text;
using System.Web.Security;
using DotNetNuke.Entities.Users;
using Hotcakes.Commerce.Marketing.PromotionQualifications;
using DotNetNuke.Security.Membership;
using Upendo.Modules.UpendoUserManaged.ViewModels;
using Upendo.Modules.UpendoUserManaged.Controllers;
using DotNetNuke.Security.Roles;

namespace Upendo.Modules.UpendoUserManaged.Utility
{
    public class UsuarioRepository
    {
        public static DataTableResponse<Users> GetUsers(double take, int skip, string filter, int? goToPage, int portalId,
            string search, string orderBy, string order)
        {
            take = take == 0 ? 10 : take;
            int goToPageValue = goToPage == null ? default : goToPage.Value;

            if (goToPage != null && goToPage != 0)
            {
                skip = (int)take * (goToPageValue - 1);
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
                return Functions.ListOfUsers(users, usersTotal, take, skip, goToPageValue, search, orderBy, order);
            }
            if (filter == "Deleted")
            {
                var users = new List<Users>();
                var deletedUsers = UserController.GetDeletedUsers(portalId).ToArray();
                foreach (UserInfo u in deletedUsers)
                {
                    users.Add(Functions.MakeUser(u));
                }
                var usersTotal = users.Count();
                return Functions.ListOfUsers(users, usersTotal, take, skip, goToPageValue, search, orderBy, order);
            }
            if (filter == "Unauthorized")
            {
                var users = new List<Users>();
                var unauthorizedUsers = UserController.GetUnAuthorizedUsers(portalId).ToArray();
                foreach (UserInfo u in unauthorizedUsers)
                {
                    users.Add(Functions.MakeUser(u));
                }
                var usersTotal = users.Count();
                return Functions.ListOfUsers(users, usersTotal, take, skip, goToPageValue, search, orderBy, order);
            }
            if (filter == "SuperUsers")
            {
                var users = _context.Users.Where(u => u.IsSuperUser == true).ToList();
                var usersTotal = users.Count();
                return Functions.ListOfUsers(users, usersTotal, take, skip, goToPageValue, search, orderBy, order);
            }
            else
            {
                var getUsers = UserController.GetUsers(portalId).ToArray();
                var users = new List<Users>();
                foreach (UserInfo u in getUsers)
                {
                    users.Add(Functions.MakeUser(u));
                }
                var usersTotal = users.Count();
                return Functions.ListOfUsers(users, usersTotal, take, skip, goToPageValue, search, orderBy, order);
            }
        }

        public static DataTableResponse<RolesViewModel> GetRolesByUser(double take, int skip, int? goToPage, int
            portalId, string search, int itemId)
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
            double rolesTotal = rolesViewModel.Count();

            take = take == 0 ? 10 : take;
            int goToPageValue = goToPage == null ? default : goToPage.Value;

            if (goToPage != null && goToPage != 0)
            {
                skip = (int)take * (goToPageValue - 1);
            }
            if (goToPage == 1)
            {
                skip = 0;
            }
            if (!string.IsNullOrEmpty(search) && search != " ")
            {
                result = result.Where(e => e.RoleName.Contains(search)).ToList();
                rolesTotal = rolesViewModel.Count();
            }
            double total = rolesTotal / take;
            var pagesTotal = Math.Ceiling(Math.Max(total, 2)) == 0 ? 1 : Math.Ceiling(Math.Max(total, 2));
            result = result.Skip(skip).Take((int)take).ToList();
            return new DataTableResponse<RolesViewModel>()
            {
                Take = take,
                Skip = skip,
                PagesTotal =
                pagesTotal,
                RecordsTotal = rolesTotal,
                GoToPage = goToPageValue,
                Search = search,
                Data =
                result
            };
        }

        public static UserViewModel GetUser(int portalId, int id)
        {
            ModuleDbContext _context = new ModuleDbContext();
            var u = _context.Users.FirstOrDefault(x => x.UserId == id);
            var userInfo = UserController.GetUserById(portalId, id);

            var user = new UserViewModel
            {
                UserId = userInfo.UserID,
                DisplayName = userInfo.DisplayName,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = userInfo.Email,
                Username = userInfo.Username,
                IsSuperUser = userInfo.IsSuperUser,
                UserRoles = userInfo.Roles,
                CreatedOnDate = userInfo.CreatedOnDate,
                LastModifiedOnDate = userInfo.LastModifiedOnDate,
                IsDeleted = userInfo.IsDeleted,
                Approved = userInfo.Membership.Approved,
                UpdatePassword = userInfo.Membership.UpdatePassword,
                LockedOut = userInfo.Membership.LockedOut,
                PortalID = userInfo.PortalID,
            };
            return user;
        }
        public static void CreateUser(UserViewModel user, int portalId)
        {
            var userInfo = new UserInfo();
            userInfo.FirstName = user.FirstName;
            userInfo.LastName = user.LastName;
            userInfo.Email = user.Email;
            userInfo.Username = user.Username;
            userInfo.PortalID = portalId;
            userInfo.IsSuperUser = user.IsSuperUser;
            userInfo.Membership.Password = user.Password;
            userInfo.Membership.Approved = user.Approved;

            var roles = RoleController.Instance.GetRoles(portalId).Where(r => r.AutoAssignment == true);
            foreach (var item in roles)
            {
                userInfo.Roles.Append(item.RoleName);
            }
            UserController.CreateUser(ref userInfo, user.SendEmail);
        }

        public static void EditUser(int portalId, UserViewModel user)
        {
            var userInfo = UserController.GetUserById(portalId, user.UserId);
            if (userInfo != null)
            {
                userInfo.FirstName = user.FirstName;
                userInfo.LastName = user.LastName;
                userInfo.Email = user.Email;
                userInfo.Username = user.Username;
                userInfo.PortalID = portalId;
                userInfo.IsSuperUser = user.IsSuperUser;
                userInfo.IsDeleted = user.IsDeleted;
                userInfo.Membership.Approved = user.Approved;
                userInfo.Membership.LockedOut = user.LockedOut;
                if (user.NewUserRol != null)
                {
                    userInfo.Roles[userInfo.Roles.Count() - 1] = user.NewUserRol;
                }
                UserController.UpdateUser(portalId, userInfo);
            }
        }

        public static void DeleteUser(int itemId)
        {

            ModuleDbContext _context = new ModuleDbContext();
            var userFind = _context.Set<Users>().Find(itemId);
            UserInfo user = UserController.GetUserByName(0, userFind.Username);
            if (user != null)
            {
                UserController.DeleteUser(ref user, true, true);
                // Delete from aspnet_Users table
                DotNetNuke.Security.Membership.MembershipProvider membershipProvider =
                DotNetNuke.Security.Membership.MembershipProvider.Instance();
                membershipProvider.DeleteUser(user);
            }
            userFind.IsDeleted = true;
            _context.Entry(userFind).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public static void ChangePassword(int itemId, string newPassword)
        {

            ModuleDbContext _context = new ModuleDbContext();
            var userFind = _context.Set<Users>().Find(itemId);
            UserInfo user = UserController.GetUserByName(0, userFind.Username);
            if (user != null)
            {
                UserController.ResetAndChangePassword(user, newPassword);
            }
        }
    }
}
