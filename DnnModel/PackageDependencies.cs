using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class PackageDependencies
    {
        public int PackageDependencyId { get; set; }
        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public string Version { get; set; }

        public virtual Packages Package { get; set; }
    }
}
