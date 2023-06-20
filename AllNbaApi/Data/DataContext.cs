using AllNbaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AllNbaApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Star> Stars { get; set; }
    }
}
