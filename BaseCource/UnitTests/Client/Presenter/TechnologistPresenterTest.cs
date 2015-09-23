using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Client.Presentor;
using Client.View;
using Contracts;
using NSubstitute;
using DomainModel.Entities;

namespace UnitTests.Client.Presenter
{
    [TestFixture]
    class TechnologistPresenterTest
    {
        TechnologistPresenter presentor;
        ITechnologistView mocktechnologistOrdersView;
        IContract mockContract;

        [SetUp]
        public void Initialize()
        {
            mocktechnologistOrdersView = Substitute.For<ITechnologistView>();
            mockContract = Substitute.For<IContract>();
            presentor = new TechnologistPresenter(mocktechnologistOrdersView, mockContract);
        }
        [Test]
        public void GetOrderItemsTest()
        {
            Order testOrder1 = new Order() { Id = 1 };
            Order testOrder2 = new Order() { Id = 2 };
            List<Order> testOrders = new List<Order>() { testOrder1, testOrder2 };
            //mockCustomerOrdersView.Orders.Returns(testOrders);
            OrderItem testOrderItem1 = new OrderItem() { Id = 0, Count = 2, Order = testOrder1, Product = new Product() { Id = 1, Name = "Test Product 1", } };
            OrderItem testOrderItem2 = new OrderItem() { Id = 1, Count = 5, Order = testOrder1, Product = new Product() { Id = 2, Name = "Test Product 2", } };
            List<OrderItem> testOrderItems = new List<OrderItem>() { testOrderItem1, testOrderItem2 };
            mockContract.GetOrderItems(Arg.Any<int>()).Returns(testOrderItems);
            presentor.GetOrderItems(mocktechnologistOrdersView.Orders[0]);
            Assert.AreEqual(mocktechnologistOrdersView.Orders, testOrders);
            Assert.AreEqual(mocktechnologistOrdersView.Orders[1].Items, null);
            Assert.AreEqual(mocktechnologistOrdersView.Orders[0].Items.Count, testOrder1.Items.Count);
            Assert.AreEqual(mocktechnologistOrdersView.Orders[0].Items[0], testOrder1.Items[0]);
            Assert.AreEqual(mocktechnologistOrdersView.Orders[0].Items[1], testOrder1.Items[1]);
        }

        [Test]
        public void FillOrderListTest()
        {
            Order testOrder1 = new Order() { Id = 1 };
            Order testOrder2 = new Order() { Id = 2 };
            List<Order> testOrders = new List<Order>() { testOrder1, testOrder2 };
            mockContract.GetOrderList(Arg.Any<int>()).Returns(testOrders);
            presentor.FillOrderList();
            Assert.AreEqual(mocktechnologistOrdersView.Orders, testOrders);
            Assert.AreEqual(mocktechnologistOrdersView.Orders[0], testOrder1);
            Assert.AreEqual(mocktechnologistOrdersView.Orders[1], testOrder2);
        }

    }
}
