using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateAppModel;

namespace TemplateDataRepository.Interfaces
{
    public interface ILogTypeListRepository : IGenericRepository<LogTypeList>
    {
        int GetLogTypeIDByName(string strLogTypeName);
    }
}
