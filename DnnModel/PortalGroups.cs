using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class PortalGroups
    {
        public int PortalGroupId { get; set; }
        public int? MasterPortalId { get; set; }
        public string PortalGroupName { get; set; }
        public string PortalGroupDescription { get; set; }
        public string AuthenticationDomain { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime? CreatedOnDate { get; set; }
        public int? LastModifiedByUserId { get; set; }
        public DateTime? LastModifiedOnDate { get; set; }
    }
}
