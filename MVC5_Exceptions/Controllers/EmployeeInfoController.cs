using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MVC5_Exceptions.Models;
using System.Data.Entity.Infrastructure;

namespace MVC5_Exceptions.Controllers
{
    //Method 3
   [HandleError(ExceptionType = typeof(DbUpdateException), View = "Error")]
    public class EmployeeInfoController : Controller
    {

        ApplicationEntities ctx;

        public EmployeeInfoController()
        {
            ctx = new ApplicationEntities();  
        }

        // GET: EmployeeInfo
        public ActionResult Index()
        {
           var Emps = ctx.EmployeeInfoes.ToList();
            return View(Emps);
        }

       

        // GET: EmployeeInfo/Create
        public ActionResult Create()
        {
            var Emp = new EmployeeInfo();
            return View(Emp);
        }

        // POST: EmployeeInfo/Create
        [HttpPost]
        public ActionResult Create(EmployeeInfo Emp)
        {
            try
            {
                ctx.EmployeeInfoes.Add(Emp);
                ctx.SaveChanges();

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                //Method 1
             // return View("Error",new HandleErrorInfo(ex,"EmployeeInfo","Create"));

                //Method 2
                throw ex;
            }
        }


        public ActionResult Edit(int id)
        {
            var Emp = ctx.EmployeeInfoes.Find(id);
            return View(Emp);
        }


       [HttpPost]
       public ActionResult Edit(int id, EmployeeInfo Emp)
        {
            try
            {
               var ep =  ctx.EmployeeInfoes.Find(id);
               if (ep != null)
               {
                   ep.EmpName = Emp.EmpName;
                   ep.DeptName = Emp.DeptName;

                   if (Emp.Salary < 1000)
                   {
                       throw new Exception();
                   }
                   
                   ep.Salary = Emp.Salary;

                   ep.Designation = Emp.Designation;
                   ctx.SaveChanges();
                   
               }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //Method 1
                //return View("Error",new HandleErrorInfo(ex,"EmployeeInfo","Create"));

                //Method 2
                throw ex;
            }
        }


        /// <summary>
        /// Method 2
        /// </summary>
        /// <param name="filterContext"></param>
       //protected override void OnException(ExceptionContext filterContext)
       //{
       //    Exception exception = filterContext.Exception;
       //    //Logging the Exception
       //    filterContext.ExceptionHandled = true;


       //    var Result = this.View("Error", new HandleErrorInfo(exception,
       //        filterContext.RouteData.Values["controller"].ToString(),
       //        filterContext.RouteData.Values["action"].ToString()));

       //    filterContext.Result = Result;
           
       //}

    }
}
