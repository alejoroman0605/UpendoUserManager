using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class RelationshipTypes
    {
        public RelationshipTypes()
        {
            Relationships = new HashSet<Relationships>();
        }

        public int RelationshipTypeId { get; set; }
        public int Direction { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreatedOnDate { get; set; }
        public int LastModifiedByUserId { get; set; }
        public DateTime LastModifiedOnDate { get; set; }

        public virtual ICollection<Relationships> Relationships { get; set; }
    }
}
