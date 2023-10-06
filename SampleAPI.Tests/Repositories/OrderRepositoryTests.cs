using FluentAssertions;
using FluentAssertions.Extensions;
using SampleAPI.Entities;
using SampleAPI.Repositories;
using SampleAPI.Requests;

namespace SampleAPI.Tests.Repositories
{
    public class OrderRepositoryTests
    {
        [Fact]
        public void AddNewOrder_ShouldWorkAsExpected()
        {
            List<Order> orders = new List<Order>();
            orders.Add(new Order
            {
                OrderID = 1,
                Name = "Test1",
                Description = "Test1",
                EntryDate = DateTime.Now,
                IsInvoiced = true,
                IsDeleted = false,
            });

            OrderRepository orderRepository = new OrderRepository();
            var response = orderRepository.AddNewOrder(orders);
            Assert.NotNull(response);
        }
    }
}