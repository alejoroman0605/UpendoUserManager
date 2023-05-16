using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class MvcExample
    {
        public int ExampleId { get; set; }
        public int ModuleId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOnDate { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime LastUpdatedOnDate { get; set; }
        public int LastUpdatedByUserId { get; set; }

        public virtual Modules Module { get; set; }
    }
}
