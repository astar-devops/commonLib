using Microsoft.AspNetCore.Mvc;
using CommonLibrary;
using TemplateAppModel;
using TemplateDataRepository;
using TemplateDataRepository.StoredProcedures;
using Newtonsoft.Json;

namespace TestApplication.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuditLogController : ControllerBase
	{
		private readonly ApplicationDbContext _context;
		private readonly IUnitOfWork _unitOfWork;
		private readonly ICommonService _commonService;

		public AuditLogController(ApplicationDbContext context, IUnitOfWork unitOfWork, ICommonService commonService)
		{
			_context = context;
			_unitOfWork = unitOfWork;
			_commonService = commonService;
		}

        // GET: api/AuditLog/1
        [HttpGet("{logID}")]
		public spGetAuditLogsCodeManagement_Result GetAuditLog(int logID)
		{
            _commonService.LogService.LogInfo("msg");
            _commonService.LogService.LogPerformance("ops1", DateTime.Now.AddMinutes(-1), DateTime.Now);

            var auditLog = _unitOfWork.AuditLogRepository.GetAuditLogByLogID(logID);

			LogDetails logDetails = new LogDetails();
			logDetails = JsonConvert.DeserializeObject<LogDetails>(auditLog.ActionRequest);

			spGetAuditLogsCodeManagement_Result result = new spGetAuditLogsCodeManagement_Result();
			result.LogID = auditLog.LogID;
			result.UpdatedBy = auditLog.UserID;
			result.UpdatedOn = auditLog.LogDateTime.ToString("dd/MM/yyyy HH:mm:ss");

			foreach (LogColumns columns in logDetails.PK)
			{
				if (columns.FieldName == "Code")
					result.Code = columns.Value;
				else if (columns.FieldName == "Key1")
					result.Key1 = columns.Value;
			}

			foreach (LogColumns columns in logDetails.Columns)
			{
				if (columns.FieldName == "CodeValue")
					result.CodeValue = columns.Value;
				else if (columns.FieldName == "CodeDescription")
					result.CodeDescription = columns.Value;
			}

			return result;
		}

		// GET: api/AuditLog/sp/1
		[HttpGet("sp/{logID}")]
		public IEnumerable<spGetAuditLogsCodeManagement_Result> GetAuditLogSP(int logID)
		{
			var auditLog = _context.SP_GetAuditLogsCodeManagement(logID);

			return auditLog;
		}
	}
}
























 