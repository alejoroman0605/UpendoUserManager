
using DotNetNuke.Entities.Users;
using DotNetNuke.Framework.JavaScriptLibraries;
using DotNetNuke.Security.Roles;
using DotNetNuke.Web.Mvc.Framework.ActionFilters;
using DotNetNuke.Web.Mvc.Framework.Controllers;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Upendo.Modules.UserManager.Models.DnnModel;
using Upendo.Modules.UserManager.Utility;
using Upendo.Modules.UserManager.Utility;
using Upendo.Modules.UserManager.ViewModels;

namespace Upendo.Modules.UserManager.Controllers
{
    [DnnHandleError]
    public class UserManageController : DnnController
    {
        [ModuleAction(ControlKey = "Edit", TitleKey = "AddItem")]
        public ActionResult Index(double? take, int? skip, string filter, int? goToPage, string search, string orderBy, string order)
        {
            var takeValue = take ?? default;
            var skipValue = take == null ? default : skip.Value;
            var portalId = ModuleContext.PortalId;
            var portalSettings = ModuleContext.PortalSettings;
            string serverUrl = $"{Request.Url.Scheme}://{portalSettings.PortalAlias.HTTPAlias}";
            ViewBag.Filter = filter;
            var pagination= new Pagination()
            {
                Take = takeValue,
                Skip = skipValue,
                Filter = filter,
                GoToPage = goToPage,
                PortalId = portalId,
                Search = search,
                OrderBy = orderBy,
                Order = order,
                ServerUrl = serverUrl,
            };
            var result = UserRepository.GetUsers(pagination);
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
            for (var i = 1; i < 3000; i++)
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
                UserRepository.CreateUser(item, portalId);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Create(UserViewModel item)
        {
            //var portalId = PortalController.Instance.GetCurrentPortalSettings().PortalId;
            var portalId = ModuleContext.PortalId;
            UserRepository.CreateUser(item, portalId);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int itemId)
        {
            var portalId = ModuleContext.PortalId;
            var item = UserRepository.GetUser(portalId, itemId);
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel item)
        {
            //int editedFor = User.UserID;
            var portalId = ModuleContext.PortalId;
            UserRepository.EditUser(portalId, item);
            return RedirectToDefaultRoute();
        }
        public ActionResult Details(int itemId)
        {
            DotNetNuke.Framework.JavaScriptLibraries.JavaScript.RequestRegistration(CommonJs.DnnPlugins);
            var portalId = ModuleContext.PortalId;
            var item = UserRepository.GetUser(portalId, itemId);
            return View(item);
        }
        public ActionResult Delete(int itemId)
        {
            UserRepository.DeleteUser(itemId);   
            return RedirectToDefaultRoute();
        }
        public ActionResult ChangePassword(int itemId)
        {
            DotNetNuke.Framework.JavaScriptLibraries.JavaScript.RequestRegistration(CommonJs.DnnPlugins);
            var portalId = ModuleContext.PortalId;
            var item = UserRepository.GetUser(portalId, itemId);
            return View(item);
        }

        [HttpPost]
        public ActionResult ChangePassword(UserViewModel user)
        {
            if (user.Password.Equals(user.ConfirmPassword))
            {
                UserRepository.ChangePassword(user.UserId, user.Password);
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

        public ActionResult UserRoles(double? take, int? skip, int? goToPage, string search, int itemId, int? roleId, string actionView)
        {
            double takeValue = take == null ? default : take.Value;
            int skipValue = take == null ? default : skip.Value;
            int roleIdValue = roleId == null ? default : roleId.Value;

            var portalId = ModuleContext.PortalId;

            if (roleId != null)
            {
                if (actionView == "Add")
                {
                    RoleController.Instance.AddUserRole(portalId, itemId, roleIdValue, RoleStatus.Approved, false, DateTime.Now, DateTime.Now.AddDays(30));

                }
                else
                {
                    RoleController.Instance.UpdateUserRole(portalId, itemId, roleIdValue, RoleStatus.Approved, false, true);
                }
            }
            ViewBag.User = UserRepository.GetUser(portalId, itemId);
            var result = UserRepository.GetRolesByUser(takeValue, skipValue, goToPage, portalId, search, itemId);
            return View(result);
        }
    }
}
