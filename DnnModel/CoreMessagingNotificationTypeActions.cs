using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class CoreMessagingNotificationTypeActions
    {
        public int NotificationTypeActionId { get; set; }
        public int NotificationTypeId { get; set; }
        public string NameResourceKey { get; set; }
        public string DescriptionResourceKey { get; set; }
        public string ConfirmResourceKey { get; set; }
        public int Order { get; set; }
        public string Apicall { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime? CreatedOnDate { get; set; }
        public int? LastModifiedByUserId { get; set; }
        public DateTime? LastModifiedOnDate { get; set; }

        public virtual CoreMessagingNotificationTypes NotificationType { get; set; }
    }
}
