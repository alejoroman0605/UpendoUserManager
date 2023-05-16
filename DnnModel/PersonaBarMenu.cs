using System;
using System.Collections.Generic;

namespace Upendo.Modules.UpendoUserManaged.Models.DnnModel
{
    public partial class PersonaBarMenu
    {
        public PersonaBarMenu()
        {
            InverseParent = new HashSet<PersonaBarMenu>();
            PersonaBarExtensions = new HashSet<PersonaBarExtensions>();
            PersonaBarMenuPermission = new HashSet<PersonaBarMenuPermission>();
            PersonaBarPermission = new HashSet<PersonaBarPermission>();
        }

        public int MenuId { get; set; }
        public string Identifier { get; set; }
        public string ModuleName { get; set; }
        public string FolderName { get; set; }
        public string Controller { get; set; }
        public string ResourceKey { get; set; }
        public string Path { get; set; }
        public string Link { get; set; }
        public string CssClass { get; set; }
        public int? ParentId { get; set; }
        public int Order { get; set; }
        public bool AllowHost { get; set; }
        public bool Enabled { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime? CreatedOnDate { get; set; }
        public int? LastModifiedByUserId { get; set; }
        public DateTime? LastModifiedOnDate { get; set; }
        public string IconFile { get; set; }

        public virtual PersonaBarMenu Parent { get; set; }
        public virtual PersonaBarMenuDefaultPermissions PersonaBarMenuDefaultPermissions { get; set; }
        public virtual ICollection<PersonaBarMenu> InverseParent { get; set; }
        public virtual ICollection<PersonaBarExtensions> PersonaBarExtensions { get; set; }
        public virtual ICollection<PersonaBarMenuPermission> PersonaBarMenuPermission { get; set; }
        public virtual ICollection<PersonaBarPermission> PersonaBarPermission { get; set; }
    }
}
