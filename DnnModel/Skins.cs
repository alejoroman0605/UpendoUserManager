using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class Skins
    {
        public int SkinId { get; set; }
        public int SkinPackageId { get; set; }
        public string SkinSrc { get; set; }

        public virtual SkinPackages SkinPackage { get; set; }
    }
}
