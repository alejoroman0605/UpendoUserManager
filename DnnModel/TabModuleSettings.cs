﻿using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class TabModuleSettings
    {
        public int TabModuleId { get; set; }
        public string SettingName { get; set; }
        public string SettingValue { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime? CreatedOnDate { get; set; }
        public int? LastModifiedByUserId { get; set; }
        public DateTime? LastModifiedOnDate { get; set; }

        public virtual TabModules TabModule { get; set; }
    }
}
