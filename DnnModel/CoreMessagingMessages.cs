using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class CoreMessagingMessages
    {
        public CoreMessagingMessages()
        {
            CoreMessagingMessageAttachments = new HashSet<CoreMessagingMessageAttachments>();
            CoreMessagingMessageRecipients = new HashSet<CoreMessagingMessageRecipients>();
        }

        public int MessageId { get; set; }
        public int? PortalId { get; set; }
        public int? NotificationTypeId { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public int? ConversationId { get; set; }
        public bool? ReplyAllAllowed { get; set; }
        public int? SenderUserId { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string Context { get; set; }
        public bool? IncludeDismissAction { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime? CreatedOnDate { get; set; }
        public int? LastModifiedByUserId { get; set; }
        public DateTime? LastModifiedOnDate { get; set; }

        public virtual CoreMessagingNotificationTypes NotificationType { get; set; }
        public virtual ICollection<CoreMessagingMessageAttachments> CoreMessagingMessageAttachments { get; set; }
        public virtual ICollection<CoreMessagingMessageRecipients> CoreMessagingMessageRecipients { get; set; }
    }
}
