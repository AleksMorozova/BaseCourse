using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DomainModel.Entities;
using Client.Translator;
using Client.ClientModel.Entities;

namespace UnitTests.Client.Translator
{
    [TestFixture]
    public class EntityTranslatorTest
    {
        [Test]
        public void TranslateToClientOrderTest()
        {
            DateTime dt = DateTime.Now;
            Order order = new Order()
            {
                Id = 10,
                PlacingDate = dt,
                Status = Status.New,
                User = new User()
                {
                    Id = 1,
                    Login = "Login",
                    Name = "Name",
                    Password = "123456",
                    Role = Role.Customer
                },
                Items = new List<OrderItem>()
                {
                    new OrderItem
                    {
                        Id=5,
                        Count=2,
                        Product=new Product(){Id=1,Name="Test product 1", Price=new ProductPrice(){Price=100}}
                    },
                    new OrderItem
                    {
                        Id=20,
                        Count=10,
                        Product=new Product(){Id=1,Name="Test product 2", Price=new ProductPrice(){Price=1000}}
                    }
                }
            };
            ClientOrder clientOrder = EntitiesTranslator.TranslateToClientOrder(order);
            Assert.AreEqual(order.Id, clientOrder.Id);
            Assert.AreEqual(order.PlacingDate, clientOrder.PlacingDate);
            Assert.AreEqual(order.Status, clientOrder.Status);
            Assert.AreEqual(order.Items.Count, clientOrder.Products.Count);
            Assert.AreEqual(order.Items[0].Product.Name, clientOrder.Products[0].Name);
            Assert.AreEqual(order.Items[1].Product.Name, clientOrder.Products[1].Name);
        }
        [Test]
        public void TranslateToClientOrderItemTest()
        {
            OrderItem orderItem = new OrderItem()
            {
                Id = 10,
                Count = 30,
                Product = new Product()
                {
                    Id = 50,
                    Name = "Test product",
                    Price = new ProductPrice()
                    {
                        Price = 100
                    }
                }
            };
            ClientOrderItem clientOrderItem = EntitiesTranslator.TranslateToClientOrderItem(orderItem);
            Assert.AreEqual(clientOrderItem.Id, orderItem.Product.Id);
            Assert.AreEqual(clientOrderItem.Name, orderItem.Product.Name);
            Assert.AreEqual(clientOrderItem.Price, orderItem.Product.Price.Price);
            Assert.AreEqual(clientOrderItem.Count, orderItem.Count);
        }
        [Test]
        public void TranslateToOrderTest()
        {
            ClientOrder clientOrder = new ClientOrder()
            {
                Id = 1,
                PlacingDate = DateTime.Now,
                Status = Status.New,
                Products = new System.ComponentModel.BindingList<ClientOrderItem>()
                {
                    new ClientOrderItem(1)
                    {
                        Count=5,
                        Name="Test product 1",
                        Price=100
                    },
                    new ClientOrderItem(2)
                    {
                        Count=2,
                        Name="Test product 2",
                        Price=200
                    }
                }
            };
            User customer = new User()
            {
                Id = 111,
                Login = "Login",
                Name = "Name",
                Password = "Password",
                Role = Role.Customer
            };
            Order order = EntitiesTranslator.TranslateToOrder(clientOrder, customer);
            Assert.AreEqual(order.Id,clientOrder.Id);
            Assert.AreEqual(order.PlacingDate,clientOrder.PlacingDate);
            Assert.AreEqual(order.User, customer);
            Assert.AreEqual(order.Status, clientOrder.Status);
            Assert.AreEqual(order.Items.Count, clientOrder.Products.Count);
            Assert.AreEqual(order.Items[0].Count, clientOrder.Products[0].Count);
            Assert.AreEqual(order.Items[0].Product.Name, clientOrder.Products[0].Name);
            Assert.AreEqual(order.Items[0].Product.Id, clientOrder.Products[0].Id);
            Assert.AreEqual(order.Items[1].Count, clientOrder.Products[1].Count);
            Assert.AreEqual(order.Items[1].Product.Name, clientOrder.Products[1].Name);
            Assert.AreEqual(order.Items[1].Product.Id, clientOrder.Products[1].Id);
        }
        [Test]
        public void TranslateToOrderItemTest()
        {
            ClientOrderItem clientOrderItem = new ClientOrderItem(1)
            {
                Count = 10,
                Name = "Test product 1",
                Price = 100,
            };
            Order order = new Order();
            OrderItem orderItem = EntitiesTranslator.TranslateToOrderItem(clientOrderItem, order);
            Assert.AreEqual(orderItem.Product.Id, clientOrderItem.Id);
            Assert.AreEqual(orderItem.Count, clientOrderItem.Count);
            Assert.AreEqual(orderItem.Order, order);
            Assert.AreEqual(orderItem.Product.Name, clientOrderItem.Name);
        }
    }
}
