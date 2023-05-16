using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class Assemblies
    {
        public int AssemblyId { get; set; }
        public int? PackageId { get; set; }
        public string AssemblyName { get; set; }
        public string Version { get; set; }

        public virtual Packages Package { get; set; }
    }
}
