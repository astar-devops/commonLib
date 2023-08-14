using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateDataRepository.StoredProcedures
{
	public class spGetAuditLogsCodeManagement_Result
	{
		public int LogID { get; set; }
		public string Code { get; set; }
		public string Key1 { get; set; }
		public string? CodeValue { get; set; }
		public string? CodeDescription { get; set; }
		public int UpdatedBy { get; set; }
		public string UpdatedOn { get; set; }
	}
}
