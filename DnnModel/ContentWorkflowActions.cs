using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class ContentWorkflowActions
    {
        public int ActionId { get; set; }
        public int ContentTypeId { get; set; }
        public string ActionType { get; set; }
        public string ActionSource { get; set; }

        public virtual ContentTypes ContentType { get; set; }
    }
}
