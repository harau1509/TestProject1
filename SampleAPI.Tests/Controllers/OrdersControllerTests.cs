using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using SampleAPI.Controllers;
using SampleAPI.Entities;
using SampleAPI.Repositories;
using SampleAPI.Requests;
using System.Net;

namespace SampleAPI.Tests.Controllers
{
    public class OrdersControllerTests
    {
        private readonly OrdersController ordersController;
        private readonly Mock<IOrderRepository> repositoryMock = new Mock<IOrderRepository>();
        private readonly Mock<ILogger<OrdersController>> loggerMock = new Mock<ILogger<OrdersController>>();

        public OrdersControllerTests() {

            ordersController = new OrdersController(repositoryMock.Object, loggerMock.Object);
        }

        [Fact]
        public void GetRecentOrder_ShouldReturnOkResult()
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

            repositoryMock.Setup(repo => repo.GetRecentOrders()).Returns(Task.FromResult(orders.AsEnumerable()));

            var response = ordersController.GetRecentOrders();
            Assert.IsType<OkObjectResult>(response.Result.Result);
        }

        [Fact]
        public void GetRecentOrder_ShouldReturnBadResult()
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

            repositoryMock.Setup(repo => repo.GetRecentOrders()).Throws(new Exception("Error occurred!"));

            var response = ordersController.GetRecentOrders();
            Assert.IsType<BadRequestObjectResult>(response.Result.Result);
        }

        [Fact]
        public void AddNewOrder_ShouldReturnOkResult()
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

            repositoryMock.Setup(repo => repo.AddNewOrder(It.IsAny<List<Order>>())).Returns(Task.CompletedTask);

            var response = ordersController.AddNewOrder(orders);
            Assert.IsType<OkObjectResult>(response.Result);
        }

        [Fact]
        public void AddNewOrder_ShouldReturnBadResult()
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

            repositoryMock.Setup(repo => repo.AddNewOrder(It.IsAny<List<Order>>())).Throws(new Exception("Error occurred!"));

            var response = ordersController.AddNewOrder(orders);
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }

        [Fact]
        public void GetAllOrders_ShouldReturnOkResult()
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
            orders.Add(new Order
            {
                OrderID = 2,
                Name = "Test2",
                Description = "Test2",
                EntryDate = DateTime.Now,
                IsInvoiced = true,
                IsDeleted = false,
            });

            repositoryMock.Setup(repo => repo.GetAllOrders()).Returns(Task.FromResult(orders.AsEnumerable()));

            var response = ordersController.GetAllOrders();
            Assert.IsType<OkObjectResult>(response.Result.Result);
        }

        [Fact]
        public void GetAllOrders_ShouldReturnBadResult()
        {
            repositoryMock.Setup(repo => repo.GetAllOrders()).Throws(new Exception("Error occurred!"));

            var response = ordersController.GetAllOrders();
            Assert.IsType<BadRequestObjectResult>(response.Result.Result);
        }
    }
}
