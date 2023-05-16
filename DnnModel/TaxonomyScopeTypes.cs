using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class TaxonomyScopeTypes
    {
        public TaxonomyScopeTypes()
        {
            TaxonomyVocabularies = new HashSet<TaxonomyVocabularies>();
        }

        public int ScopeTypeId { get; set; }
        public string ScopeType { get; set; }

        public virtual ICollection<TaxonomyVocabularies> TaxonomyVocabularies { get; set; }
    }
}
