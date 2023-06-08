using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Upendo.Modules.UpendoUserManaged.ViewModels
{
    public struct DataTableResponse<T>
    {
        public double Take { get; set; }
        public int Skip { get; set; }
        public int Page { get; set; }
        public int GoToPage { get; set; }
        public double PagesTotal { get; set; }
        public double RecordsTotal { get; set; }
        public int RecordsFiltered { get; set; }
        public string Search;
        public string OrderBy;
        public string Order;
        public List<T> Data;
    }

}