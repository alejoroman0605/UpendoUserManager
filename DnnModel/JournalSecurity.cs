using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class JournalSecurity
    {
        public int JournalSecurityId { get; set; }
        public int JournalId { get; set; }
        public string SecurityKey { get; set; }
    }
}
