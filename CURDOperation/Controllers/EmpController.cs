using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CURDOperation.DAL;
using Microsoft.Extensions.Configuration;

namespace CURDOperation.Controllers
{
    public class EmpController : Controller
    {
        private readonly IConfiguration configuration;
        EmployeeDAL employeeDAL;

        public EmpController(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.employeeDAL = new EmployeeDAL(this.configuration);

        }
        // GET: EmpController
        public ActionResult List()
        {
            var model = employeeDAL.GetAllEmployees();
            return View(model);
        }

        // GET: EmpController/Details/5
        public ActionResult Details(int id)
        {

            var model = employeeDAL.GetEmployeeById(id);
            return View(model);
        }

        // GET: EmpController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {
            try
            {
               int result = employeeDAL.AddEmployee(emp);          
                if (result == 1)
                    return RedirectToAction(nameof(List));
                else
                    return BadRequest();
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: EmpController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = employeeDAL.GetEmployeeById(id);
            return View(model);
        }

        // POST: EmpController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee emp)
        {
            try
            {
                 int result = employeeDAL.UpdateEmployee(emp);
                if (result == 1)
                    return RedirectToAction(nameof(List));
                else
                    return BadRequest();
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: EmpController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = employeeDAL.GetEmployeeById(id);
            return View(model);
        }

        // POST: EmpController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {

            try
            {
                int result = employeeDAL.DeleteEmployee(id);
                if (result == 1)
                    return RedirectToAction(nameof(List));
                else
                    return BadRequest();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
