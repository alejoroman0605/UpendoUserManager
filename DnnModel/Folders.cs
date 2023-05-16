using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class Folders
    {
        public Folders()
        {
            Files = new HashSet<Files>();
            FolderPermission = new HashSet<FolderPermission>();
        }

        public int FolderId { get; set; }
        public int? PortalId { get; set; }
        public string FolderPath { get; set; }
        public int StorageLocation { get; set; }
        public bool IsProtected { get; set; }
        public bool IsCached { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime? CreatedOnDate { get; set; }
        public int? LastModifiedByUserId { get; set; }
        public DateTime? LastModifiedOnDate { get; set; }
        public Guid UniqueId { get; set; }
        public Guid VersionGuid { get; set; }
        public int FolderMappingId { get; set; }
        public int? ParentId { get; set; }
        public bool IsVersioned { get; set; }
        public int? WorkflowId { get; set; }
        public string MappedPath { get; set; }

        public virtual FolderMappings FolderMapping { get; set; }
        public virtual Portals Portal { get; set; }
        public virtual ContentWorkflows Workflow { get; set; }
        public virtual ICollection<Files> Files { get; set; }
        public virtual ICollection<FolderPermission> FolderPermission { get; set; }
    }
}
