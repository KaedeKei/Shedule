namespace Shedule.Models
{
	public class DeliveryEvent
	{
		public int Id { get; set; }
		public DeliveryPoint EventPoint { get; set; }
		public DateTime EventDeliveryDate { get; set; }
		public Manager EventManager { get; set; }
		public bool IsRelevant { get; set; }
		public bool IsDone { get; set; }

		public DeliveryEvent()
		{

		}

		public DeliveryEvent(DeliveryPoint thisPoint, DateTime thisDeliveryDate, bool isRelevant, bool isDone)
		{
			EventPoint = thisPoint;
			EventDeliveryDate = thisDeliveryDate;
			IsRelevant = isRelevant;
			IsDone = isDone;
			EventManager = thisPoint.ThisManager;
		}
	}
}
