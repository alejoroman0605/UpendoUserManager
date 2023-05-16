using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class ContentItemsMetaData
    {
        public int ContentItemMetaDataId { get; set; }
        public int ContentItemId { get; set; }
        public int MetaDataId { get; set; }
        public string MetaDataValue { get; set; }

        public virtual ContentItems ContentItem { get; set; }
        public virtual MetaData MetaData { get; set; }
    }
}
