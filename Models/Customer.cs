namespace Shedule.Models
{
	public class Customer
	{
		public int Id { get; set; }
		public string CustomerName { get; set; }
		public bool IsDebtor { get; set; }

		public Customer(string customerName, bool isDebtor)
		{
			CustomerName = customerName;
			IsDebtor = isDebtor;
		}

		public Customer()
		{
		}

		public override string ToString()
		{
			return this.CustomerName;
		}
	}
}
