using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Contracts;
using Client.Presentor;
using Client.View;
using NSubstitute;
using DomainModel.Entities;
using Client.ClientModel.Entities;
using Client.ClientModel.Commands;

namespace UnitTests.Client.Presenter
{
    [TestFixture]
    class CustomerEditOrderPresenterTest
    {
        CustomerEditOrderPresenter presenter;
        ICustomerEditOrderView mockCustomerEditOrderView;
        IContract mockContract;
        [SetUp]
        public void Initialize()
        {
            mockCustomerEditOrderView = Substitute.For<ICustomerEditOrderView>();
            mockContract = Substitute.For<IContract>();
            presenter = new CustomerEditOrderPresenter(mockCustomerEditOrderView, mockContract);
        }
        [Test]
        public void GetAllProductsTest()
        {
            Product p1 = new Product()
            {
                Id = 1,
                Name = "Test product 1",
                Units = 3,
                Price = new ProductPrice()
                {
                    Price = 100
                }
            };
            Product p2 = new Product()
            {
                Id = 1,
                Name = "Test product 2",
                Units = 3,
                Price = new ProductPrice()
                {
                    Price = 200
                }
            };
            Product p3 = new Product()
            {
                Id = 1,
                Name = "Test product 3",
                Units = 3,
                Price = new ProductPrice()
                {
                    Price = 300
                }
            };
            IList<Product> products = new List<Product>(){p1,p2,p3};
            mockContract.GetProducts().Returns(products);
            var newProducts = presenter.GetAllProducts();
            Assert.AreEqual(newProducts, products);
        }
        [Test]
        public void AddOrderItemToOrderTest()
        {
            ClientOrder testOrder = new ClientOrder(1)
            {
                PlacingDate = DateTime.Now,
                Status = Status.New,
                Products = new System.ComponentModel.BindingList<ClientOrderItem>()
            };
            Product testProduct = new Product()
            {
                Id = 1,
                Name = "Test product 1",
                Price = new ProductPrice()
                {
                    Price = 100
                }
            };
            int value = 10;
            presenter.CommandList.Clear();
            mockCustomerEditOrderView.Order = testOrder;
            presenter.AddOrderItemToOrder(testProduct, value, testOrder);
            Assert.AreEqual(presenter.CommandList[0].Entity, mockCustomerEditOrderView.Order.Products[0]);
            Assert.AreEqual(presenter.CommandList[0].CommandType, CommandType.Create);
            Assert.AreEqual(presenter.CommandList[1].Entity, mockCustomerEditOrderView.Order.Products[0]);
            Assert.AreEqual(presenter.CommandList[1].CommandType, CommandType.Update);
            Assert.AreEqual(presenter.CommandList[1].FieldName, "Count");
            Assert.AreEqual(presenter.CommandList[1].Value, value);
        }
        [Test]
        public void RemoveOrderItemFromOrderTest()
        {
            ClientOrder testOrder = new ClientOrder(1)
            {
                PlacingDate = DateTime.Now,
                Status = Status.New,
                Products = new System.ComponentModel.BindingList<ClientOrderItem>()
            };
            Product testProduct = new Product()
            {
                Id = 1,
                Name = "Test product 1",
                Price = new ProductPrice()
                {
                    Price = 100
                }
            };
            int value = 10;
            presenter.CommandList.Clear();
            mockCustomerEditOrderView.Order = testOrder;
            presenter.AddOrderItemToOrder(testProduct, value, testOrder);
            Assert.AreEqual(presenter.CommandList[0].Entity, mockCustomerEditOrderView.Order.Products[0]);
            Assert.AreEqual(presenter.CommandList[0].CommandType, CommandType.Create);
            Assert.AreEqual(presenter.CommandList[1].Entity, mockCustomerEditOrderView.Order.Products[0]);
            Assert.AreEqual(presenter.CommandList[1].CommandType, CommandType.Update);
            Assert.AreEqual(presenter.CommandList[1].FieldName, "Count");
            Assert.AreEqual(presenter.CommandList[1].Value, value);
            presenter.RemoveOrderItemFromOrder(mockCustomerEditOrderView.Order.Products[0]);
            Assert.AreEqual(mockCustomerEditOrderView.Order.Products.Count, 0);
            Assert.AreEqual(presenter.CommandList.Count, 0);
        }
        [Test]
        public void RemoveOrderTest()
        {
            ClientOrder testOrder = new ClientOrder(1)
            {
                PlacingDate = DateTime.Now,
                Status = Status.New,
                Products = new System.ComponentModel.BindingList<ClientOrderItem>()
            };
            Product testProduct = new Product()
            {
                Id = 1,
                Name = "Test product 1",
                Price = new ProductPrice()
                {
                    Price = 100
                }
            };
            int value = 10;
            presenter.CommandList.Clear();
            mockCustomerEditOrderView.Order = testOrder;
            presenter.CommandList.AddCreateOrderCommand(testOrder);
            presenter.AddOrderItemToOrder(testProduct, value, testOrder);
            Assert.AreEqual(presenter.CommandList[0].Entity, testOrder);
            Assert.AreEqual(presenter.CommandList[0].CommandType, CommandType.Create);
            Assert.AreEqual(presenter.CommandList[1].Entity, mockCustomerEditOrderView.Order.Products[0]);
            Assert.AreEqual(presenter.CommandList[1].CommandType, CommandType.Create);
            Assert.AreEqual(presenter.CommandList[2].Entity, mockCustomerEditOrderView.Order.Products[0]);
            Assert.AreEqual(presenter.CommandList[2].CommandType, CommandType.Update);
            Assert.AreEqual(presenter.CommandList[2].FieldName, "Count");
            Assert.AreEqual(presenter.CommandList[2].Value, value);
            presenter.RemoveOrder();
            Assert.AreEqual(presenter.CommandList.Count, 0);
        }
        [Test]
        public void SetOrderSatusToNewTest()
        {
            ClientOrder testOrder = new ClientOrder(1)
            {
                PlacingDate = DateTime.Now,
                Status = Status.New,
                Products = new System.ComponentModel.BindingList<ClientOrderItem>()
            };
            Product testProduct = new Product()
            {
                Id = 1,
                Name = "Test product 1",
                Price = new ProductPrice()
                {
                    Price = 100
                }
            };
            int value = 10;
            presenter.CommandList.Clear();
            mockCustomerEditOrderView.Order = testOrder;
            presenter.CommandList.AddCreateOrderCommand(testOrder);
            presenter.AddOrderItemToOrder(testProduct, value, testOrder);
            Assert.AreEqual(presenter.CommandList[0].Entity, testOrder);
            Assert.AreEqual(presenter.CommandList[0].CommandType, CommandType.Create);
            Assert.AreEqual(presenter.CommandList[1].Entity, mockCustomerEditOrderView.Order.Products[0]);
            Assert.AreEqual(presenter.CommandList[1].CommandType, CommandType.Create);
            Assert.AreEqual(presenter.CommandList[2].Entity, mockCustomerEditOrderView.Order.Products[0]);
            Assert.AreEqual(presenter.CommandList[2].CommandType, CommandType.Update);
            Assert.AreEqual(presenter.CommandList[2].FieldName, "Count");
            Assert.AreEqual(presenter.CommandList[2].Value, value);
            presenter.SetOrderSatusToNew();
            Assert.AreEqual(presenter.CommandList[3].Entity, testOrder);
            Assert.AreEqual(presenter.CommandList[3].CommandType, CommandType.Update);
            Assert.AreEqual(presenter.CommandList[3].FieldName, "Status");
            Assert.AreEqual(presenter.CommandList[3].Value, Status.New);
        }
    }
}
