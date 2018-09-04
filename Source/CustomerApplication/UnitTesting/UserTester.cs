using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Profile.Facade;
using CustomerApplication.Controllers;
using CustomerApplication.Models;
using Profile.Facade.DTOs;
using System.Web.Mvc;

namespace UnitTesting
{
    [TestFixture]
    public class UserTester
    {
        [TestCase]
        public void ProfileIndexTest()
        {
            ProfileFacade_test profileFacadeTest = new ProfileFacade_test();
            UserController userController = new UserController(profileFacadeTest);

            var actual = (userController.Index("C00000001") as ViewResult).ViewData.Model;
            Assert.IsNotNull(actual);
            Assert.IsInstanceOf(typeof(CustomerProfile), actual);

            var actual2 = (userController.Index("C034536"));
            Assert.IsNotNull(actual2);
            Assert.IsInstanceOf(typeof(RedirectToRouteResult), actual2);
        }

        [TestCase]
        public void ProfileEditTest()
        {
            ProfileFacade_test profileFacadeTest = new ProfileFacade_test();
            UserController userController = new UserController(profileFacadeTest);
            var edit = new CustomerProfile()
            {
                UserName = "C00000001",
                FirstName = "Test1",
                LastName = "Test2",
                Information = "TestInfo",
            };

            var actual = (userController.Edit(edit.UserName) as ViewResult).ViewData.Model;
            Assert.IsNotNull(actual);
            Assert.IsInstanceOf(typeof(CustomerProfile), actual);
        }

        [TestCase]
        public void ProfileLoginTest()
        {
            ProfileFacade_test profileFacadeTest = new ProfileFacade_test();
            UserController userController = new UserController(profileFacadeTest);

            var user1 = new User()
            {
                UserName = "C00000001",
                Password = "pw123",
                RememberMe = true
            };

            var user2 = new User()
            {
                UserName = "C0003455",
                Password = "pw123",
                RememberMe = true
            };

            var actual = (userController.Login(user1));
            Assert.IsNotNull(actual);
            Assert.IsInstanceOf(typeof(RedirectToRouteResult), actual);

            var actual2 = (userController.Login(user2) as ViewResult).ViewData.Model;
            Assert.IsNotNull(actual2);
            Assert.IsInstanceOf(typeof(User), actual2);
        }

        [TestCase]
        public void ProfileRegisterTest()
        {
            ProfileFacade_test profileFacadeTest = new ProfileFacade_test();
            UserController userController = new UserController(profileFacadeTest);

            var user1 = new User()
            {
                UserName = "C00456568",
                Password = "pw123",
                RememberMe = true
            };

            var user2 = new User()
            {
                UserName = "C00000001",
                Password = "pw123",
                RememberMe = true
            };

            var actual = (userController.Register(user1));
            Assert.IsNotNull(actual);
            Assert.IsInstanceOf(typeof(RedirectToRouteResult), actual);

            var actual2 = (userController.Register(user2) as ViewResult).ViewData.Model;
            Assert.IsNotNull(actual2);
            Assert.IsInstanceOf(typeof(User), actual2);
        }
    }
}
