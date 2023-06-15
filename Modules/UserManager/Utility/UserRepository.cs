using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DotNetNuke.Entities.Users;
using DotNetNuke.Security.Roles;
using Upendo.Modules.UserManager.Data;
using Upendo.Modules.UserManager.Models.DnnModel;
using Upendo.Modules.UserManager.ViewModels;

namespace Upendo.Modules.UserManager.Utility
{
    /// <summary>
    /// User Repository
    /// </summary>
    public class UserRepository
    {
        /// <summary>
        /// Get all users by param
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <param name="filter"></param>
        /// <param name="goToPage"></param>
        /// <param name="portalId"></param>
        /// <param name="search"></param>
        /// <param name="orderBy"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public static DataTableResponse<Users> GetUsers(double take, int skip, string filter, int? goToPage, int portalId,
            string search, string orderBy, string order)
        {
            take = take == 0 ? 10 : take;
            var goToPageValue = goToPage ?? default;

            if (goToPage != null && goToPage != 0)
            {
                skip = (int)take * (goToPageValue - 1);
            }
            if (goToPage == 1)
            {
                skip = 0;
            }

            var context = new ModuleDbContext();
            switch (filter)
            {
                case "All":
                {
                    var users = context.Users.ToList();
                    var usersTotal = users.Count();
                    return Functions.ListOfUsers(users, usersTotal, take, skip, goToPageValue, search, orderBy, order);
                }
                case "Deleted":
                {
                    var deletedUsers = UserController.GetDeletedUsers(portalId).ToArray();
                    var users = (from UserInfo u in deletedUsers select Functions.MakeUser(u)).ToList();
                    var usersTotal = users.Count();
                    return Functions.ListOfUsers(users, usersTotal, take, skip, goToPageValue, search, orderBy, order);
                }
                case "Unauthorized":
                {
                    var unauthorizedUsers = UserController.GetUnAuthorizedUsers(portalId).ToArray();
                    var users = (from UserInfo u in unauthorizedUsers select Functions.MakeUser(u)).ToList();
                    var usersTotal = users.Count();
                    return Functions.ListOfUsers(users, usersTotal, take, skip, goToPageValue, search, orderBy, order);
                }
                case "SuperUsers":
                {
                    var users = context.Users.Where(u => u.IsSuperUser == true).ToList();
                    var usersTotal = users.Count();
                    return Functions.ListOfUsers(users, usersTotal, take, skip, goToPageValue, search, orderBy, order);
                }
                default:
                {
                    var getUsers = UserController.GetUsers(portalId).ToArray();
                    var users = (from UserInfo u in getUsers select Functions.MakeUser(u)).ToList();
                    var usersTotal = users.Count();
                    return Functions.ListOfUsers(users, usersTotal, take, skip, goToPageValue, search, orderBy, order);
                }
            }
        }

        /// <summary>
        /// Returns the roles of the user
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <param name="goToPage"></param>
        /// <param name="portalId"></param>
        /// <param name="search"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public static DataTableResponse<RolesViewModel> GetRolesByUser(double take, int skip, int? goToPage, int
            portalId, string search, int itemId)
        {
            var roles = RoleController.Instance.GetRoles(portalId);
            var rolesViewModel = new List<RolesViewModel>();
            var userInfo = UserController.GetUserById(portalId, itemId);

            foreach (var item in roles)
            {
                if (item.Status != RoleStatus.Approved) continue;
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
            var result = rolesViewModel.OrderByDescending(r => r.Index).ToList();
            double rolesTotal = rolesViewModel.Count();

            take = take == 0 ? 10 : take;
            var goToPageValue = goToPage ?? default;

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
            var total = rolesTotal / take;
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

        /// <summary>
        /// Return the user
        /// </summary>
        /// <param name="portalId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static UserViewModel GetUser(int portalId, int id)
        {
            var context = new ModuleDbContext();
            //var u = context.Users.FirstOrDefault(x => x.UserId == id);
            var userInfo = UserController.GetUserById(portalId, id);

            var user = new UserViewModel
            {
                UserId = userInfo.UserID,
                DisplayName = userInfo.DisplayName,
                FirstName = userInfo.FirstName,
                LastName = userInfo.LastName,
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
        /// <summary>
        /// Create User
        /// </summary>
        /// <param name="user"></param>
        /// <param name="portalId"></param>
        public static void CreateUser(UserViewModel user, int portalId)
        {
            var userInfo = new UserInfo
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Username = user.Username,
                PortalID = portalId,
                IsSuperUser = user.IsSuperUser,
                Membership =
                {
                    Password = user.Password,
                    Approved = user.Approved
                }
            };

            var roles = RoleController.Instance.GetRoles(portalId).Where(r => r.AutoAssignment == true);
            foreach (var item in roles)
            {
                userInfo.Roles.Append(item.RoleName);
            }
            UserController.CreateUser(ref userInfo, user.SendEmail);
        }

        /// <summary>
        /// Edit the user
        /// </summary>
        /// <param name="portalId"></param>
        /// <param name="user"></param>
        public static void EditUser(int portalId, UserViewModel user)
        {
            var userInfo = UserController.GetUserById(portalId, user.UserId);
            if (userInfo == null) return;
            userInfo.FirstName = user.FirstName;
            userInfo.LastName = user.LastName;
            userInfo.Email = user.Email;
            userInfo.Username = user.Username;
            userInfo.PortalID = portalId;
            userInfo.IsSuperUser = user.IsSuperUser;
            userInfo.IsDeleted = user.IsDeleted;
            userInfo.Membership.Approved = user.Approved;
            userInfo.Membership.LockedOut = user.LockedOut;
            if (!string.IsNullOrEmpty(user.Password) && user.Password != " ")
            {
                ChangePassword(user.UserId, user.Password);
            }
            if (user.NewUserRol != null)
            {
                userInfo.Roles[userInfo.Roles.Count() - 1] = user.NewUserRol;
            }
            UserController.UpdateUser(portalId, userInfo);
        }

        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="itemId"></param>
        public static void DeleteUser(int itemId)
        {

            var context = new ModuleDbContext();
            var userFind = context.Set<Users>().Find(itemId);
            var user = UserController.GetUserByName(0, userFind.Username);
            if (user != null)
            {
                UserController.DeleteUser(ref user, true, true);
                // Delete from aspnet_Users table
                DotNetNuke.Security.Membership.MembershipProvider membershipProvider =
                DotNetNuke.Security.Membership.MembershipProvider.Instance();
                membershipProvider.DeleteUser(user);
            }
            userFind.IsDeleted = true;
            context.Entry(userFind).State = EntityState.Modified;
            context.SaveChanges();
        }

        public static void ChangePassword(int itemId, string newPassword)
        {

            var context = new ModuleDbContext();
            var userFind = context.Set<Users>().Find(itemId);
            if (userFind == null) return;
            var user = UserController.GetUserByName(0, userFind.Username);
            if (user != null)
            {
                UserController.ResetAndChangePassword(user, newPassword);
            }
        }
    }
}
