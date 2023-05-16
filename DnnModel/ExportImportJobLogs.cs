using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class ExportImportJobLogs
    {
        public int JobLogId { get; set; }
        public int JobId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public int Level { get; set; }
        public DateTime CreatedOnDate { get; set; }

        public virtual ExportImportJobs Job { get; set; }
    }
}
