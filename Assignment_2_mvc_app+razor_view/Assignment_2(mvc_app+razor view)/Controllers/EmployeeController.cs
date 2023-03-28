using Assignment_2_mvc_app_razor_view_.Models;
using System.Web.Mvc.Html;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment_2_mvc_app_razor_view_.Controllers
{
    public class EmployeeController : Controller
    {
        
        public static List<Employee> employees = new List<Employee>()
        {
            new Employee{Id=10,Name="Yash",City="Mumbai"}
        };
        
        public ActionResult Index()
        {
            return View(employees);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            if(ModelState.IsValid)
                employees.Add(emp);

            return RedirectToAction("Index");
        }
        
        public ActionResult Edit(int id)
        {
            return View(employees.Where(x => x.Id == id).FirstOrDefault());
        }
        
        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            Employee obj = employees.Where(x => x.Id == emp.Id).FirstOrDefault();
            obj.Name = emp.Name;
            obj.City = emp.City;
            return RedirectToAction("Index");
        }
        
   
        //here only HttpGet and HttpPost works
        public ActionResult Delete(int id)
        {
            Employee obj = employees.Where(x => x.Id == id).FirstOrDefault();
            employees.Remove(obj);
   
            return RedirectToAction("Index");
        }

    }
}
