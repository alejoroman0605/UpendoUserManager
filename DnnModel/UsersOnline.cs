using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class UsersOnline
    {
        public int UserId { get; set; }
        public int PortalId { get; set; }
        public int TabId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastActiveDate { get; set; }

        public virtual Portals Portal { get; set; }
        public virtual Users User { get; set; }
    }
}
