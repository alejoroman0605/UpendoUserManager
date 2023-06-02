using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Upendo.Modules.UpendoUserManaged.ViewModels
{
    public class RolesViewModel
    {
        public int RoleId { get; set; }
        public int? PortalId { get; set; }
        public string RoleName { get; set; }
        public bool HasRole { get; set; }
        public int Index { get; set; }
    }
}