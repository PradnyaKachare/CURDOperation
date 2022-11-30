using CURDOperation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CURDOperation.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IConfiguration configuration;
        CustomerDAL customerDAL;

        public CustomerController(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.customerDAL = new CustomerDAL(this.configuration);
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Customers cust)
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Customers cust)
        {
            Customers c = customerDAL.CustomerLogin(cust);
            if(c!=null)
            {
                return RedirectToAction("List", "emp");
            }
            else
            return View();
        }
    }


}
