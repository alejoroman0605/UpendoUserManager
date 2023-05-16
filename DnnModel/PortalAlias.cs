using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class PortalAlias
    {
        public int PortalAliasId { get; set; }
        public int PortalId { get; set; }
        public string Httpalias { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime? CreatedOnDate { get; set; }
        public int? LastModifiedByUserId { get; set; }
        public DateTime? LastModifiedOnDate { get; set; }
        public string BrowserType { get; set; }
        public string Skin { get; set; }
        public string CultureCode { get; set; }
        public bool IsPrimary { get; set; }

        public virtual Portals Portal { get; set; }
    }
}
