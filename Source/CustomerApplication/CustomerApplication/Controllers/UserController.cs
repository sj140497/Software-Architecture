using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Profile.Facade;
using System.Web.Security;
using Profile.Facade.DTOs;
using System.Net;

namespace CustomerApplication.Controllers
{
    public class UserController : Controller
    {

        private IProfileFacade profileFacadeTest;
        public UserController()
        {
            this.profileFacadeTest = new ProfileFacade();
        }

        public UserController(IProfileFacade profileFacadeTest)
        {
            this.profileFacadeTest = profileFacadeTest;
        }

        // GET: User
        public ActionResult Index(string userName)
        {
            var v = profileFacadeTest.getCustomerProfile(userName);
            if (v != null) {
                return View(v);
            }
            return RedirectToAction("Index", "Home");
        }


        public ActionResult Edit(string userName)
        {
            if (userName == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cust = profileFacadeTest.getCustomerProfile(userName);
            if (cust == null)
            {
                return HttpNotFound();
            }
            return View(cust);
        }


        //[Bind(Include = "CustomerNo,BillingAddress,ShippingAddress,purchaseAmount,Ean")] ViewModels.OrderVM order
        [HttpPost]
        public ActionResult Edit([Bind(Include = "UserName,FirstName,LastName,Information")] CustomerProfile cust)
        {
            if (ModelState.IsValid)
            {
                profileFacadeTest.editProfile(cust);
                return RedirectToAction("Index");
            }
            return View(cust);
            
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Models.User user)
        {
            if (ModelState.IsValid)
            {
                var customerProfile = profileFacadeTest.getCustomerProfile(user.UserName);
                if (customerProfile != null && customerProfile.PasswordHash == SHA1.Encode(user.Password))
                {
                    profileFacadeTest.loginAuth(new UserDTO() { UserName = user.UserName, RememberMe = user.RememberMe });

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect!");
                }
            }
            return View(user);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Models.User user)
        {
            if (ModelState.IsValid)
            {
                var customerProfile = profileFacadeTest.getCustomerProfile(user.UserName);
                if (customerProfile == null)
                {
                    profileFacadeTest.registerCustomer(new CustomerLoginDTO()
                    {
                        UserName = user.UserName,
                        Password = user.Password,
                    });

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Username already exists, please try again.");
                }
            }
            return View(user);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
