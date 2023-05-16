using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class Journal
    {
        public Journal()
        {
            JournalComments = new HashSet<JournalComments>();
            JournalData = new HashSet<JournalData>();
        }

        public int JournalId { get; set; }
        public int JournalTypeId { get; set; }
        public int? UserId { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? PortalId { get; set; }
        public int ProfileId { get; set; }
        public int GroupId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string ItemData { get; set; }
        public string ImageUrl { get; set; }
        public string ObjectKey { get; set; }
        public Guid? AccessKey { get; set; }
        public int? ContentItemId { get; set; }
        public bool IsDeleted { get; set; }
        public bool CommentsDisabled { get; set; }
        public bool CommentsHidden { get; set; }

        public virtual JournalTypes JournalType { get; set; }
        public virtual ICollection<JournalComments> JournalComments { get; set; }
        public virtual ICollection<JournalData> JournalData { get; set; }
    }
}
