using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class UserAuthentication
    {
        public int UserAuthenticationId { get; set; }
        public int UserId { get; set; }
        public string AuthenticationType { get; set; }
        public string AuthenticationToken { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime? CreatedOnDate { get; set; }
        public int? LastModifiedByUserId { get; set; }
        public DateTime? LastModifiedOnDate { get; set; }

        public virtual Users User { get; set; }
    }
}
