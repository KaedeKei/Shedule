using Microsoft.EntityFrameworkCore;
using Shedule.Models;
using System.Collections;

namespace Shedule.Data
{
	public class SqliteCustomersAsync : ICustomer
	{
		private readonly AppDbContext _dbContext;

		public SqliteCustomersAsync(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task AddCustomer(Customer customer)
		{
			Customer? newCustomer = await GetByName(customer.CustomerName);
			if (newCustomer == null)
			{
				await _dbContext.Customers.AddAsync(customer);
				await _dbContext.SaveChangesAsync();
			}
			else
			{

			}
		}

		public async Task<IReadOnlyCollection<Customer>> GetCustomers()
		{
			var list = await _dbContext.Customers.ToListAsync();
			return list.AsReadOnly();
		}

		public async Task<IReadOnlyCollection<Customer>?> GetSCustomers(string customerName)
		{
			var searchResults = _dbContext.Customers.Where(it => it.CustomerName.Contains(customerName));
			var list = new List<Customer>();
			if (searchResults == null)
			{
				return list;
			}
			else
			{
				foreach (var item in searchResults)
				{
					list.Add(item);
				}

				return list.AsReadOnly();
			}			
		}

        public async Task<Customer> GetById(int Id)
		{
			var customer = await _dbContext.Customers.FirstAsync(it => it.Id == Id);
			return customer;
        }

        public async Task<Customer> GetByName(string customerName)
		{
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(it => it.CustomerName == customerName);
            return customer;
        }

		public async Task Update(Customer customer)
		{
			_dbContext.Entry(customer).State = EntityState.Modified;
			await _dbContext.SaveChangesAsync();
		}
	}
}
