using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateAppModel;

namespace TemplateDataRepository.Interfaces
{
    public interface IAuditLogRepository : IGenericRepository<AuditLog>
	{
		AuditLog GetAuditLogByLogID(int logID);
	}
}
