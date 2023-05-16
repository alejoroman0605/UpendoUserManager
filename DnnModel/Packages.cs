using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class Packages
    {
        public Packages()
        {
            Assemblies = new HashSet<Assemblies>();
            Authentication = new HashSet<Authentication>();
            DesktopModules = new HashSet<DesktopModules>();
            JavaScriptLibraries = new HashSet<JavaScriptLibraries>();
            LanguagePacks = new HashSet<LanguagePacks>();
            PackageDependencies = new HashSet<PackageDependencies>();
            SkinControls = new HashSet<SkinControls>();
            SkinPackages = new HashSet<SkinPackages>();
        }

        public int PackageId { get; set; }
        public int? PortalId { get; set; }
        public string Name { get; set; }
        public string FriendlyName { get; set; }
        public string Description { get; set; }
        public string PackageType { get; set; }
        public string Version { get; set; }
        public string License { get; set; }
        public string Manifest { get; set; }
        public string Owner { get; set; }
        public string Organization { get; set; }
        public string Url { get; set; }
        public string Email { get; set; }
        public string ReleaseNotes { get; set; }
        public bool IsSystemPackage { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime? CreatedOnDate { get; set; }
        public int? LastModifiedByUserId { get; set; }
        public DateTime? LastModifiedOnDate { get; set; }
        public string FolderName { get; set; }
        public string IconFile { get; set; }

        public virtual PackageTypes PackageTypeNavigation { get; set; }
        public virtual ICollection<Assemblies> Assemblies { get; set; }
        public virtual ICollection<Authentication> Authentication { get; set; }
        public virtual ICollection<DesktopModules> DesktopModules { get; set; }
        public virtual ICollection<JavaScriptLibraries> JavaScriptLibraries { get; set; }
        public virtual ICollection<LanguagePacks> LanguagePacks { get; set; }
        public virtual ICollection<PackageDependencies> PackageDependencies { get; set; }
        public virtual ICollection<SkinControls> SkinControls { get; set; }
        public virtual ICollection<SkinPackages> SkinPackages { get; set; }
    }
}
