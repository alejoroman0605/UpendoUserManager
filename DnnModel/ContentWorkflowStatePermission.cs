using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class ContentWorkflowStatePermission
    {
        public int WorkflowStatePermissionId { get; set; }
        public int StateId { get; set; }
        public int PermissionId { get; set; }
        public bool AllowAccess { get; set; }
        public int? RoleId { get; set; }
        public int? UserId { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime? CreatedOnDate { get; set; }
        public int? LastModifiedByUserId { get; set; }
        public DateTime? LastModifiedOnDate { get; set; }

        public virtual Permission Permission { get; set; }
        public virtual ContentWorkflowStates State { get; set; }
        public virtual Users User { get; set; }
    }
}
