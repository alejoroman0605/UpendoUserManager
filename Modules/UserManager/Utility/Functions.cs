using System.Collections.Generic;
using System.Linq;
using Upendo.Modules.UserManager.Models.DnnModel;
using Upendo.Modules.UserManager.Data;
using DotNetNuke.Entities.Users;
using DotNetNuke.Security.Roles;
using Upendo.Modules.UserManager.ViewModels;
using System;
using System.Web;
using System.Net;

namespace Upendo.Modules.UserManager.Utility
{
    public class Functions
    {
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
        }public static Users MakeUserFromViewModel(UserViewModel u)
        {
            var user = new Users()
            {
                UserId = u.UserId,
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
        public static DataTableResponse<Users> ListOfUsers(List<Users> users, int usersTotal, Pagination pagination)
        {
            if (!string.IsNullOrEmpty(pagination.Search) && pagination.Search != " ")
            {
                users = users.Where(e => string.Concat(e.FirstName.ToLower(), e.DisplayName.ToLower(), e.Email.ToLower(), e.Username.ToLower()).Contains(pagination.Search.Trim().ToLower())).ToList();
                usersTotal = users.Count();
                pagination.Skip = 0;
            }
            users = users.Skip(pagination.Skip).Take((int)pagination.Take).ToList();
            double total = usersTotal / pagination.Take;
            var pagesTotal = Math.Ceiling(Math.Max(total, 2)) == 0 ? 1 : Math.Ceiling(Math.Max(total, 2));

            if (!string.IsNullOrEmpty(pagination.OrderBy))
            {
                switch (pagination.OrderBy)
                {
                    case "Username":
                        users = pagination.Order == "desc" ? users.OrderByDescending(x => x.Username).ToList() : users.OrderBy(x => x.Username).ToList();
                        break;
                    case "DisplayName":
                        users = pagination.Order == "desc" ? users.OrderByDescending(x => x.DisplayName).ToList() : users.OrderBy(x => x.DisplayName).ToList();
                        break;
                    case "Email":
                        users = pagination.Order == "desc" ? users.OrderByDescending(x => x.Email).ToList() : users.OrderBy(x => x.Email).ToList();
                        break;
                }
            }
            return new DataTableResponse<Users>() { Take = pagination.Take, Skip = pagination.Skip, PagesTotal = pagesTotal, RecordsTotal = usersTotal, GoToPage = pagination.GoToPage ?? default, Search = pagination.Search, OrderBy = pagination.OrderBy, Order = pagination.Order, Data = users };
        }

        public static DataTableResponse<RolesViewModel> ListOfRoles(List<RolesViewModel> roles, int rolesTotal, double take, int skip, int goToPageValue, string search, string orderBy, string order)
        {
            if (!string.IsNullOrEmpty(search)&& search!=" ")
            {
                roles = roles.Where(e => string.Concat(e.RoleName.ToLower()).Contains(search.Trim().ToLower())).ToList();
                rolesTotal = roles.Count();
                skip = 0;
            }
            roles = roles.Skip(skip).Take((int)take).ToList();
            double total = rolesTotal / take;
            var pagesTotal = Math.Ceiling(Math.Max(total, 2)) == 0 ? 1 : Math.Ceiling(Math.Max(total, 2));
            if (!string.IsNullOrEmpty(orderBy))
            {
                switch (orderBy)
                {
                    case "RoleName":
                        roles = order == "desc" ? roles.OrderByDescending(x => x.RoleName).ToList() : roles.OrderBy(x => x.RoleName).ToList();
                        break;
                }
            }
            return new DataTableResponse<RolesViewModel>() { Take = take, Skip = skip, PagesTotal = pagesTotal, RecordsTotal = rolesTotal, GoToPage = goToPageValue, Search = search, OrderBy = orderBy, Order = order, Data = roles };
        }
        public static string DNNCookie()
        {
            HttpRequest currentRequest = HttpContext.Current.Request;
            string aspxAnonymousCookie = currentRequest.Cookies[".ASPXANONYMOUS"]?.Value;
            string dnnIsMobileCookie = currentRequest.Cookies["dnn_IsMobile"]?.Value;
            string languageCookie = currentRequest.Cookies["language"]?.Value;
            string requestVerificationTokenCookie = currentRequest.Cookies["__RequestVerificationToken"]?.Value;
            string authenticationCookie = currentRequest.Cookies["authentication"]?.Value;
            string dotNetNukeCookie = currentRequest.Cookies[".DOTNETNUKE"]?.Value;
            var result = $".ASPXANONYMOUS={aspxAnonymousCookie}; dnn_IsMobile={dnnIsMobileCookie}; language={languageCookie}; __RequestVerificationToken={requestVerificationTokenCookie}; authentication={authenticationCookie}; .DOTNETNUKE={dotNetNukeCookie}";
            return result;
        }
    }
}