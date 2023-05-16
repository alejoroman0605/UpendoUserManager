using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class Relationships
    {
        public Relationships()
        {
            UserRelationshipPreferences = new HashSet<UserRelationshipPreferences>();
            UserRelationships = new HashSet<UserRelationships>();
        }

        public int RelationshipId { get; set; }
        public int RelationshipTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? PortalId { get; set; }
        public int? UserId { get; set; }
        public int DefaultResponse { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreatedOnDate { get; set; }
        public int LastModifiedByUserId { get; set; }
        public DateTime LastModifiedOnDate { get; set; }

        public virtual Portals Portal { get; set; }
        public virtual RelationshipTypes RelationshipType { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<UserRelationshipPreferences> UserRelationshipPreferences { get; set; }
        public virtual ICollection<UserRelationships> UserRelationships { get; set; }
    }
}
