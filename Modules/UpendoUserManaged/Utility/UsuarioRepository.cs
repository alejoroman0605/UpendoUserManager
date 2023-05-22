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
<<<<<<< Updated upstream
        public static Users ObtenerUsuario(int id)
        {
            ModuleDbContext _context = new ModuleDbContext();
            var user = _context.Users.SingleOrDefault(s => s.UserId == id);
=======
        public static UserViewModel GetUser(int id)
        {
            ModuleDbContext _context = new ModuleDbContext();
            var userDnn = _context.Users.FirstOrDefault(x=>x.UserId == id);
            var user = new UserViewModel {
                UserId= userDnn.UserId,
                FirstName = userDnn.FirstName,
                LastName = userDnn.LastName,
                Email = userDnn.Email,
                Username = userDnn.Username,
                IsSuperUser = userDnn.IsSuperUser,
                Approved = Membership.GetUser(userDnn).IsApproved,
                UserRoles = userDnn.UserRoles,
            };
>>>>>>> Stashed changes
            return user;
        }

        public static void CreateUser(UserViewModel user,int portalId)
        {
            var userInfo = new UserInfo();
            userInfo.FirstName = user.FirstName;
            userInfo.LastName = user.LastName;
            userInfo.Email = user.Email;
            userInfo.Username = user.Username;
            userInfo.PortalID= portalId;
            userInfo.IsSuperUser = user.IsSuperUser;
            userInfo.Membership.Password = user.Password;
            userInfo.Membership.Approved = user.Approved;

            ModuleDbContext _context = new ModuleDbContext();
            var roles = _context.Roles.Where(r => r.AutoAssignment==true).ToList();
            foreach (var item in roles)
            {
                userInfo.Roles.Append(item.RoleName);
            }
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