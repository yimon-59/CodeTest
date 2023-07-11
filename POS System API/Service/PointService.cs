using POS_System_API.Model;
using POS_System_API.Repository.Interface;
using POS_System_API.Service.Interface;

namespace POS_System_API.Service
{
    public class PointService : IPointService
    {
        private readonly IPointRepository _pointRepository;

        public PointService(IPointRepository pointRepository)
        {
            _pointRepository = pointRepository;
        }

        public int CalculatePoint(string memberCode)
        {
            return _pointRepository.CalculatePoint(memberCode);
        }
    }
}
