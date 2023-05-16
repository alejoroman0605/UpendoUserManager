using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class ModuleControls
    {
        public int ModuleControlId { get; set; }
        public int? ModuleDefId { get; set; }
        public string ControlKey { get; set; }
        public string ControlTitle { get; set; }
        public string ControlSrc { get; set; }
        public string IconFile { get; set; }
        public int ControlType { get; set; }
        public int? ViewOrder { get; set; }
        public string HelpUrl { get; set; }
        public bool SupportsPartialRendering { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime? CreatedOnDate { get; set; }
        public int? LastModifiedByUserId { get; set; }
        public DateTime? LastModifiedOnDate { get; set; }
        public bool SupportsPopUps { get; set; }

        public virtual ModuleDefinitions ModuleDef { get; set; }
    }
}
