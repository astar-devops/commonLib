using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateDataRepository.Interfaces;
using TemplateAppModel;

namespace TemplateDataRepository.Repositories
{
    public class AuditLogRepository : GenericRepository<AuditLog>, IAuditLogRepository
	{
		public AuditLogRepository(ApplicationDbContext context) : base(context) { }

		public ApplicationDbContext _context => Context;

		public AuditLog GetAuditLogByLogID(int logID)
		{
			return _context.AuditLog.SingleOrDefault(l => l.LogID == logID);
		}
	}
}
