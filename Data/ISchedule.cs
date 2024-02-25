using Shedule.Models;

namespace Shedule.Data
{
	public interface ISchedule
	{
		public Task AddDeliveryEvent(DeliveryEvent delivery);
		Task<IReadOnlyCollection<DeliveryEvent>> GetDeliveryEvents();
		Task<DeliveryEvent> GetById(int Id);
    }
}
