using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class ContentTypes
    {
        public ContentTypes()
        {
            ContentItems = new HashSet<ContentItems>();
            ContentWorkflowActions = new HashSet<ContentWorkflowActions>();
        }

        public int ContentTypeId { get; set; }
        public string ContentType { get; set; }

        public virtual ICollection<ContentItems> ContentItems { get; set; }
        public virtual ICollection<ContentWorkflowActions> ContentWorkflowActions { get; set; }
    }
}
