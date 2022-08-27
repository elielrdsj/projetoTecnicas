using Microsoft.EntityFrameworkCore;

namespace YuGiOhAPI.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Yugioh> YugiohDb { get; set; }
    }
}
