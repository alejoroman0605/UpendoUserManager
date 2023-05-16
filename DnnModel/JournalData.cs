using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class JournalData
    {
        public int JournalDataId { get; set; }
        public int JournalId { get; set; }
        public string JournalXml { get; set; }

        public virtual Journal Journal { get; set; }
    }
}
