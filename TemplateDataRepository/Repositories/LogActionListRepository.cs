using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateAppModel;
using TemplateDataRepository.Interfaces;

namespace TemplateDataRepository.Repositories
{
    public class LogActionListRepository : GenericRepository<LogActionList>, ILogActionListRepository
    {
        public LogActionListRepository(ApplicationDbContext context) : base(context) { }

        public ApplicationDbContext _context => Context;

        public int GetLogActionIDByName(string strLogActionName)
        {
            int intLogActionID = 0;
            var logAction = _context.LogActionList.SingleOrDefault(l => l.LogActionName == strLogActionName);
            if (logAction != null)
            {
                intLogActionID = logAction.LogActionID;
            }

            return intLogActionID;
        }
    }
}
