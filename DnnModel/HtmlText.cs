using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class HtmlText
    {
        public HtmlText()
        {
            HtmlTextLog = new HashSet<HtmlTextLog>();
            HtmlTextUsers = new HashSet<HtmlTextUsers>();
        }

        public int ModuleId { get; set; }
        public int ItemId { get; set; }
        public string Content { get; set; }
        public int? Version { get; set; }
        public int? StateId { get; set; }
        public bool? IsPublished { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime? CreatedOnDate { get; set; }
        public int? LastModifiedByUserId { get; set; }
        public DateTime? LastModifiedOnDate { get; set; }
        public string Summary { get; set; }

        public virtual Modules Module { get; set; }
        public virtual WorkflowStates State { get; set; }
        public virtual ICollection<HtmlTextLog> HtmlTextLog { get; set; }
        public virtual ICollection<HtmlTextUsers> HtmlTextUsers { get; set; }
    }
}
