using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateAppModel;
using TemplateDataRepository.Interfaces;

namespace TemplateDataRepository.Repositories
{
    public class ExceptionTypeListRepository : GenericRepository<ExceptionTypeList>, IExceptionTypeListRepository
    {
        public ExceptionTypeListRepository(ApplicationDbContext context) : base(context) { }

        public ApplicationDbContext _context => Context;
    }
}
