using log4net;
using log4net.Config;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Reflection;
using TemplateAppModel;
using TemplateDataRepository;

namespace CommonLibrary
{
    public class LogService : ILogService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILog _auditLogger = LogManager.GetLogger("AuditLogger");
        private readonly ILog _performanceLogger = LogManager.GetLogger("PerformanceLogger");
        public LogService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
        }

        /// <summary>
        /// Write INFO log into log file
        /// </summary>
        /// <param name="strLogMessage">Message to be written to log file</param>
        public void LogInfo(string strLogMessage)
        {
            MethodBase callerDetails = null;
            try
            {
                if (!string.IsNullOrEmpty(strLogMessage))
                {
                    callerDetails = new StackFrame(1).GetMethod();
                    _auditLogger.Info(callerDetails.DeclaringType.Name + "  " + callerDetails.Name + " - " + strLogMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing INFO log. Exception: " + ex.ToString());
            }
            finally
            {
                if (callerDetails != null)
                {
                    callerDetails = null;
                }
            }
        }

        /// <summary>
        /// Write DEBUG log into log file
        /// </summary>
        /// <param name="strLogMessage">Message to be written to log file</param>
        public void LogDebug(string strLogMessage)
        {
            MethodBase callerDetails = null;
            try
            {
                if (!string.IsNullOrEmpty(strLogMessage))
                {
                    callerDetails = new StackFrame(1).GetMethod();
                    _auditLogger.Debug(callerDetails.DeclaringType.Name + "  " + callerDetails.Name + " - " + strLogMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing DEBUG log. Exception: " + ex.ToString());
            }
            finally
            {
                if (callerDetails != null)
                {
                    callerDetails = null;
                }
            }
        }

        /// <summary>
        /// Write WARNING log into log file
        /// </summary>
        /// <param name="strLogMessage">Message to be written to log file</param>
        public void LogWarn(string strLogMessage)
        {
            MethodBase callerDetails = null;
            try
            {
                if (!string.IsNullOrEmpty(strLogMessage))
                {
                    callerDetails = new StackFrame(1).GetMethod();
                    _auditLogger.Warn(callerDetails.DeclaringType.Name + "  " + callerDetails.Name + " - " + strLogMessage);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing WARNING log. Exception: " + ex.ToString());
            }
            finally
            {
                if (callerDetails != null)
                {
                    callerDetails = null;
                }
            }
        }

        /// <summary>
        /// Write ERROR log into log file
        /// </summary>
        /// <param name="strLogMessage">Message to be written to log file</param>
        /// <param name="exceptionMessage">Exception message to be written to log file</param>
        public void LogError(string strLogMessage, Exception exceptionMessage)
        {
            MethodBase callerDetails = null;
            try
            {
                if (!string.IsNullOrEmpty(strLogMessage))
                {
                    callerDetails = new StackFrame(1).GetMethod();
                    if (exceptionMessage != null)
                    {
                        if (exceptionMessage.InnerException == null)
                        {
                            _auditLogger.Error(callerDetails.DeclaringType.Name + "  " + callerDetails.Name + " - " + strLogMessage + " " + exceptionMessage.Source.ToString().Trim() + " - " + exceptionMessage.Message.ToString().Trim());
                        }
                        else
                        {
                            _auditLogger.Error(callerDetails.DeclaringType.Name + "  " + callerDetails.Name + " - " + strLogMessage + " " + exceptionMessage.Source.ToString().Trim() + " - " + exceptionMessage.Message.ToString().Trim() + " " + exceptionMessage.InnerException.Message.ToString().Trim());

                            if (exceptionMessage.InnerException.InnerException != null)
                            {
                                if (exceptionMessage.InnerException.InnerException.Message != null)
                                {
                                    _auditLogger.Error(callerDetails.DeclaringType.Name + "  " + callerDetails.Name + " - " + strLogMessage + " " + exceptionMessage.Source.ToString().Trim() + " - " + exceptionMessage.Message.ToString().Trim() + " " + exceptionMessage.InnerException.InnerException.Message.ToString().Trim());
                                }
                            }
                        }
                    }
                    else
                    {
                        _auditLogger.Error(callerDetails.DeclaringType.Name + "  " + callerDetails.Name + " - " + strLogMessage);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing ERROR log. Exception: " + ex.ToString());
            }
            finally
            {
                if (callerDetails != null)
                {
                    callerDetails = null;
                }
            }
        }

        /// <summary>
        /// Log performance
        /// </summary>
        /// <param name="strOperationName"></param>
        /// <param name="startDateTime"></param>
        /// <param name="endDateTime"></param>
        public void LogPerformance(string strOperationName, DateTime startDateTime, DateTime endDateTime)
        {
            if (!_performanceLogger.IsInfoEnabled) return;
            {
                var span = endDateTime.Subtract(startDateTime);
                _performanceLogger.Info(strOperationName + " - " + startDateTime.ToString("HH:mm:ss.fff")
                                                        + " to " + endDateTime.ToString("HH:mm:ss.fff") + " = " +
                                                        span.Minutes + "m, " + span.Seconds + "s, " +
                                                        span.Milliseconds + "ms");
            }
        }

        public void InsertAuditLogToDB(AuditLog auditLog)
        {
            try
            {
                if (_unitOfWork != null && _unitOfWork.AuditLogRepository != null)
                {
                    _unitOfWork.AuditLogRepository.Add(auditLog);
                    _unitOfWork.Save();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void InsertInterfaceLogToDB(InterfaceLog interfaceLog)
        {
            try
            {
                if (_unitOfWork != null && _unitOfWork.InterfaceLogRepository != null)
                {
                    _unitOfWork.InterfaceLogRepository.Add(interfaceLog);
                    _unitOfWork.Save();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void InsertExceptionLogToDB(ExceptionLog exceptionLog)
        {
            try
            {
                if (_unitOfWork != null && _unitOfWork.ExceptionLogRepository != null)
                {
                    _unitOfWork.ExceptionLogRepository.Add(exceptionLog);
                    _unitOfWork.Save();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string strConstructRequestID(string strSource)
        {
            string longRequestDateTime = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            string requestDateTime = longRequestDateTime.Substring(0, 14);
            int randomNo = intGenerateRandomNo();
            string strRequestID = strSource + requestDateTime + randomNo;
            return strRequestID;
        }

		// Generate Random Number
        private int intGenerateRandomNo()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }

        public string strConstructLogActionRequest(Dictionary<string, string> pkDictionary, Dictionary<string, string> detailDictionary)
        {
            LogDetails logDetails = new LogDetails();

            List<LogColumns> logPKColumns = new List<LogColumns>();
            logPKColumns = AddIntoLogColumnsList(logPKColumns, pkDictionary);
            logDetails.PK = logPKColumns;

            List<LogColumns> logDetailsColumns = new List<LogColumns>();
            logDetailsColumns = AddIntoLogColumnsList(logDetailsColumns, detailDictionary);
            logDetails.Columns = logDetailsColumns;

            string actionDetails = JsonConvert.SerializeObject(logDetails, Formatting.Indented);

            return actionDetails;
        }

        public string strConstructLogActionRequestEdit(Dictionary<string, string> pkDictionary,
            dynamic oldObject, dynamic newObject, string[] editableColumns, bool hasBefore = false, bool includeUneditedColumns = false)
        {
            LogDetails logDetails = new LogDetails();

            List<LogColumns> logPKColumns = new List<LogColumns>();
            logPKColumns = AddIntoLogColumnsList(logPKColumns, pkDictionary);
            logDetails.PK = logPKColumns;

            List<LogColumns> logDetailsColumns = new List<LogColumns>();
            logDetailsColumns = GetEditedAndUneditedColumns(oldObject, newObject, editableColumns, hasBefore, includeUneditedColumns);
            logDetails.Columns = logDetailsColumns;

            string actionDetails = JsonConvert.SerializeObject(logDetails, Formatting.Indented);

            return actionDetails;
        }

        private List<LogColumns> AddIntoLogColumnsList(List<LogColumns> columns, Dictionary<string, string> listDict)
        {
            foreach (KeyValuePair<string, string> item in listDict)
            {
                columns.Add(new LogColumns { FieldName = item.Key, Value = item.Value });
            }

            return columns;
        }

        private List<LogColumns> GetEditedAndUneditedColumns(dynamic oldObject, dynamic newObject,
            string[] editableColumns, bool hasBefore = false, bool includeUneditedColumns = false)
        {
            List<LogColumns> editedColumns = new List<LogColumns>();
            List<string> listEditable = new List<string>(editableColumns);
            var oldRecord = oldObject;
            var oNewRecord = newObject;

            var oType = oldRecord.GetType();

            foreach (var oProperty in oType.GetProperties())
            {
                var oOldValue = oProperty.GetValue(oldRecord, null);
                var oNewValue = oProperty.GetValue(oNewRecord, null);

                if (listEditable.Contains(oProperty.Name))
                {
                    if (!object.Equals(oOldValue, oNewValue))
                    {
                        var sNewValue = oNewValue == null ? "null" : oNewValue.ToString();

                        if (hasBefore)
                        {
                            // Before and After Value are different (edited)
                            editedColumns.Add(new LogColumns { FieldName = oProperty.Name, Value = $"{oOldValue}~{sNewValue}" });
                        }
                        else
                        {
                            // Only After value
                            editedColumns.Add(new LogColumns { FieldName = oProperty.Name, Value = sNewValue });
                        }
                    }
                    else
                    {
                        if (includeUneditedColumns)
                        {
                            // Before and After Value are the same (not edited)
                            editedColumns.Add(new LogColumns { FieldName = oProperty.Name, Value = $"{oOldValue}~{oOldValue}" });
                        }
                    }
                }
            }

            return editedColumns;
        }
    }
}
