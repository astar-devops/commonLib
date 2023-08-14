using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateDataRepository.StoredProcedures;
using Microsoft.EntityFrameworkCore;

namespace TemplateDataRepository
{
	public partial class ApplicationDbContext : DbContext
	{
		public virtual DbSet<spGetAuditLogsCodeManagement_Result> spGetAuditLogsCodeManagement_Results { get; set; }

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<spGetAuditLogsCodeManagement_Result>(entity =>
				entity.HasKey(e => e.LogID));
		}

		public IEnumerable<spGetAuditLogsCodeManagement_Result> SP_GetAuditLogsCodeManagement(int logID)
		{
			return this.spGetAuditLogsCodeManagement_Results
				.FromSqlInterpolated($"[dbo].[spGetAuditLogsCodeManagement] {logID}")
				.ToList();
		}
	}
}
