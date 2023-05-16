using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class PasswordHistory
    {
        public int PasswordHistoryId { get; set; }
        public int UserId { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime? CreatedOnDate { get; set; }
        public int? LastModifiedByUserId { get; set; }
        public DateTime? LastModifiedOnDate { get; set; }

        public virtual Users User { get; set; }
    }
}
