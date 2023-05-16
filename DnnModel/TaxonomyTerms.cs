using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class TaxonomyTerms
    {
        public TaxonomyTerms()
        {
            ContentItemsTags = new HashSet<ContentItemsTags>();
            InverseParentTerm = new HashSet<TaxonomyTerms>();
        }

        public int TermId { get; set; }
        public int VocabularyId { get; set; }
        public int? ParentTermId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public int TermLeft { get; set; }
        public int TermRight { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime? CreatedOnDate { get; set; }
        public int? LastModifiedByUserId { get; set; }
        public DateTime? LastModifiedOnDate { get; set; }

        public virtual TaxonomyTerms ParentTerm { get; set; }
        public virtual TaxonomyVocabularies Vocabulary { get; set; }
        public virtual ICollection<ContentItemsTags> ContentItemsTags { get; set; }
        public virtual ICollection<TaxonomyTerms> InverseParentTerm { get; set; }
    }
}
