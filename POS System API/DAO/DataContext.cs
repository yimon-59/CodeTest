using Microsoft.EntityFrameworkCore;
using POS_System_API.Model;

namespace POS_System_API.DAO
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Member> Member { get; set; } = null!;
        public DbSet<Products> Product { get; set; } = null!;
    }

}
