using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class WebServers
    {
        public int ServerId { get; set; }
        public string ServerName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastActivityDate { get; set; }
        public string Url { get; set; }
        public string IisappName { get; set; }
        public bool? Enabled { get; set; }
        public string ServerGroup { get; set; }
        public string UniqueId { get; set; }
        public int PingFailureCount { get; set; }
    }
}
