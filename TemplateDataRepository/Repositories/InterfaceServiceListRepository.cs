using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateAppModel;
using TemplateDataRepository.Interfaces;

namespace TemplateDataRepository.Repositories
{
    public class InterfaceServiceListRepository : GenericRepository<InterfaceServiceList>, IInterfaceServiceListRepository
    {
        public InterfaceServiceListRepository(ApplicationDbContext context) : base(context) { }

        public ApplicationDbContext _context => Context;
        public int GetInterfaceServiceIDByName(string strInterfaceServiceName)
        {
            int intInterfaceServiceID = 0;
            var interfaceService = _context.InterfaceServiceList.SingleOrDefault(l => l.InterfaceServiceName == strInterfaceServiceName);
            if (interfaceService != null)
            {
                intInterfaceServiceID = interfaceService.InterfaceServiceID;
            }

            return intInterfaceServiceID;
        }
    }
}
