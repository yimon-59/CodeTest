using POS_System_API.Model;
using System.Runtime.InteropServices;

namespace POS_System_API.Repository.Interface
{
    public interface IPointRepository
    {
        int Create(string memberCode);
        int CalculatePoint(string memberCode);
    }
}
