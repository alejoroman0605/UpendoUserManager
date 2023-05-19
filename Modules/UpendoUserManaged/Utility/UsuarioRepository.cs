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

namespace Upendo.Modules.UpendoUserManaged.Utility
{
    public class UsuarioRepository
    {
        public static UserViewModel ObtenerUsuario(int id)
        {
            ModuleDbContext _context = new ModuleDbContext();
            var usersDnn = _context.Users.ToList();
            var aspnetMemberships = _context.AspnetMemberships.ToList();

            var users = from u in usersDnn
                        join m in aspnetMemberships on u.Email equals m.Email
                        select new UserViewModel
                        {
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            Email = u.Email,
                            Username = u.Username,
                            IsSuperUser = u.IsSuperUser,
                            Approved=m.IsApproved,
                            UserRoles=u.UserRoles,
                        };
            var result = users.SingleOrDefault(s => s.UserId == id);
            return result;
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
            UserController.CreateUser(ref userInfo);
        }

        public static void EditUser(Users user, int editedFor)
        {
            ModuleDbContext _context = new ModuleDbContext();
            var userFind = _context.Set<Users>().Find(user.UserId);
            userFind.Username = user.Username;
            userFind.FirstName = user.FirstName;
            userFind.LastName = user.LastName;
            userFind.DisplayName = user.FirstName + " " + user.LastName;
            userFind.LastModifiedOnDate = DateTime.UtcNow;
            userFind.LastModifiedByUserId = editedFor;
            _context.Entry(userFind).State = EntityState.Modified;
            _context.SaveChanges();
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
                DotNetNuke.Security.Membership.MembershipProvider membershipProvider = DotNetNuke.Security.Membership.MembershipProvider.Instance();
                membershipProvider.ChangePassword(user, user.Membership.Password, newPassword);
            }
        }
    }
}