
using DotNetNuke.Entities.Users;
using DotNetNuke.Framework.JavaScriptLibraries;
using DotNetNuke.UI.UserControls;
using DotNetNuke.Web.Mvc.Framework.ActionFilters;
using DotNetNuke.Web.Mvc.Framework.Controllers;
using System;
using System.Data.Entity;
using System.Web.Mvc;
using Upendo.Modules.UpendoUserManaged.Components;
using Upendo.Modules.UpendoUserManaged.Data;
using Upendo.Modules.UpendoUserManaged.Models;
using Upendo.Modules.UpendoUserManaged.Models.DnnModel;
using Upendo.Modules.UpendoUserManaged.Utility;
using DotNetNuke.Entities.Users;
using DotNetNuke.Security.Membership;

namespace Upendo.Modules.UpendoUserManaged.Controllers
{
    [DnnHandleError]
    public class UserManageController : DnnController
    {
        
        public ActionResult Delete(int itemId)
        {
            UsuarioRepository.DeleteUser(itemId);
            return RedirectToDefaultRoute();
        }

        [ModuleAction(ControlKey = "Create", TitleKey = "AddItem")]
        public ActionResult Create()
        {
            DotNetNuke.Framework.JavaScriptLibraries.JavaScript.RequestRegistration(CommonJs.DnnPlugins);
            return View();
        }

        [HttpPost]
        public ActionResult Create(Users item)
        {
            //var portalId = PortalController.Instance.GetCurrentPortalSettings().PortalId;
            var portalId = ModuleContext.PortalId;
            UsuarioRepository.CreateUser(item, portalId);
            return RedirectToDefaultRoute();
        }

        public ActionResult Edit(int itemId)
        {
            DotNetNuke.Framework.JavaScriptLibraries.JavaScript.RequestRegistration(CommonJs.DnnPlugins);
            var item = UsuarioRepository.ObtenerUsuario(itemId);
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
            var item = UsuarioRepository.ObtenerUsuario(itemId);
            return View(item);
        }

        [ModuleAction(ControlKey = "Edit", TitleKey = "AddItem")]
        public ActionResult Index()
        {
            var items = Functions.ObtenerUsuarios();
            return View(items);
        }

        public ActionResult ChangePassword(int itemId)
        {
            DotNetNuke.Framework.JavaScriptLibraries.JavaScript.RequestRegistration(CommonJs.DnnPlugins);
            var item = UsuarioRepository.ObtenerUsuario(itemId);
            return View(item);
        }

        [HttpPost]
        public ActionResult ChangePassword(int itemId, string newPassword, string confrimPassword)
        {
            if (newPassword.Equals(confrimPassword))
            {
                UsuarioRepository.ChangePassword(itemId, newPassword);
            }
            return RedirectToDefaultRoute();
        }


    }
}
