using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class DesktopModules
    {
        public DesktopModules()
        {
            CoreMessagingNotificationTypes = new HashSet<CoreMessagingNotificationTypes>();
            ModuleDefinitions = new HashSet<ModuleDefinitions>();
            PortalDesktopModules = new HashSet<PortalDesktopModules>();
        }

        public int DesktopModuleId { get; set; }
        public string FriendlyName { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public bool IsPremium { get; set; }
        public bool IsAdmin { get; set; }
        public string BusinessControllerClass { get; set; }
        public string FolderName { get; set; }
        public string ModuleName { get; set; }
        public int SupportedFeatures { get; set; }
        public string CompatibleVersions { get; set; }
        public string Dependencies { get; set; }
        public string Permissions { get; set; }
        public int PackageId { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime? CreatedOnDate { get; set; }
        public int? LastModifiedByUserId { get; set; }
        public DateTime? LastModifiedOnDate { get; set; }
        public int ContentItemId { get; set; }
        public int Shareable { get; set; }
        public string AdminPage { get; set; }
        public string HostPage { get; set; }

        public virtual Packages Package { get; set; }
        public virtual ICollection<CoreMessagingNotificationTypes> CoreMessagingNotificationTypes { get; set; }
        public virtual ICollection<ModuleDefinitions> ModuleDefinitions { get; set; }
        public virtual ICollection<PortalDesktopModules> PortalDesktopModules { get; set; }
    }
}
