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
        public static UserViewModel GetUser(int portalId, int id)
        {
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

            var roles = RoleController.Instance.GetRoles(portalId).Where(r=>r.AutoAssignment==true);
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
                if (user.NewUserRol!=null)
                {
                    userInfo.Roles[userInfo.Roles.Count()-1]=user.NewUserRol;
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
                DotNetNuke.Security.Membership.MembershipProvider membershipProvider = DotNetNuke.Security.Membership.MembershipProvider.Instance();
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