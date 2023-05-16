using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class MetaData
    {
        public MetaData()
        {
            ContentItemsMetaData = new HashSet<ContentItemsMetaData>();
        }

        public int MetaDataId { get; set; }
        public string MetaDataName { get; set; }
        public string MetaDataDescription { get; set; }

        public virtual ICollection<ContentItemsMetaData> ContentItemsMetaData { get; set; }
    }
}
