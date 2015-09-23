using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Client.Presentor;
using Client.View;
using Contracts;
using NSubstitute;
using Client.ClientModel.Entities;
using DomainModel.Entities;

namespace UnitTests.Client.Presenter
{
    [TestFixture]
    class CustomerOrdersPresentorTest
    {
        CustomerOrdersPresenter presenter;
        ICustomerOrdersView mockCustomerOrdersView;
        IContract mockContract;
        [SetUp]
        public void Initialize()
        {
            mockCustomerOrdersView = Substitute.For<ICustomerOrdersView>();
            mockContract = Substitute.For<IContract>();
            presenter = new CustomerOrdersPresenter(mockCustomerOrdersView, mockContract);
        }
        [Test]
        public void GetOrderItemsTest()
        {
            ClientOrder testOrder1 = new ClientOrder() { Id = 1 };
            ClientOrder testOrder2 = new ClientOrder() { Id = 2 };
            List<ClientOrder> testOrders = new List<ClientOrder>() { testOrder1, testOrder2 };
            mockCustomerOrdersView.Orders.Returns(testOrders);
            OrderItem testOrderItem1 = new OrderItem()
            {
                Id = 0,
                Count = 2,
                Product = new Product()
                    {
                        Id = 1,
                        Name = "Test Product 1",
                        Price = new ProductPrice()
                            {
                                Price = 200
                            }
                    }
            };
            OrderItem testOrderItem2 = new OrderItem()
            {
                Id = 1,
                Count = 5,
                Product = new Product()
                {
                    Id = 2,
                    Name = "Test Product 2",
                    Price = new ProductPrice()
                    {
                        Price=10
                    }

                }
            };
            List<OrderItem> testOrderItems = new List<OrderItem>() { testOrderItem1, testOrderItem2 };
            mockContract.GetOrderItems(Arg.Any<int>()).Returns(testOrderItems);
            presenter.GetOrderItems(mockCustomerOrdersView.Orders[0]);
            Assert.AreEqual(mockCustomerOrdersView.Orders, testOrders);
            Assert.AreEqual(mockCustomerOrdersView.Orders[1].Products, null);
            Assert.AreEqual(mockCustomerOrdersView.Orders[0].Products.Count, testOrder1.Products.Count);
            Assert.AreEqual(mockCustomerOrdersView.Orders[0].Products[0], testOrder1.Products[0]);
            Assert.AreEqual(mockCustomerOrdersView.Orders[0].Products[1], testOrder1.Products[1]);
        }
        [Test]
        public void FillOrderListTest()
        {
            Order testOrder1 = new Order() { Id = 1 };
            Order testOrder2 = new Order() { Id = 2 };
            List<Order> testOrders = new List<Order>() { testOrder1, testOrder2 };
            mockContract.GetOrderList(Arg.Any<int>()).Returns(testOrders);
            presenter.FillOrderList();
            Assert.AreEqual(mockCustomerOrdersView.Orders.Count, testOrders.Count);
            Assert.AreEqual(mockCustomerOrdersView.Orders[0].Id, testOrder1.Id);
            Assert.AreEqual(mockCustomerOrdersView.Orders[0].PlacingDate, testOrder1.PlacingDate);
            Assert.AreEqual(mockCustomerOrdersView.Orders[0].Status, testOrder1.Status);
            Assert.AreEqual(mockCustomerOrdersView.Orders[1].Id, testOrder2.Id);
            Assert.AreEqual(mockCustomerOrdersView.Orders[1].PlacingDate, testOrder2.PlacingDate);
            Assert.AreEqual(mockCustomerOrdersView.Orders[1].Status, testOrder2.Status);
        }
    }
}
