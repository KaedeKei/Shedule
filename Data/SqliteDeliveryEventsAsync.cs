using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Shedule.Models;
using Shedule.Pages;

namespace Shedule.Data
{
	public class SqliteDeliveryEventsAsync : IDeliveryEvent
	{
		private readonly AppDbContext _dbContext;

		public SqliteDeliveryEventsAsync(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task AddEvent(DeliveryEvent deliveryEvent)
		{
			await _dbContext.DeliveryEvents.AddAsync(deliveryEvent);
			await _dbContext.SaveChangesAsync();
		}

		public async Task<IReadOnlyCollection<DeliveryEvent>> GetEvents()
		{
			var list = await _dbContext.DeliveryEvents.ToListAsync();
			return list.AsReadOnly();
		}

		public async Task<IReadOnlyCollection<DeliveryEvent>> GetActiveEvents()
		{
			var list = new List<DeliveryEvent>();

			foreach (var item in _dbContext.DeliveryEvents)
			{
				if (item.EventPoint.IsEnable == true)
				{
					list.Add(item);
				}
			}

			return list.AsReadOnly();
		}

		public async Task<IReadOnlyCollection<DeliveryEvent>> GetSEvents(string word)
		{
			var list = new List<DeliveryEvent>();

			foreach (var item in _dbContext.DeliveryEvents)
			{
				if (item.EventPoint.ThisCustomer.CustomerName.ToLower().Contains(word.ToLower()) ||
					item.EventPoint.PointName.ToLower().Contains(word.ToLower()))
				{
					list.Add(item);
				}
			}

			return list.AsReadOnly();
		}

		public async Task<IReadOnlyCollection<DeliveryEvent>> GetByDate(DateTime date)
		{
			var list = new List<DeliveryEvent>();

			foreach (var item in _dbContext.DeliveryEvents)
			{
				if (item.EventDeliveryDate == date)
				{
					list.Add(item);
				}
			}

			return list.AsReadOnly();
		}

		public async Task<IReadOnlyCollection<DeliveryEvent>> GetActiveByDateAndManager(DateTime date, int managerId)
		{
			var list = new List<DeliveryEvent>();

			foreach (var item in _dbContext.DeliveryEvents)
			{
				if (item.EventDeliveryDate == date && item.EventManager.Id == managerId && item.IsRelevant == true)
				{
					list.Add(item);
				}
			}

			return list.AsReadOnly();
		}

		public async Task<IReadOnlyCollection<DeliveryEvent>> GetByDateAndPoint(DateTime date, int pointId)
		{
			var list = new List<DeliveryEvent>();

			foreach (var item in _dbContext.DeliveryEvents)
			{
				if (item.EventDeliveryDate == date && item.EventPoint.Id == pointId)
				{
					list.Add(item);
				}
			}

			return list.AsReadOnly();
		}

		public async Task<DeliveryEvent> GetById(int Id)
		{
			var thisEvent = await _dbContext.DeliveryEvents.FirstAsync(it => it.Id == Id);
			return thisEvent;
		}

		public async Task<DeliveryEvent> GetByRelevant(bool isRelevant)
		{
			var thisEvent = await _dbContext.DeliveryEvents.FirstAsync(it => it.IsDone == isRelevant);
			return thisEvent;
		}

		public async Task Update(DeliveryEvent deliveryEvent)
		{
			_dbContext.Entry(deliveryEvent).State = EntityState.Modified;
			await _dbContext.SaveChangesAsync();
		}
	}
}
