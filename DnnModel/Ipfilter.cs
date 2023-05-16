using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class Ipfilter
    {
        public int IpfilterId { get; set; }
        public string Ipaddress { get; set; }
        public string SubnetMask { get; set; }
        public byte? RuleType { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime? CreatedOnDate { get; set; }
        public int? LastModifiedByUserId { get; set; }
        public DateTime? LastModifiedOnDate { get; set; }
        public string Notes { get; set; }
    }
}
