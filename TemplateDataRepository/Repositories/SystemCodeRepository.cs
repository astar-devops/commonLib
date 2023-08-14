using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateDataRepository.Interfaces;
using TemplateAppModel;

namespace TemplateDataRepository.Repositories
{
	public class SystemCodeRepository : GenericRepository<SystemCode>, ISystemCodeRepository
	{
		public SystemCodeRepository(ApplicationDbContext context) : base(context) { }

		public ApplicationDbContext _context => Context;

		public SystemCode GetSystemCodeByCodeAndKey(int code, string key1)
		{
			return _context.SystemCode.SingleOrDefault(c => c.Code == code && c.Key1 == key1);
		}
	}
}
