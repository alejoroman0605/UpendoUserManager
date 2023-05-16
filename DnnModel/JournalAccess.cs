using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class JournalAccess
    {
        public int JournalAccessId { get; set; }
        public int JournalTypeId { get; set; }
        public int PortalId { get; set; }
        public string Name { get; set; }
        public Guid AccessKey { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
