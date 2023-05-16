using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class Lists
    {
        public int EntryId { get; set; }
        public string ListName { get; set; }
        public string Value { get; set; }
        public string Text { get; set; }
        public int ParentId { get; set; }
        public int Level { get; set; }
        public int SortOrder { get; set; }
        public int DefinitionId { get; set; }
        public string Description { get; set; }
        public int PortalId { get; set; }
        public bool SystemList { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime? CreatedOnDate { get; set; }
        public int? LastModifiedByUserId { get; set; }
        public DateTime? LastModifiedOnDate { get; set; }
    }
}
