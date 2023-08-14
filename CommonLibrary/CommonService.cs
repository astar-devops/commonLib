using TemplateDataRepository;

namespace CommonLibrary
{
    public class CommonService : ICommonService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogService _logService;

        public CommonService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _logService = new LogService(_unitOfWork);
        }

        public ILogService LogService { get { return _logService; } }
    }
}
