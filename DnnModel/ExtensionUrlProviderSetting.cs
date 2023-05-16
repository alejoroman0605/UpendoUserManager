using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class ExtensionUrlProviderSetting
    {
        public int ExtensionUrlProviderId { get; set; }
        public int PortalId { get; set; }
        public string SettingName { get; set; }
        public string SettingValue { get; set; }
    }
}
