using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class MobileRedirectionRules
    {
        public int Id { get; set; }
        public int RedirectionId { get; set; }
        public string Capability { get; set; }
        public string Expression { get; set; }

        public virtual MobileRedirections Redirection { get; set; }
    }
}
