using Shedule.Models;
using Shedule.Pages;

namespace Shedule.Data
{
	public interface IDeliveryEvent
	{
		public Task AddEvent(DeliveryEvent deliveryEvent);
		Task<IReadOnlyCollection<DeliveryEvent>> GetEvents();
		Task<IReadOnlyCollection<DeliveryEvent>> GetActiveEvents();
		Task<IReadOnlyCollection<DeliveryEvent>> GetSEvents(string word);
		Task<IReadOnlyCollection<DeliveryEvent>> GetByDate(DateTime date);
		Task<IReadOnlyCollection<DeliveryEvent>> GetActiveByDateAndManager(DateTime date, int managerId);
		Task<IReadOnlyCollection<DeliveryEvent>> GetByDateAndPoint(DateTime date, int pointId);
		public Task<DeliveryEvent> GetById(int Id);
		public Task<DeliveryEvent> GetByRelevant(bool isRelevant);
		public Task Update(DeliveryEvent deliveryEvent);
	}
}
