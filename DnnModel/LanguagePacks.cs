using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class LanguagePacks
    {
        public int LanguagePackId { get; set; }
        public int PackageId { get; set; }
        public int DependentPackageId { get; set; }
        public int LanguageId { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime? CreatedOnDate { get; set; }
        public int? LastModifiedByUserId { get; set; }
        public DateTime? LastModifiedOnDate { get; set; }

        public virtual Packages Package { get; set; }
    }
}
