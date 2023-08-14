using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateDataRepository.Interfaces;

namespace TemplateDataRepository
{
	public interface IUnitOfWork : IDisposable
	{
		ISystemCodeRepository SystemCodeRepository { get; }
		IAuditLogRepository AuditLogRepository { get; }
        ILogTypeListRepository LogTypeListRepository { get; }
        ILogActionListRepository LogActionListRepository { get; }
        ILogTypeActionRepository LogTypeActionRepository { get; }
        IInterfaceLogRepository InterfaceLogRepository { get; }
        IInterfaceTypeListRepository InterfaceTypeListRepository { get; }
        IInterfaceServiceListRepository InterfaceServiceListRepository { get; }
        IInterfaceTypeServiceRepository InterfaceTypeServiceRepository { get; }
        IExceptionLogRepository ExceptionLogRepository { get; }
        IExceptionTypeListRepository ExceptionTypeListRepository { get; }
        void Save();
	}
}
