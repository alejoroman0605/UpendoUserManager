using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class UserPortals
    {
        public int UserId { get; set; }
        public int PortalId { get; set; }
        public int UserPortalId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool? Authorised { get; set; }
        public bool IsDeleted { get; set; }
        public bool RefreshRoles { get; set; }
        public string VanityUrl { get; set; }
        public bool HasAgreedToTerms { get; set; }
        public DateTime? HasAgreedToTermsOn { get; set; }
        public bool RequestsRemoval { get; set; }

        public virtual Portals Portal { get; set; }
        public virtual Users User { get; set; }
    }
}
