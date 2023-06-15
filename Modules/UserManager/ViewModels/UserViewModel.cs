using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Upendo.Modules.UserManager.Models.DnnModel;

namespace Upendo.Modules.UserManager.ViewModels
{
    public class UserViewModel
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsSuperUser { get; set; }
        public bool Approved { get; set; }
        public int? AffiliateId { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool UpdatePassword { get; set; }
        public string LastIpaddress { get; set; }
        public bool IsDeleted { get; set; }
        public bool SendEmail { get; set; }
        public bool LockedOut { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime? CreatedOnDate { get; set; }
        public int? LastModifiedByUserId { get; set; }
        public DateTime? LastModifiedOnDate { get; set; }
        public Guid? PasswordResetToken { get; set; }
        public DateTime? PasswordResetExpiration { get; set; }
        public int PortalID { get; set; }
        public string[] UserRoles { get; set; }
        public string NewUserRol { get; set; }
    }
}