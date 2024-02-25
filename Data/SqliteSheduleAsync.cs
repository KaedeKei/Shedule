using Microsoft.EntityFrameworkCore;
using Shedule.Models;

namespace Shedule.Data
{
	public class SqliteSheduleAsync : ISchedule
	{
		private readonly AppDbContext _dbContext;

		public async Task AddDeliveryEvent(DeliveryEvent delivery)
		{
			await _dbContext.DeliveryEvents.AddAsync(delivery);
			await _dbContext.SaveChangesAsync();
		}

		public async Task<IReadOnlyCollection<DeliveryEvent>> GetDeliveryEvents()
		{
			var list = await _dbContext.DeliveryEvents.ToListAsync();
			return list.AsReadOnly();
		}

		public SqliteSheduleAsync(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<DeliveryEvent> GetById(int Id)
		{
			var deliveryEvent = await _dbContext.DeliveryEvents.FirstAsync(it => it.Id == Id);
			return deliveryEvent;
		}

		public async Task Update(DeliveryEvent delivery)
		{
			_dbContext.Entry(delivery).State = EntityState.Modified;
			await _dbContext.SaveChangesAsync();
		}
	}
}
