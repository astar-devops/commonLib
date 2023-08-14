using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateAppModel;
using TemplateDataRepository.Interfaces;

namespace TemplateDataRepository.Repositories
{
    public class InterfaceLogRepository : GenericRepository<InterfaceLog>, IInterfaceLogRepository
    {
        public InterfaceLogRepository(ApplicationDbContext context) : base(context) { }

        public ApplicationDbContext _context => Context;
    }
}
