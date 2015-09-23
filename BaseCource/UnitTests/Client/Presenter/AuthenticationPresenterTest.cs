using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Client.View;
using Contracts;
using DomainModel.Entities;
using Client.Presentor;
using NUnit.Mocks;
using NSubstitute;

namespace UnitTests.Client.Presenter
{
    [TestFixture]
    public class AuthenticationPresentorTest
    {
        AuthenticationPresenter presentor;
        IAuthenticationView mockAuthenticationView;
        IContract mockContract;
        [SetUp]
        public void Initialize()
        {
            mockAuthenticationView = Substitute.For<IAuthenticationView>();
            mockContract = Substitute.For<IContract>();
            presentor = new AuthenticationPresenter(mockAuthenticationView, (IContract)mockContract);
        }
        [Test]
        public void GetCustomerTest()
        {
            mockContract.GetUser("TestCustomerLogin", "TestCustomerPassword").Returns(new User() { Login = "TestCustomerLogin", Password = "TestCustomerPassword", Name = "TestCustomerName", Role = Role.Customer });
            User user = presentor.Authenticate("TestCustomerLogin", "TestCustomerPassword");
            Assert.AreEqual(user.Name, "TestCustomerName");
            Assert.AreEqual(user.Role, Role.Customer);
        }
        [Test]
        public void GetTechTest()
        {
            mockContract.GetUser("TestTechLogin", "TestTechPassword").Returns(new User() { Login = "TestTechLogin", Password = "TestTechPassword", Name = "TestTechName", Role = Role.Technologist });
            User user = presentor.Authenticate("TestTechLogin", "TestTechPassword");
            Assert.AreEqual(user.Name, "TestTechName");
            Assert.AreEqual(user.Role, Role.Technologist);
        }
        [Test]
        public void GetNonexistentUserTest()
        {
            mockContract.GetUser("TestTechLogin", "TestTechPassword").Returns(new User() { Login = "TestTechLogin", Password = "TestTechPassword", Name = "TestTechName", Role = Role.Technologist });
            User user = presentor.Authenticate("SomeTestLogin", "SomeTestPassword");
            Assert.AreEqual(user.Name, string.Empty);
        }
    }
    
}
