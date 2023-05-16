using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class ContentItemsTags
    {
        public int ContentItemTagId { get; set; }
        public int ContentItemId { get; set; }
        public int TermId { get; set; }

        public virtual ContentItems ContentItem { get; set; }
        public virtual TaxonomyTerms Term { get; set; }
    }
}
