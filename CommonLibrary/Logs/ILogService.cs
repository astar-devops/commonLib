using TemplateAppModel;

namespace CommonLibrary
{
    public interface ILogService
    {
        void LogInfo(string strLogMessage);
        void LogDebug(string strLogMessage);
        void LogWarn(string strLogMessage);
        void LogError(string strLogMessage, Exception exceptionMessage);
        void LogPerformance(string strOperationName, DateTime startDateTime, DateTime endDateTime);
        void InsertAuditLogToDB(AuditLog auditLog);
        void InsertInterfaceLogToDB(InterfaceLog interfaceLog);
        void InsertExceptionLogToDB(ExceptionLog exceptionLog);
        string strConstructRequestID(string strSource);
        string strConstructLogActionRequest(Dictionary<string, string> pkDictionary, Dictionary<string, string> detailDictionary);
        string strConstructLogActionRequestEdit(Dictionary<string, string> pkDictionary, dynamic oldObject, dynamic newObject, string[] editableColumns, 
            bool hasBefore = false, bool includeUneditedColumns = false);
    }
}
