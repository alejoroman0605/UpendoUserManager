using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class TaxonomyVocabularies
    {
        public TaxonomyVocabularies()
        {
            TaxonomyTerms = new HashSet<TaxonomyTerms>();
        }

        public int VocabularyId { get; set; }
        public int VocabularyTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public int? ScopeId { get; set; }
        public int ScopeTypeId { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime? CreatedOnDate { get; set; }
        public int? LastModifiedByUserId { get; set; }
        public DateTime? LastModifiedOnDate { get; set; }
        public bool IsSystem { get; set; }

        public virtual TaxonomyScopeTypes ScopeType { get; set; }
        public virtual TaxonomyVocabularyTypes VocabularyType { get; set; }
        public virtual ICollection<TaxonomyTerms> TaxonomyTerms { get; set; }
    }
}
