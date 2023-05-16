using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class SiteLog
    {
        public int SiteLogId { get; set; }
        public DateTime DateTime { get; set; }
        public int PortalId { get; set; }
        public int? UserId { get; set; }
        public string Referrer { get; set; }
        public string Url { get; set; }
        public string UserAgent { get; set; }
        public string UserHostAddress { get; set; }
        public string UserHostName { get; set; }
        public int? TabId { get; set; }
        public int? AffiliateId { get; set; }

        public virtual Portals Portal { get; set; }
    }
}
