using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;
using BLL;

namespace DBWebMVCAPP.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {

            List<Employee> employees = HRManager.GetAll();
            return View(employees);
        }
        public ActionResult Details(int DEPTNO)
        {

            Employee employee = HRManager.GetByID(DEPTNO);
            return View(employee);
        }
        public ActionResult Delete(int DEPTNO)
        {

            bool status = HRManager.Delete(DEPTNO);
            return RedirectToAction("index");
        }

        public ActionResult Insert()
        {
            return View();
 
 
 // comment added by saurabh
 }

        [HttpPost]
        public ActionResult Insert(int DEPTNO, string DNAME, string LOC)
        {
            Employee emp = new Employee
            {

                DEPTNO = DEPTNO,
                DNAME = DNAME,
                LOC = LOC
             
            };
            HRManager.Insert(emp);
            return RedirectToAction("index");

        }

        public ActionResult Update(int DEPTNO)
        {
            Employee employee = HRManager.GetByID(DEPTNO);
            return View(employee);
        }

        [HttpPost]
        public ActionResult Update(int DEPTNO, string DNAME, string LOC)
        {
        Employee emp = new Employee
        {
            DEPTNO = DEPTNO,
            DNAME = DNAME,
            LOC = LOC
         };
            HRManager.Update(emp);
            return RedirectToAction("index");
        }



    }
}
