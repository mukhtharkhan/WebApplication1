using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class RentalDbContext: DbContext
    {
        public RentalDbContext(DbContextOptions<RentalDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Cars> Cars { get; set; }

        public virtual DbSet<CarImages> CarImages { get; set; }

        public virtual DbSet<Customer> Customer { get; set; }

        public virtual DbSet<Rentals> Rentals { get; set; }

        public virtual DbSet<Bill> Bills { get; set; }
    }
}
