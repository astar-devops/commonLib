using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateDataRepository.Interfaces;
using TemplateDataRepository.Repositories;
using Microsoft.EntityFrameworkCore;

namespace TemplateDataRepository
{
	public class UnitOfWork : DbContext, IUnitOfWork
	{
		private readonly ApplicationDbContext _context;

		private readonly ISystemCodeRepository _systemCodeRepository;
		private readonly IAuditLogRepository _auditLogRepository;
		private readonly ILogTypeListRepository _logTypeListRepository;
		private readonly ILogActionListRepository _logActionListRepository;
        private readonly ILogTypeActionRepository _logTypeActionRepository;
        private readonly IInterfaceLogRepository _interfaceLogRepository;
		private readonly IInterfaceTypeListRepository _interfaceTypeListRepository;
		private readonly IInterfaceServiceListRepository _interfaceServiceListRepository;
        private readonly IInterfaceTypeServiceRepository _interfaceTypeServiceRepository;
        private readonly IExceptionLogRepository _exceptionLogRepository;
		private readonly IExceptionTypeListRepository _exceptionTypeListRepository;

		public UnitOfWork(ApplicationDbContext context)
		{
			_context = context;
			_systemCodeRepository = new SystemCodeRepository(_context);
			_auditLogRepository = new AuditLogRepository(_context);
            _logTypeListRepository = new LogTypeListRepository(_context);
            _logActionListRepository = new LogActionListRepository(_context);
            _logTypeActionRepository = new LogTypeActionRepository(_context);
            _interfaceLogRepository = new InterfaceLogRepository(_context);
            _interfaceTypeListRepository = new InterfaceTypeListRepository(_context);
            _interfaceServiceListRepository = new InterfaceServiceListRepository(_context);
            _interfaceTypeServiceRepository = new InterfaceTypeServiceRepository(_context);
            _exceptionLogRepository = new ExceptionLogRepository(_context);
            _exceptionTypeListRepository = new ExceptionTypeListRepository(_context);

        }

		public ISystemCodeRepository SystemCodeRepository
		{
			get { return _systemCodeRepository; } 
		}

		public IAuditLogRepository AuditLogRepository
		{
			get { return _auditLogRepository; }
		}

        public ILogTypeListRepository LogTypeListRepository
        {
            get { return _logTypeListRepository; }
        }

        public ILogActionListRepository LogActionListRepository
        {
            get { return _logActionListRepository; }
        }

        public ILogTypeActionRepository LogTypeActionRepository
        {
            get { return _logTypeActionRepository; }
        }

        public IInterfaceLogRepository InterfaceLogRepository
        {
            get { return _interfaceLogRepository; }
        }

        public IInterfaceTypeListRepository InterfaceTypeListRepository
        {
            get { return _interfaceTypeListRepository; }
        }

        public IInterfaceServiceListRepository InterfaceServiceListRepository
        {
            get { return _interfaceServiceListRepository; }
        }

        public IInterfaceTypeServiceRepository InterfaceTypeServiceRepository
        {
            get { return _interfaceTypeServiceRepository; }
        }

        public IExceptionLogRepository ExceptionLogRepository
        {
            get { return _exceptionLogRepository; }
        }

        public IExceptionTypeListRepository ExceptionTypeListRepository
        {
            get { return _exceptionTypeListRepository; }
        }

        public void Save()
		{
			_context.Database.SetCommandTimeout(180);
			_context.SaveChanges();
		}

		private bool disposed = false;

		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					_context.Dispose();
				}
			}

			this.disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
