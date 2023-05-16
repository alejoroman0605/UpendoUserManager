using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class TaxonomyVocabularyTypes
    {
        public TaxonomyVocabularyTypes()
        {
            TaxonomyVocabularies = new HashSet<TaxonomyVocabularies>();
        }

        public int VocabularyTypeId { get; set; }
        public string VocabularyType { get; set; }

        public virtual ICollection<TaxonomyVocabularies> TaxonomyVocabularies { get; set; }
    }
}
