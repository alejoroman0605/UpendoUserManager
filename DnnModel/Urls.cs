using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class Urls
    {
        public int UrlId { get; set; }
        public int? PortalId { get; set; }
        public string Url { get; set; }

        public virtual Portals Portal { get; set; }
    }
}
