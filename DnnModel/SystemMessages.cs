using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class SystemMessages
    {
        public int MessageId { get; set; }
        public int? PortalId { get; set; }
        public string MessageName { get; set; }
        public string MessageValue { get; set; }

        public virtual Portals Portal { get; set; }
    }
}
