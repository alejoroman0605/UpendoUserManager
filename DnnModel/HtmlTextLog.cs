using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class HtmlTextLog
    {
        public int HtmlTextLogId { get; set; }
        public int ItemId { get; set; }
        public int StateId { get; set; }
        public string Comment { get; set; }
        public bool Approved { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreatedOnDate { get; set; }

        public virtual HtmlText Item { get; set; }
        public virtual WorkflowStates State { get; set; }
    }
}
