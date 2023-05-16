using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class PersonaBarMenuDefaultPermissions
    {
        public int Id { get; set; }
        public int MenuId { get; set; }
        public string RoleNames { get; set; }

        public virtual PersonaBarMenu Menu { get; set; }
    }
}
