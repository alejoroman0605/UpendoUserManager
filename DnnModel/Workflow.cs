using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class Workflow
    {
        public Workflow()
        {
            WorkflowStates = new HashSet<WorkflowStates>();
        }

        public int WorkflowId { get; set; }
        public int? PortalId { get; set; }
        public string WorkflowName { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<WorkflowStates> WorkflowStates { get; set; }
    }
}
