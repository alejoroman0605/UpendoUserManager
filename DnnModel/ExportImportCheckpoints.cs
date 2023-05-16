using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class ExportImportCheckpoints
    {
        public int CheckpointId { get; set; }
        public int JobId { get; set; }
        public string AssemblyName { get; set; }
        public string Category { get; set; }
        public int Stage { get; set; }
        public string StageData { get; set; }
        public int Progress { get; set; }
        public int TotalItems { get; set; }
        public int ProcessedItems { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public bool? Completed { get; set; }

        public virtual ExportImportJobs Job { get; set; }
    }
}
