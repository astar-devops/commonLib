using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TemplateAppModel
{
	public class AuditLog
	{
		[Key]
		public int LogID { get; set; }
		public int UserID { get; set; }
		public string? DeviceID { get; set; }
		public string? IPAddress { get; set; }
		public DateTime LogDateTime { get; set; }
		public int LogTypeID { get; set; }
		public int LogActionID { get; set; }
		public string? ActionRequest { get; set; }
		public string? ActionResponse { get; set; }
		public string? Status { get; set; }
		public string? ErrorCode { get; set; }
		public string? ErrorDescription { get; set; }
		public string? RefID { get; set; }
	}

	public class LogTypeList
	{
		public int LogTypeID { get; set; }
		public string LogTypeName { get; set; }
	}

	public class LogActionList
	{
		public int LogActionID { get; set; }
        public string LogActionName { get; set; }
		public string? LogActionDescription { get; set; }

	}

	public class LogTypeAction
	{
		public int LogTypeID { get; set; }
		public int LogActionID { get; set; }
	}

	public class LogDetails
	{
		public List<LogColumns> PK { get; set; }
		public List<LogColumns> Columns { get; set; }
	}

	public class LogColumns
	{
		public string FieldName { get; set; }
		public string Value { get; set; }
	}
}
