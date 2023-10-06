using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using SampleAPI.Entities;
using SampleAPI.Requests;
using System.Collections;

namespace SampleAPI.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public async Task AddNewOrder(List<Order> order)
        {
            using (var dbContext = new SampleApiDbContext())
            {
                await dbContext.Orders.AddRangeAsync(order);
                dbContext.SaveChanges();
            }            
        }

        public async Task<IEnumerable<Order>> GetRecentOrders()
        {
            DateTime cutoffDate = DateTime.Now.AddDays(-1);

            using (var dbContext = new SampleApiDbContext())
            {
                List<Order> orders = await dbContext.Orders.Where(x => x.EntryDate >= cutoffDate && x.IsDeleted != true).ToListAsync();
                return orders;
            }
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            using (var dbContext = new SampleApiDbContext())
            {
                List<Order> orders = await dbContext.Orders.ToListAsync();
                return orders;
            }
        }
    }
}
