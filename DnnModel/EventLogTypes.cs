using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class EventLogTypes
    {
        public EventLogTypes()
        {
            EventLog = new HashSet<EventLog>();
            EventLogConfig = new HashSet<EventLogConfig>();
        }

        public string LogTypeKey { get; set; }
        public string LogTypeFriendlyName { get; set; }
        public string LogTypeDescription { get; set; }
        public string LogTypeOwner { get; set; }
        public string LogTypeCssclass { get; set; }

        public virtual ICollection<EventLog> EventLog { get; set; }
        public virtual ICollection<EventLogConfig> EventLogConfig { get; set; }
    }
}
