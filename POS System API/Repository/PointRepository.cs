using POS_System_API.DAO;
using POS_System_API.Model;

namespace POS_System_API.Repository
{
    public class PointRepository
    {
        private readonly DataContext pointSystemDBContext;

        public PointRepository(DataContext pointSystemDBContext)
        {
            this.pointSystemDBContext = pointSystemDBContext;
        }

        public int CalculatePoint(string memberCode)
        {
            int point = 0;
            var product = pointSystemDBContext.Product.Find(memberCode);
            if (product != null)
            {
                if(product.Name != "Alcohol" && product.UnitPrice == 100)
                {
                    point += 10;
                };
            }
            return Create(memberCode, point);
        }

        public int Create(string memberCode, int point)
        {
            Member member = new Member();
            member.MemberCode = memberCode;
            member.Point = point;   
            int result = 0;
            pointSystemDBContext.Member.Add(member);
            result = pointSystemDBContext.SaveChanges();
            return result;
        }
    }
}
