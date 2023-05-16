using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class CoreMessagingMessageRecipients
    {
        public int RecipientId { get; set; }
        public int MessageId { get; set; }
        public int UserId { get; set; }
        public bool Read { get; set; }
        public bool Archived { get; set; }
        public bool EmailSent { get; set; }
        public DateTime? EmailSentDate { get; set; }
        public Guid? EmailSchedulerInstance { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime? CreatedOnDate { get; set; }
        public int? LastModifiedByUserId { get; set; }
        public DateTime? LastModifiedOnDate { get; set; }
        public bool SendToast { get; set; }

        public virtual CoreMessagingMessages Message { get; set; }
    }
}
