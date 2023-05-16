using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class ContentWorkflowSources
    {
        public int SourceId { get; set; }
        public int WorkflowId { get; set; }
        public string SourceName { get; set; }
        public string SourceType { get; set; }

        public virtual ContentWorkflows Workflow { get; set; }
    }
}
