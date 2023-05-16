using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class MobileRedirections
    {
        public MobileRedirections()
        {
            MobileRedirectionRules = new HashSet<MobileRedirectionRules>();
        }

        public int Id { get; set; }
        public int PortalId { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public int SortOrder { get; set; }
        public int SourceTabId { get; set; }
        public bool IncludeChildTabs { get; set; }
        public int TargetType { get; set; }
        public string TargetValue { get; set; }
        public bool Enabled { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreatedOnDate { get; set; }
        public int LastModifiedByUserId { get; set; }
        public DateTime LastModifiedOnDate { get; set; }

        public virtual Portals Portal { get; set; }
        public virtual ICollection<MobileRedirectionRules> MobileRedirectionRules { get; set; }
    }
}
