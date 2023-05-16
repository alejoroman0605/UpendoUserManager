using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class Modules
    {
        public Modules()
        {
            CoreMessagingSubscriptions = new HashSet<CoreMessagingSubscriptions>();
            HtmlText = new HashSet<HtmlText>();
            ModulePermission = new HashSet<ModulePermission>();
            ModuleSettings = new HashSet<ModuleSettings>();
            MvcExample = new HashSet<MvcExample>();
            TabModules = new HashSet<TabModules>();
        }

        public int ModuleId { get; set; }
        public int ModuleDefId { get; set; }
        public bool AllTabs { get; set; }
        public bool IsDeleted { get; set; }
        public bool? InheritViewPermissions { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? PortalId { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime? CreatedOnDate { get; set; }
        public int? LastModifiedByUserId { get; set; }
        public DateTime? LastModifiedOnDate { get; set; }
        public DateTime? LastContentModifiedOnDate { get; set; }
        public int? ContentItemId { get; set; }
        public bool? IsShareable { get; set; }
        public bool? IsShareableViewOnly { get; set; }

        public virtual ContentItems ContentItem { get; set; }
        public virtual ModuleDefinitions ModuleDef { get; set; }
        public virtual ICollection<CoreMessagingSubscriptions> CoreMessagingSubscriptions { get; set; }
        public virtual ICollection<HtmlText> HtmlText { get; set; }
        public virtual ICollection<ModulePermission> ModulePermission { get; set; }
        public virtual ICollection<ModuleSettings> ModuleSettings { get; set; }
        public virtual ICollection<MvcExample> MvcExample { get; set; }
        public virtual ICollection<TabModules> TabModules { get; set; }
    }
}
