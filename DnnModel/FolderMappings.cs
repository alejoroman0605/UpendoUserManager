using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class FolderMappings
    {
        public FolderMappings()
        {
            FolderMappingsSettings = new HashSet<FolderMappingsSettings>();
            Folders = new HashSet<Folders>();
        }

        public int FolderMappingId { get; set; }
        public int? PortalId { get; set; }
        public string MappingName { get; set; }
        public string FolderProviderType { get; set; }
        public int? Priority { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime? CreatedOnDate { get; set; }
        public int? LastModifiedByUserId { get; set; }
        public DateTime? LastModifiedOnDate { get; set; }

        public virtual Portals Portal { get; set; }
        public virtual ICollection<FolderMappingsSettings> FolderMappingsSettings { get; set; }
        public virtual ICollection<Folders> Folders { get; set; }
    }
}
