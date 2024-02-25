using Microsoft.EntityFrameworkCore;
using Shedule.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;

namespace Shedule.Data
{
	public class SqliteDeliveryPointAsync : IDeliveryPoint
	{
		private readonly AppDbContext _dbContext;

		public SqliteDeliveryPointAsync(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task AddDeliveryPoint(DeliveryPoint deliveryPoint)
		{
			DeliveryPoint? point = await GetByName(deliveryPoint.PointName);
			if (point == null)
			{
				await _dbContext.DeliveryPoints.AddAsync(deliveryPoint);
				await _dbContext.SaveChangesAsync();
			}
			else
			{

			}
		}

		public async Task<IReadOnlyCollection<DeliveryPoint>> GetDeliveryPoints()
		{
			var list = await _dbContext.DeliveryPoints.ToListAsync();
			return list.AsReadOnly();
		}

		public async Task<IReadOnlyCollection<DeliveryPoint>?> GetDeliveryPointsByDayAndManagersId(int id, DateTime day)
		{
			var list = new List<DeliveryPoint>();

			foreach (var item in _dbContext.DeliveryPoints)
			{
				if (item.DeliveryDay.DayOfWeek == day.DayOfWeek && item.ThisManager.Id == id)
				{
					list.Add(item);
				}
			}

			return list.AsReadOnly();
		}

		public async Task<IReadOnlyCollection<DeliveryPoint>?> GetSDeliveryPoints(string word)
		{
			var list = new List<DeliveryPoint>();

			foreach (var item in _dbContext.DeliveryPoints)
			{
				if (item.PointName.ToLower().Contains(word.ToLower()) ||
					item.ThisCustomer.CustomerName.ToLower().Contains(word.ToLower()) ||
					item.ThisManager.ManagerName.ToLower().Contains(word.ToLower()) ||
					item.Adress.ToLower().Contains(word.ToLower()))
					{
					list.Add(item);
					}
			}

			return list.AsReadOnly();
		}

		public async Task<DeliveryPoint> GetById(int Id)
		{
			var point = await _dbContext.DeliveryPoints.FirstAsync(it => it.Id == Id);
			return point;
        }

		public async Task<DeliveryPoint> GetByName(string deliveryPointName)
		{
            var point = await _dbContext.DeliveryPoints.FirstOrDefaultAsync(it => it.PointName == deliveryPointName);
			return point;

        }

		public async Task Update(DeliveryPoint point)
		{
			_dbContext.Entry(point).State = EntityState.Modified;
			await _dbContext.SaveChangesAsync();
		}
	}
}
