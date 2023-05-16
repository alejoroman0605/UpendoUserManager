using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class ScheduleHistory
    {
        public int ScheduleHistoryId { get; set; }
        public int ScheduleId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? Succeeded { get; set; }
        public string LogNotes { get; set; }
        public DateTime? NextStart { get; set; }
        public string Server { get; set; }

        public virtual Schedule Schedule { get; set; }
    }
}
