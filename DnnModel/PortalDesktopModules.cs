using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class PortalDesktopModules
    {
        public PortalDesktopModules()
        {
            DesktopModulePermission = new HashSet<DesktopModulePermission>();
        }

        public int PortalDesktopModuleId { get; set; }
        public int PortalId { get; set; }
        public int DesktopModuleId { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime? CreatedOnDate { get; set; }
        public int? LastModifiedByUserId { get; set; }
        public DateTime? LastModifiedOnDate { get; set; }

        public virtual DesktopModules DesktopModule { get; set; }
        public virtual Portals Portal { get; set; }
        public virtual ICollection<DesktopModulePermission> DesktopModulePermission { get; set; }
    }
}
