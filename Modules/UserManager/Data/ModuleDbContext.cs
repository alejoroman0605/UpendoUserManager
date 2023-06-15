using DotNetNuke.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Xml;
using Upendo.Modules.UserManager.Models.DnnModel;

namespace Upendo.Modules.UserManager.Data
{
    public class ModuleDbContext : DbContext
    {
        public ModuleDbContext() : base("name=SiteSqlServer")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<RoleGroups> RoleGroups { get; set; }
        public DbSet<Portals> Portals { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<AspnetMembership> AspnetMemberships { get; set; }
        //public DbSet<AspnetUsers> AspnetUsers { get; set; }
    }
}