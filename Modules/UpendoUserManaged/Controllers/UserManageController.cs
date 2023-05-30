
using DotNetNuke.Entities.Users;
using DotNetNuke.Framework.JavaScriptLibraries;
using DotNetNuke.Web.Mvc.Framework.ActionFilters;
using DotNetNuke.Web.Mvc.Framework.Controllers;
using System.Collections.Generic;
using System.Web.Mvc;
using Upendo.Modules.UpendoUserManaged.Models.DnnModel;
using Upendo.Modules.UpendoUserManaged.Utility;
using Upendo.Modules.UpendoUserManaged.ViewModels;

namespace Upendo.Modules.UpendoUserManaged.Controllers
{
    [DnnHandleError]
    public class UserManageController : DnnController
    {
        [ModuleAction(ControlKey = "Edit", TitleKey = "AddItem")]
        public ActionResult Index(string filter)
        {
            var portalId = ModuleContext.PortalId;
            var result = Functions.GetUsers(filter, portalId);
            ViewBag.Filter = filter;
            return View(result);
        }

        public ActionResult Create()
        {
            DotNetNuke.Framework.JavaScriptLibraries.JavaScript.RequestRegistration(CommonJs.DnnPlugins);
            return View();
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
            DotNetNuke.Framework.JavaScriptLibraries.JavaScript.RequestRegistration(CommonJs.DnnPlugins);
            var item = UsuarioRepository.GetUser(itemId);
            //ViewBag.Roles = Functions.GetRoles();
            ViewBag.Roles = new SelectList(Functions.GetRoles(), "RoleId", "RoleName");
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(Users item)
        {
            int editedFor = User.UserID;
            UsuarioRepository.EditUser(item, editedFor);
            return RedirectToDefaultRoute();
        }
        public ActionResult Details(int itemId)
        {
            DotNetNuke.Framework.JavaScriptLibraries.JavaScript.RequestRegistration(CommonJs.DnnPlugins);
            var item = UsuarioRepository.GetUser(itemId);
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
            var item = UsuarioRepository.GetUser(itemId);
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
    }
}
