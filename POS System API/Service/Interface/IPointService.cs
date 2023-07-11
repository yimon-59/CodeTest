using POS_System_API.Model;
using System.Drawing;

namespace POS_System_API.Service.Interface
{
    public interface IPointService
    {
        int CalculatePoint(string memberCode);
    }
}
