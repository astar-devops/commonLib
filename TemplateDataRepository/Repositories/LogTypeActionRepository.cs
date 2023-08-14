using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateAppModel;
using TemplateDataRepository.Interfaces;

namespace TemplateDataRepository.Repositories
{
    public class LogTypeActionRepository : GenericRepository<LogTypeAction>, ILogTypeActionRepository
    {
        public LogTypeActionRepository(ApplicationDbContext context) : base(context) { }

        public ApplicationDbContext _context => Context;
    }
}
