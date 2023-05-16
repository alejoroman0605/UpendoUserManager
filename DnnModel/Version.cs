using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class Version
    {
        public int VersionId { get; set; }
        public int Major { get; set; }
        public int Minor { get; set; }
        public int Build { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? Increment { get; set; }
    }
}
