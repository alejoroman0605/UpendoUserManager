using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class TabVersionDetails
    {
        public int TabVersionDetailId { get; set; }
        public int TabVersionId { get; set; }
        public int ModuleId { get; set; }
        public int ModuleVersion { get; set; }
        public string PaneName { get; set; }
        public int ModuleOrder { get; set; }
        public int Action { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreatedOnDate { get; set; }
        public int LastModifiedByUserId { get; set; }
        public DateTime LastModifiedOnDate { get; set; }

        public virtual TabVersions TabVersion { get; set; }
    }
}
