﻿using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class PersonaBarMenuPermission
    {
        public int MenuPermissionId { get; set; }
        public int? PortalId { get; set; }
        public int MenuId { get; set; }
        public int PermissionId { get; set; }
        public bool AllowAccess { get; set; }
        public int? RoleId { get; set; }
        public int? UserId { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime? CreatedOnDate { get; set; }
        public int? LastModifiedByUserId { get; set; }
        public DateTime? LastModifiedOnDate { get; set; }

        public virtual PersonaBarMenu Menu { get; set; }
        public virtual PersonaBarPermission Permission { get; set; }
        public virtual Portals Portal { get; set; }
        public virtual Roles Role { get; set; }
        public virtual Users User { get; set; }
    }
}
