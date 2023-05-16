using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class ExtensionUrlProviderTab
    {
        public int ExtensionUrlProviderId { get; set; }
        public int PortalId { get; set; }
        public int TabId { get; set; }
        public bool IsActive { get; set; }
    }
}
