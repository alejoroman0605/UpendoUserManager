using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class SkinPackages
    {
        public SkinPackages()
        {
            Skins = new HashSet<Skins>();
        }

        public int SkinPackageId { get; set; }
        public int PackageId { get; set; }
        public int? PortalId { get; set; }
        public string SkinName { get; set; }
        public string SkinType { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime? CreatedOnDate { get; set; }
        public int? LastModifiedByUserId { get; set; }
        public DateTime? LastModifiedOnDate { get; set; }

        public virtual Packages Package { get; set; }
        public virtual ICollection<Skins> Skins { get; set; }
    }
}
