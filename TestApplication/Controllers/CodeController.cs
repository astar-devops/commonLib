using CommonLibrary;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using TemplateAppModel;
using TemplateDataRepository;

namespace TestApplication.Controllers
{
    [ApiController]
	[Route("api/[controller]/[action]")]
	public class CodeController : ControllerBase
	{
		private readonly ApplicationDbContext _context;
		private readonly IUnitOfWork _unitOfWork;
		private readonly ICommonService _commonService;

		public CodeController(ApplicationDbContext context, IUnitOfWork unitOfWork, ICommonService commonService)
		{
			_context = context;
			_unitOfWork = unitOfWork;
            _commonService = commonService;
        }

		// POST: api/Code
		[HttpPost]
		[ProducesDefaultResponseType(typeof(ResponseMessage))]
		public async Task<IActionResult> AddCode(SystemCode systemCode)
		{
			ResponseMessage responseMsg = new ResponseMessage();
			DateTime logDateTime = DateTime.Now;

            string strRequestID = string.Empty;
            int intInterfaceTypeID = 0;
            int intInterfaceServiceID = 0;
            string strRequestPayload = string.Empty;
			string strResponsePayload = string.Empty;

            int intUserID = 0;
            string strDeviceID = string.Empty;
            string strIPAddress = string.Empty;
            int intLogTypeID = 0;
            int intLogActionID = 0;

			string strActionRequest = string.Empty;
			string errorMessage = string.Empty;

            try
			{
                strRequestID = _commonService.LogService.strConstructRequestID(TestAppConstants.SYSTEM_CODE_PREFIX);
                intInterfaceTypeID = _unitOfWork.InterfaceTypeListRepository.GetInterfaceTypeIDByName(TestAppConstants.INTERFACETYPE_A);
                intInterfaceServiceID = _unitOfWork.InterfaceServiceListRepository.GetInterfaceServiceIDByName(TestAppConstants.INTERFACESERVICE_A_ADDCODE);
                strRequestPayload = JsonConvert.SerializeObject(systemCode, Formatting.Indented);

                intUserID = 1;
                strDeviceID = "AHQ-XXXXX";
                strIPAddress = "192.168.xxx.xxx";
                intLogTypeID = _unitOfWork.LogTypeListRepository.GetLogTypeIDByName(TestAppConstants.LOGTYPE_SYSTEMCODE);
                intLogActionID = _unitOfWork.LogActionListRepository.GetLogActionIDByName(TestAppConstants.LOGACTION_SYSTEMCODE_ADD);

                await Task.Run(() =>
				{
                    //Sample data
                    //int codeID = 1;
                    //string key1 = "A";
                    //string codeValue = "test value";
                    //string codeDesc = "test desc";

                    /* Start Prepare Audit Logging */
                    Dictionary<string, string> pkDictionary = new Dictionary<string, string>();
					pkDictionary.Add("Code", systemCode.Code.ToString());
					pkDictionary.Add("Key1", systemCode.Key1);

					Dictionary<string, string> detailDictionary = new Dictionary<string, string>();
					detailDictionary.Add("CodeValue", systemCode.CodeValue);
					detailDictionary.Add("CodeDescription", systemCode.CodeDescription);

					strActionRequest = _commonService.LogService.strConstructLogActionRequest(pkDictionary, detailDictionary);


					/* Insert into SystemCode table */
					using (var context = new ApplicationDbContext(_context.Options))
					{
						context.SystemCode.Add(systemCode);
						context.SaveChanges();
					}

                    // not using unitofwork in order to allow insert into InterfaceLog and AuditLog tables if cannot save into SystemCode e.g. due to PK violation error
                    //_unitOfWork.SystemCodeRepository.Add(systemCode);
                    //_unitOfWork.Save();

                    /* Insert into InterfaceLog table */
                    responseMsg.IsSuccess = true;
                    responseMsg.RequestID = strRequestID;
                    strResponsePayload = JsonConvert.SerializeObject(responseMsg, Formatting.Indented);

                    Utility.InsertIntoInterfaceLogTable(_commonService, strRequestID, intInterfaceTypeID, intInterfaceServiceID, strRequestPayload, strResponsePayload,
                        logDateTime, DateTime.Now, CommonConstants.INTERFACELOG_PROCESSFLAG_SUCCESS, null, ((int)HttpStatusCode.OK).ToString(), null, null, null);


                    /* Insert into AuditLog table */
                    Utility.InsertIntoAuditLogTable(_commonService, intUserID, strDeviceID, strIPAddress, logDateTime, intLogTypeID, intLogActionID, strActionRequest, 
						null, CommonConstants.AUDITLOGSTATUS_SUCCESS, null, null, strRequestID);

                });
			}
			catch (Exception ex)
			{
                errorMessage = ex.Message;
                _commonService.LogService.LogError("Error in adding new code", ex);
				_commonService.LogService.LogError(ex.StackTrace, null);

                responseMsg.IsSuccess = false;
                strResponsePayload = JsonConvert.SerializeObject(responseMsg, Formatting.Indented);

                Utility.InsertIntoInterfaceLogTable(_commonService, strRequestID, intInterfaceTypeID, intInterfaceServiceID, strRequestPayload, strResponsePayload,
                        logDateTime, DateTime.Now, CommonConstants.INTERFACELOG_PROCESSFLAG_ERROR, null, ((int)HttpStatusCode.BadRequest).ToString(), DateTime.Now, errorMessage, null);

                Utility.InsertIntoAuditLogTable(_commonService, intUserID, strDeviceID, strIPAddress, logDateTime, intLogTypeID, intLogActionID, strActionRequest,
                        null, CommonConstants.AUDITLOGSTATUS_ERROR, null, errorMessage, strRequestID);

                Utility.InsertIntoExceptionLogTable(_commonService, 3, DateTime.Now, errorMessage, strRequestID);


                return BadRequest(responseMsg);
            }

			return Ok(responseMsg);
		}

		// PUT: api/Code/1/A
		[HttpPut("{code}/{key1}")]
        public async Task EditCode(int code, string key1, SystemCode systemCode)
        {
            DateTime logDateTime = DateTime.Now;
            //Sample data
            //string codeValue = "test value";
			//string codeDesc = "test desc 1";

			SystemCode editedSystemCode = new SystemCode()
			{
				CodeValue = systemCode.CodeValue,
				CodeDescription = systemCode.CodeDescription
			};

			try
			{
				await Task.Run(() =>
				{
                    var existingSystemCode = _unitOfWork.SystemCodeRepository.GetSystemCodeByCodeAndKey(code, key1);

                    if (existingSystemCode != null)
					{
						/* Start Prepare Audit Logging */
						Dictionary<string, string> pkDictionary = new Dictionary<string, string>();
                        pkDictionary.Add("Code", code.ToString());
                        pkDictionary.Add("Key1", key1);

                        string[] editableColumns = { "CodeValue", "CodeDescription" };

						string strActionRequest = _commonService.LogService.strConstructLogActionRequestEdit(pkDictionary, existingSystemCode, editedSystemCode, editableColumns, true, false);

						/* Update SystemCode table */
						existingSystemCode.CodeValue = systemCode.CodeValue;
						existingSystemCode.CodeDescription = systemCode.CodeDescription;

						_unitOfWork.Save();

						/* Insert into AuditLog table */
						int intUserID = 1;
						string strDeviceID = "AHQ-XXXXX";
						string strIPAddress = "192.168.xxx.xxx";
						int intLogTypeID = _unitOfWork.LogTypeListRepository.GetLogTypeIDByName(TestAppConstants.LOGTYPE_SYSTEMCODE);
						int intLogActionID = _unitOfWork.LogActionListRepository.GetLogActionIDByName(TestAppConstants.LOGACTION_SYSTEMCODE_EDIT);
						string strLogStatus = CommonConstants.AUDITLOGSTATUS_SUCCESS;

                        AuditLog auditLog = new AuditLog()
                        {
                            UserID = intUserID,
                            DeviceID = strDeviceID,
                            IPAddress = strIPAddress,
                            LogDateTime = logDateTime,
                            LogTypeID = intLogTypeID,
                            LogActionID = intLogActionID,
                            ActionRequest = strActionRequest,
                            ActionResponse = null,
                            Status = strLogStatus,
                            ErrorCode = null,
                            ErrorDescription = null,
                            RefID = null
                        };

                        _commonService.LogService.InsertAuditLogToDB(auditLog);
					}
				});
			}
			catch (Exception ex)
			{
				throw;
			}
		}

        // DELETE: api/Code/1/A
        [HttpDelete("{code}/{key1}")]
        public async Task DeleteCode(int code, string key1)
		{
            DateTime logDateTime = DateTime.Now;

            try
			{
				await Task.Run(() =>
				{
					var existingSystemCode = _unitOfWork.SystemCodeRepository.GetSystemCodeByCodeAndKey(code, key1);

					if (existingSystemCode != null)
					{
						/* Start Prepare Audit Logging */
						Dictionary<string, string> pkDictionary = new Dictionary<string, string>();
						pkDictionary.Add("Code", existingSystemCode.Code.ToString());
						pkDictionary.Add("Key1", existingSystemCode.Key1);

						Dictionary<string, string> detailDictionary = new Dictionary<string, string>();
						detailDictionary.Add("CodeValue", existingSystemCode.CodeValue);
						detailDictionary.Add("CodeDescription", existingSystemCode.CodeDescription);

						string strActionRequest = _commonService.LogService.strConstructLogActionRequest(pkDictionary, detailDictionary);

						/* Delete from SystemCode table */
						_unitOfWork.SystemCodeRepository.Delete(existingSystemCode);
						_unitOfWork.Save();

						/* Insert into AuditLog table */
						int intUserID = 1;
						string strDeviceID = "AHQ-XXXXX";
						string strIPAddress = "192.168.xxx.xxx";
						int intLogTypeID = _unitOfWork.LogTypeListRepository.GetLogTypeIDByName(TestAppConstants.LOGTYPE_SYSTEMCODE);
						int intLogActionID = _unitOfWork.LogActionListRepository.GetLogActionIDByName(TestAppConstants.LOGACTION_SYSTEMCODE_DEL);
						string strLogStatus = CommonConstants.AUDITLOGSTATUS_SUCCESS;

                        AuditLog auditLog = new AuditLog()
                        {
                            UserID = intUserID,
                            DeviceID = strDeviceID,
                            IPAddress = strIPAddress,
                            LogDateTime = logDateTime,
                            LogTypeID = intLogTypeID,
                            LogActionID = intLogActionID,
                            ActionRequest = strActionRequest,
                            ActionResponse = null,
                            Status = strLogStatus,
                            ErrorCode = null,
                            ErrorDescription = null,
                            RefID = null
                        };

                        _commonService.LogService.InsertAuditLogToDB(auditLog);
					}
				});
			}
			catch (Exception ex)
			{
				throw;
			}
		}
	}
}
