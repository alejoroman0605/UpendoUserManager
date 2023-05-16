using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class WorkflowStates
    {
        public WorkflowStates()
        {
            HtmlText = new HashSet<HtmlText>();
            HtmlTextLog = new HashSet<HtmlTextLog>();
        }

        public int StateId { get; set; }
        public int WorkflowId { get; set; }
        public string StateName { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
        public bool Notify { get; set; }

        public virtual Workflow Workflow { get; set; }
        public virtual ICollection<HtmlText> HtmlText { get; set; }
        public virtual ICollection<HtmlTextLog> HtmlTextLog { get; set; }
    }
}
