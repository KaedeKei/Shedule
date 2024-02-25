using Shedule.Models;

namespace Shedule.Data
{
	public interface IDeliveryPoint
	{
		public Task AddDeliveryPoint(DeliveryPoint deliveryPoint);
		public Task<IReadOnlyCollection<DeliveryPoint>> GetDeliveryPoints();
		public Task<IReadOnlyCollection<DeliveryPoint>> GetDeliveryPointsByDayAndManagersId(int id, DateTime day);
		public Task<IReadOnlyCollection<DeliveryPoint>> GetSDeliveryPoints(string pointName);
		public Task<DeliveryPoint> GetById(int Id);
		public Task<DeliveryPoint> GetByName(string deliveryPointName);
		public Task Update(DeliveryPoint point);
	}
}
