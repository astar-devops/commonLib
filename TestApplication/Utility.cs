using TemplateAppModel;
using CommonLibrary;
using System.Net;

namespace TestApplication
{
    public class Utility
    {
        public static void InsertIntoInterfaceLogTable(ICommonService _commonService, string strRequestID, int intInterfaceTypeID, int intInterfaceServiceID, 
            string? strRequestPayload, string? strResponsePayload, DateTime? requestDateTime, DateTime? responseDateTime, string? strProcessFlag, int? intRetryCount, 
            string? strStatusCode, DateTime? errorDateTime, string? strErrorDesc, string? strRefID)
        {

            InterfaceLog interfaceLog = new InterfaceLog()
            {
                RequestID = strRequestID,
                InterfaceTypeID = intInterfaceTypeID,
                InterfaceServiceID = intInterfaceServiceID,
                RequestPayload = strRequestPayload,
                ResponsePayload = strResponsePayload,
                RequestDateTime = requestDateTime,
                ResponseDateTime = responseDateTime,
                ProcessFlag = strProcessFlag,
                RetryCount = intRetryCount,
                StatusCode = strStatusCode,
                ErrorDateTime = errorDateTime,
                ErrorDescription = strErrorDesc,
                RefID = strRefID
            };

            _commonService.LogService.InsertInterfaceLogToDB(interfaceLog);

        }

        public static void InsertIntoAuditLogTable(ICommonService _commonService, int intUserID, string? strDeviceID, string? strIPAddress,
            DateTime logDateTime, int intLogTypeID, int intLogActionID, string? strActionRequest, string? strActionResponse,
            string? strLogStatus, string? strErrorCode, string? strErrorDesc, string? strRefID)
        {

            AuditLog auditLog = new AuditLog()
            {
                UserID = intUserID,
                DeviceID = strDeviceID,
                IPAddress = strIPAddress,
                LogDateTime = logDateTime,
                LogTypeID = intLogTypeID,
                LogActionID = intLogActionID,
                ActionRequest = strActionRequest,
                ActionResponse = strActionResponse,
                Status = strLogStatus,
                ErrorCode = strErrorCode,
                ErrorDescription = strErrorDesc,
                RefID = strRefID
            };

            _commonService.LogService.InsertAuditLogToDB(auditLog);

        }

        public static void InsertIntoExceptionLogTable(ICommonService _commonService, int exceptionTypeID, DateTime exceptionDateTime, string exceptionDescription,
            string? strRefID)
        {

            ExceptionLog exceptionLog = new ExceptionLog()
            {
                ExceptionTypeID = exceptionTypeID,
                ExceptionDateTime = exceptionDateTime,
                ExceptionDescription = exceptionDescription,
                RefID = strRefID
            };

            _commonService.LogService.InsertExceptionLogToDB(exceptionLog);

        }
    }
}
