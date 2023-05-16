using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class ScheduleItemSettings
    {
        public int ScheduleId { get; set; }
        public string SettingName { get; set; }
        public string SettingValue { get; set; }

        public virtual Schedule Schedule { get; set; }
    }
}
