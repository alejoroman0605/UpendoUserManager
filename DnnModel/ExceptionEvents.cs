using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class ExceptionEvents
    {
        public long LogEventId { get; set; }
        public string AssemblyVersion { get; set; }
        public int? PortalId { get; set; }
        public int? UserId { get; set; }
        public int? TabId { get; set; }
        public string RawUrl { get; set; }
        public string Referrer { get; set; }
        public string UserAgent { get; set; }

        public virtual EventLog LogEvent { get; set; }
    }
}
