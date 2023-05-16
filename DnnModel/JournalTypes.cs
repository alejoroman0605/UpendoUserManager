using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class JournalTypes
    {
        public JournalTypes()
        {
            Journal = new HashSet<Journal>();
        }

        public int JournalTypeId { get; set; }
        public string JournalType { get; set; }
        public string Icon { get; set; }
        public int PortalId { get; set; }
        public bool? IsEnabled { get; set; }
        public bool? AppliesToProfile { get; set; }
        public bool? AppliesToGroup { get; set; }
        public bool? AppliesToStream { get; set; }
        public string Options { get; set; }
        public bool SupportsNotify { get; set; }
        public bool? EnableComments { get; set; }

        public virtual ICollection<Journal> Journal { get; set; }
    }
}
