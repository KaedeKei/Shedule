using Shedule.Models;

namespace Shedule.Data
{
	public interface ICustomer
	{
		public Task AddCustomer(Customer customer);
		Task<IReadOnlyCollection<Customer>> GetCustomers();
		Task<IReadOnlyCollection<Customer>?> GetSCustomers(string customerName);
        Task<Customer> GetByName(string customerName);
        Task<Customer> GetById(int id);
		public Task Update(Customer customer);
	}
}
