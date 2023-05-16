using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class TabAliasSkins
    {
        public int TabAliasSkinId { get; set; }
        public int TabId { get; set; }
        public int PortalAliasId { get; set; }
        public string SkinSrc { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime? CreatedOnDate { get; set; }
        public int? LastModifiedByUserId { get; set; }
        public DateTime? LastModifiedOnDate { get; set; }
    }
}
