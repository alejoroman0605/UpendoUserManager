using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class UserProfile
    {
        public int ProfileId { get; set; }
        public int UserId { get; set; }
        public int PropertyDefinitionId { get; set; }
        public string PropertyValue { get; set; }
        public string PropertyText { get; set; }
        public int Visibility { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public string ExtendedVisibility { get; set; }

        public virtual ProfilePropertyDefinition PropertyDefinition { get; set; }
        public virtual Users User { get; set; }
    }
}
