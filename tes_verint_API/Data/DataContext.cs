using Microsoft.EntityFrameworkCore;

namespace tes_verint_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<employees> Employees { get; set; }

    }
}
