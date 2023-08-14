using Microsoft.EntityFrameworkCore;
using TemplateAppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TemplateDataRepository
{
    public partial class ApplicationDbContext : DbContext
    {
        private readonly DbContextOptions _options;

        public DbContextOptions Options { get { return _options; } }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            _options = options;
        }

        public DbSet<AuditLog> AuditLog { get; set; }
        public DbSet<LogTypeList> LogTypeList { get; set; }
        public DbSet<LogActionList> LogActionList { get; set; }
        public DbSet<LogTypeAction> LogTypeAction { get; set; }
        public DbSet<InterfaceLog> InterfaceLog { get; set; }
        public DbSet<InterfaceTypeList> InterfaceTypeList { get; set; }
        public DbSet<InterfaceServiceList> InterfaceServiceList { get; set; }
        public DbSet<InterfaceTypeService> InterfaceTypeService { get; set; }
        public DbSet<ExceptionLog> ExceptionLog { get; set; }
        public DbSet<ExceptionTypeList> ExceptionTypeList { get; set; }
        public DbSet<SystemCode> SystemCode { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            modelBuilder.Entity<LogTypeList>().HasKey(l => new { l.LogTypeID });
            modelBuilder.Entity<LogActionList>().HasKey(l => new { l.LogActionID });
            modelBuilder.Entity<LogTypeAction>().HasKey(l => new { l.LogTypeID, l.LogActionID });
            modelBuilder.Entity<InterfaceTypeList>().HasKey(i => new { i.InterfaceTypeID });
            modelBuilder.Entity<InterfaceServiceList>().HasKey(i => new { i.InterfaceServiceID });
            modelBuilder.Entity<InterfaceTypeService>().HasKey(i => new { i.InterfaceTypeID, i.InterfaceServiceID });
            modelBuilder.Entity<ExceptionTypeList>().HasKey(e => new { e.ExceptionTypeID });
            modelBuilder.Entity<SystemCode>().HasKey(c => new { c.Code, c.Key1 });

			//base.OnModelCreating(modelBuilder);

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}
