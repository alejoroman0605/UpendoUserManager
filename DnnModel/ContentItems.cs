using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class ContentItems
    {
        public ContentItems()
        {
            ContentItemsMetaData = new HashSet<ContentItemsMetaData>();
            ContentItemsTags = new HashSet<ContentItemsTags>();
            ContentWorkflowLogs = new HashSet<ContentWorkflowLogs>();
            Files = new HashSet<Files>();
            Modules = new HashSet<Modules>();
            Tabs = new HashSet<Tabs>();
        }

        public int ContentItemId { get; set; }
        public string Content { get; set; }
        public int ContentTypeId { get; set; }
        public int TabId { get; set; }
        public int ModuleId { get; set; }
        public string ContentKey { get; set; }
        public bool Indexed { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime? CreatedOnDate { get; set; }
        public int? LastModifiedByUserId { get; set; }
        public DateTime? LastModifiedOnDate { get; set; }
        public int? StateId { get; set; }

        public virtual ContentTypes ContentType { get; set; }
        public virtual ContentWorkflowStates State { get; set; }
        public virtual ICollection<ContentItemsMetaData> ContentItemsMetaData { get; set; }
        public virtual ICollection<ContentItemsTags> ContentItemsTags { get; set; }
        public virtual ICollection<ContentWorkflowLogs> ContentWorkflowLogs { get; set; }
        public virtual ICollection<Files> Files { get; set; }
        public virtual ICollection<Modules> Modules { get; set; }
        public virtual ICollection<Tabs> Tabs { get; set; }
    }
}
