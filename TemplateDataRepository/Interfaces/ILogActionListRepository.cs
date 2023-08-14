using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateAppModel;

namespace TemplateDataRepository.Interfaces
{
    public interface ILogActionListRepository : IGenericRepository<LogActionList>
    {
        int GetLogActionIDByName(string strLogActionName);
    }
}
