using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateAppModel;
using TemplateDataRepository.Interfaces;

namespace TemplateDataRepository.Repositories
{
    public class LogTypeListRepository : GenericRepository<LogTypeList>, ILogTypeListRepository
    {
        public LogTypeListRepository(ApplicationDbContext context) : base(context) { }

        public ApplicationDbContext _context => Context;

        public int GetLogTypeIDByName(string strLogTypeName)
        {
            int intLogTypeID = 0;
            var logType = _context.LogTypeList.SingleOrDefault(l => l.LogTypeName == strLogTypeName);
            if (logType != null)
            {
                intLogTypeID = logType.LogTypeID;
            }

            return intLogTypeID;
        }
    }
}
