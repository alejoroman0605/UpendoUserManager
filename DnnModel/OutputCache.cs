using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class OutputCache
    {
        public string CacheKey { get; set; }
        public int ItemId { get; set; }
        public string Data { get; set; }
        public DateTime Expiration { get; set; }
    }
}
