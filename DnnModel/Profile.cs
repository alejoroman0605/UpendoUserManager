using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class Profile
    {
        public int ProfileId { get; set; }
        public int UserId { get; set; }
        public int PortalId { get; set; }
        public string ProfileData { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Portals Portal { get; set; }
        public virtual Users User { get; set; }
    }
}
