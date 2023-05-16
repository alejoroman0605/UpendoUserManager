using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class PortalLanguages
    {
        public int PortalLanguageId { get; set; }
        public int PortalId { get; set; }
        public int LanguageId { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime? CreatedOnDate { get; set; }
        public int? LastModifiedByUserId { get; set; }
        public DateTime? LastModifiedOnDate { get; set; }
        public bool IsPublished { get; set; }

        public virtual Languages Language { get; set; }
        public virtual Portals Portal { get; set; }
    }
}
