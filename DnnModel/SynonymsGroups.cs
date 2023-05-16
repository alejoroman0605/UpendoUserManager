using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class SynonymsGroups
    {
        public int SynonymsGroupId { get; set; }
        public string SynonymsTags { get; set; }
        public int PortalId { get; set; }
        public string CultureCode { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreatedOnDate { get; set; }
        public int LastModifiedByUserId { get; set; }
        public DateTime LastModifiedOnDate { get; set; }
    }
}
