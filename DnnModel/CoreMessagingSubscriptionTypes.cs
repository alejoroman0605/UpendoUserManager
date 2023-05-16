using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class CoreMessagingSubscriptionTypes
    {
        public CoreMessagingSubscriptionTypes()
        {
            CoreMessagingSubscriptions = new HashSet<CoreMessagingSubscriptions>();
        }

        public int SubscriptionTypeId { get; set; }
        public string SubscriptionName { get; set; }
        public string FriendlyName { get; set; }
        public int? DesktopModuleId { get; set; }

        public virtual ICollection<CoreMessagingSubscriptions> CoreMessagingSubscriptions { get; set; }
    }
}
