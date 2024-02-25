using Microsoft.EntityFrameworkCore;
using Shedule.Models;

namespace Shedule.Data
{
	public class AppDbContext : DbContext
	{
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Manager> Managers { get; set; }
		public DbSet<DeliveryPoint> DeliveryPoints { get; set; }
		public DbSet<DeliveryEvent> DeliveryEvents { get; set; }

		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}
	}
}
