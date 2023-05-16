using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class EventLogConfig
    {
        public EventLogConfig()
        {
            EventLog = new HashSet<EventLog>();
        }

        public int Id { get; set; }
        public string LogTypeKey { get; set; }
        public int? LogTypePortalId { get; set; }
        public bool LoggingIsActive { get; set; }
        public int KeepMostRecent { get; set; }
        public bool EmailNotificationIsActive { get; set; }
        public int? NotificationThreshold { get; set; }
        public int? NotificationThresholdTime { get; set; }
        public int? NotificationThresholdTimeType { get; set; }
        public string MailFromAddress { get; set; }
        public string MailToAddress { get; set; }

        public virtual EventLogTypes LogTypeKeyNavigation { get; set; }
        public virtual ICollection<EventLog> EventLog { get; set; }
    }
}
