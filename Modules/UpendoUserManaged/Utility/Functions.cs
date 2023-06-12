﻿using System.Collections.Generic;
using System.Linq;
using Upendo.Modules.UpendoUserManaged.Models.DnnModel;
using Upendo.Modules.UpendoUserManaged.Data;
using DotNetNuke.Entities.Users;
using DotNetNuke.Security.Roles;
using Upendo.Modules.UpendoUserManaged.ViewModels;
using System;

namespace Upendo.Modules.UpendoUserManaged.Utility
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
        }
        public static DataTableResponse<Users> ListOfUsers(List<Users> users, int usersTotal, double take, int skip, int goToPageValue, string search, string orderBy, string order)
        {
            if (!string.IsNullOrEmpty(search) && search != " ")
            {
                users = users.Where(e => string.Concat(e.FirstName.ToLower(), e.DisplayName.ToLower(), e.Email.ToLower(), e.Username.ToLower()).Contains(search.Trim().ToLower())).ToList();
                usersTotal = users.Count();
                skip = 0;
            }
            users = users.Skip(skip).Take((int)take).ToList();
            double total = usersTotal / take;
            var pagesTotal = Math.Ceiling(Math.Max(total, 2)) == 0 ? 1 : Math.Ceiling(Math.Max(total, 2));
            if (!string.IsNullOrEmpty(orderBy))
            {
                switch (orderBy)
                {
                    case "Username":
                        users = order == "desc" ? users.OrderByDescending(x => x.Username).ToList() : users.OrderBy(x => x.Username).ToList();
                        break;
                    case "DisplayName":
                        users = order == "desc" ? users.OrderByDescending(x => x.DisplayName).ToList() : users.OrderBy(x => x.DisplayName).ToList();
                        break;
                    case "Email":
                        users = order == "desc" ? users.OrderByDescending(x => x.Email).ToList() : users.OrderBy(x => x.Email).ToList();
                        break;
                }
            }
            return new DataTableResponse<Users>() { Take = take, Skip = skip, PagesTotal = pagesTotal, RecordsTotal = usersTotal, GoToPage = goToPageValue, Search = search, OrderBy = orderBy, Order = order, Data = users };
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

    }
}