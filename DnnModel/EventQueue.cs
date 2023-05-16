using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class EventQueue
    {
        public int EventMessageId { get; set; }
        public string EventName { get; set; }
        public int Priority { get; set; }
        public string ProcessorType { get; set; }
        public string ProcessorCommand { get; set; }
        public string Body { get; set; }
        public string Sender { get; set; }
        public string Subscriber { get; set; }
        public string AuthorizedRoles { get; set; }
        public string ExceptionMessage { get; set; }
        public DateTime SentDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Attributes { get; set; }
        public bool IsComplete { get; set; }
    }
}
