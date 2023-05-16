using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class CoreMessagingSubscriptions
    {
        public int SubscriptionId { get; set; }
        public int UserId { get; set; }
        public int? PortalId { get; set; }
        public int SubscriptionTypeId { get; set; }
        public string ObjectKey { get; set; }
        public string ObjectData { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOnDate { get; set; }
        public int? ModuleId { get; set; }
        public int? TabId { get; set; }

        public virtual Modules Module { get; set; }
        public virtual Portals Portal { get; set; }
        public virtual CoreMessagingSubscriptionTypes SubscriptionType { get; set; }
        public virtual Users User { get; set; }
    }
}
