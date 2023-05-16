using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class SearchTypes
    {
        public int SearchTypeId { get; set; }
        public string SearchTypeName { get; set; }
        public string SearchResultClass { get; set; }
        public bool? IsPrivate { get; set; }
    }
}
