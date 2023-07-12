using Microsoft.EntityFrameworkCore;
using MobileAPI.Model;

namespace MobileAPI.DAO
{
    public class MobileDataContext : DbContext
    { 
        public MobileDataContext(DbContextOptions<MobileDataContext> options)
            : base(options)
        {
        }

        public DbSet<Member> Member { get; set; } = null!;
        public DbSet<Coupon> Coupon { get; set; } = null!;
        public DbSet<MemberCoupon> MemberCoupon { get; set; } = null!;
        public DbSet<PurchaseHistory> PurchaseHistory { get; set; } = null!;
    }
}
