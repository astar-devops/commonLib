using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateAppModel;
using TemplateDataRepository.Interfaces;

namespace TemplateDataRepository.Repositories
{
    public class InterfaceTypeListRepository : GenericRepository<InterfaceTypeList>, IInterfaceTypeListRepository
    {
        public InterfaceTypeListRepository(ApplicationDbContext context) : base(context) { }

        public ApplicationDbContext _context => Context;

        public int GetInterfaceTypeIDByName(string strInterfaceTypeName)
        {
            int intInterfaceTypeID = 0;
            var interfaceType = _context.InterfaceTypeList.SingleOrDefault(l => l.InterfaceTypeName == strInterfaceTypeName);
            if (interfaceType != null)
            {
                intInterfaceTypeID = interfaceType.InterfaceTypeID;
            }

            return intInterfaceTypeID;
        }
    }
}
