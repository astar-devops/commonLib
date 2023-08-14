using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateAppModel;

namespace TemplateDataRepository.Interfaces
{
    public interface IInterfaceServiceListRepository : IGenericRepository<InterfaceServiceList>
    {
        int GetInterfaceServiceIDByName(string strInterfaceServiceName);
    }
}
