using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class Schedule
    {
        public Schedule()
        {
            ScheduleHistory = new HashSet<ScheduleHistory>();
            ScheduleItemSettings = new HashSet<ScheduleItemSettings>();
        }

        public int ScheduleId { get; set; }
        public string TypeFullName { get; set; }
        public int TimeLapse { get; set; }
        public string TimeLapseMeasurement { get; set; }
        public int RetryTimeLapse { get; set; }
        public string RetryTimeLapseMeasurement { get; set; }
        public int RetainHistoryNum { get; set; }
        public string AttachToEvent { get; set; }
        public bool CatchUpEnabled { get; set; }
        public bool Enabled { get; set; }
        public string ObjectDependencies { get; set; }
        public string Servers { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime? CreatedOnDate { get; set; }
        public int? LastModifiedByUserId { get; set; }
        public DateTime? LastModifiedOnDate { get; set; }
        public string FriendlyName { get; set; }
        public DateTime? ScheduleStartDate { get; set; }

        public virtual ICollection<ScheduleHistory> ScheduleHistory { get; set; }
        public virtual ICollection<ScheduleItemSettings> ScheduleItemSettings { get; set; }
    }
}
