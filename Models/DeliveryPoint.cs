namespace Shedule.Models
{
	public class DeliveryPoint
	{
		public int Id { get; set; }
		public string PointName { get; set; }
		public string Adress { get; set; }
		public Customer ThisCustomer { get; set; }
		public Manager ThisManager { get; set; }
		public DateTime DeliveryDay { get; set; }
		public bool IsEnable { get; set; }

		public DeliveryPoint(string pointName, string adress, Customer thisCustomer, Manager thisManager, DateTime deliveryDay, bool isEnable)
		{
			PointName = pointName;
			Adress = adress;
			ThisCustomer = thisCustomer;
			ThisManager = thisManager;
			DeliveryDay = deliveryDay;
			IsEnable = isEnable;
		}

		public DeliveryPoint(string pointName, string adress, bool isEnable)
		{
			PointName = pointName;
			Adress = adress;
			IsEnable = isEnable;
		}

		public DeliveryPoint()
		{
		}

		public override string ToString()
		{
			return this.Id + ". " + this.ThisCustomer + " - " + this.PointName + " - " + this.Adress + " - " + this.DeliveryDay;
		}
	}
}
