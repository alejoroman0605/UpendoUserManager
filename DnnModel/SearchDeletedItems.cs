using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class SearchDeletedItems
    {
        public int SearchDeletedItemsId { get; set; }
        public DateTime DateCreated { get; set; }
        public string Document { get; set; }
    }
}
