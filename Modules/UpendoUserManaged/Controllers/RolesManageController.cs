
using DotNetNuke.Entities.Users;
using DotNetNuke.Framework.JavaScriptLibraries;
using DotNetNuke.Security.Roles;
using DotNetNuke.Web.Mvc.Framework.ActionFilters;
using DotNetNuke.Web.Mvc.Framework.Controllers;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Upendo.Modules.UpendoUserManaged.Models.DnnModel;
using Upendo.Modules.UpendoUserManaged.Utility;
using Upendo.Modules.UpendoUserManaged.ViewModels;

namespace Upendo.Modules.UpendoUserManaged.Controllers
{
    [DnnHandleError]
    public class RolesManageController : DnnController
    {
        [ModuleAction(ControlKey = "Edit", TitleKey = "AddItem")]
        public ActionResult Index(int? take, int? skip, string filter,int? goToPage, string search, string orderBy, string order)
        {
            int takeValue = take == null ? default : take.Value;
            int skipValue = take == null ? default : skip.Value;
            var portalId = ModuleContext.PortalId;
            ViewBag.Filter = filter;
            var result = Functions.GetUsers(takeValue, skipValue, filter,goToPage, portalId, search, orderBy, order);
            return View(result);
        }

        public ActionResult Create()
        {
            DotNetNuke.Framework.JavaScriptLibraries.JavaScript.RequestRegistration(CommonJs.DnnPlugins);
            return View();
        }
        public ActionResult CreateUserTest()
        {
            var portalId = ModuleContext.PortalId;
            for (int i = 1001; i < 2000; i++)
            {
                var item = new UserViewModel()
                {
                    Username = "user" + i,
                    LastName = "Last Name " + i,
                    FirstName = "User" + i,
                    Email = "user" + i + "@gmail.com",
                    IsSuperUser = false,
                    IsDeleted = false,
                    Approved = true,
                    Password = "Admin123*"
                };
                UsuarioRepository.CreateUser(item, portalId);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Create(UserViewModel item)
        {
            //var portalId = PortalController.Instance.GetCurrentPortalSettings().PortalId;
            var portalId = ModuleContext.PortalId;
            UsuarioRepository.CreateUser(item, portalId);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int itemId)
        {
            var portalId = ModuleContext.PortalId;
            var item = UsuarioRepository.GetUser(portalId, itemId);
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel item)
        {
            //int editedFor = User.UserID;
            var portalId = ModuleContext.PortalId;
            UsuarioRepository.EditUser(portalId, item);
            return RedirectToDefaultRoute();
        }
        public ActionResult Details(int itemId)
        {
            DotNetNuke.Framework.JavaScriptLibraries.JavaScript.RequestRegistration(CommonJs.DnnPlugins);
            var portalId = ModuleContext.PortalId;
            var item = UsuarioRepository.GetUser(portalId, itemId);
            return View(item);
        }
        public ActionResult Delete(int itemId)
        {
            UsuarioRepository.DeleteUser(itemId);
            return RedirectToDefaultRoute();
        }
        public ActionResult ChangePassword(int itemId)
        {
            DotNetNuke.Framework.JavaScriptLibraries.JavaScript.RequestRegistration(CommonJs.DnnPlugins);
            var portalId = ModuleContext.PortalId;
            var item = UsuarioRepository.GetUser(portalId, itemId);
            return View(item);
        }

        [HttpPost]
        public ActionResult ChangePassword(UserViewModel user)
        {
            if (user.Password.Equals(user.ConfirmPassword))
            {
                UsuarioRepository.ChangePassword(user.UserId, user.Password);
            }
            return RedirectToDefaultRoute();
        }
        public ActionResult DeleteUnauthorizedUsers()
        {
            var portalId = ModuleContext.PortalId;
            UserController.DeleteUnauthorizedUsers(portalId);
            return RedirectToDefaultRoute();
        }
        public ActionResult RemoveDeletedUsers()
        {
            var portalId = ModuleContext.PortalId;
            UserController.RemoveDeletedUsers(portalId);
            return RedirectToDefaultRoute();
        }

        public ActionResult UserRoles(int itemId)
        {
            var portalId = ModuleContext.PortalId;
            ViewBag.User = UsuarioRepository.GetUser(portalId, itemId);
            var result = Functions.GetRolesByUser(portalId, itemId);
            return View(result);
        }

        public ActionResult AddUserToRole(int roleId, int userId)
        {
            var portalId = ModuleContext.PortalId;
            RoleController.Instance.AddUserRole(portalId, userId, roleId, RoleStatus.Approved, false, DateTime.Now, DateTime.Now.AddDays(30));
            return RedirectToAction("Index");
            //return RedirectToAction("UserRoles",  new { itemId = userId });
        }
        public ActionResult DeleteUserRole(int roleId, int userId)
        {
            var portalId = ModuleContext.PortalId;
            RoleController.Instance.UpdateUserRole(portalId, userId, roleId, RoleStatus.Approved, false, true);
            return RedirectToAction("Index");
            //return RedirectToAction("UserRoles",  new { itemId = userId });
        }
    }
}
