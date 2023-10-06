using SampleAPI.Entities;
using SampleAPI.Requests;

namespace SampleAPI.Repositories
{
    public interface IOrderRepository
    {
        // TODO: Create repository methods.

        // Suggestions for repo methods:
         Task<IEnumerable<Order>> GetRecentOrders();
         Task<IEnumerable<Order>> GetAllOrders();
         Task AddNewOrder(List<Order> order);
    }
}
