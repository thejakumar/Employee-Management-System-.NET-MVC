using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.Diagnostics;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private IEmployeeRepository _employeeRepository;

        public HomeController( IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [Route("")]
        [Route("/")]
        public ViewResult Index()
        {
            var model = _employeeRepository.GetAllEmployees();
            return View("~/Views/Home/Index.cshtml",model);
        }
         
        [Route("{id?}")]
        public ViewResult Details(int? id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = _employeeRepository.GetEmployee(id??1),
                PageTitle = "Employee Details"
            };
            //Employee model = _employeeRepository.GetEmployee(1);
            //ViewData["Employee"] = model;
            //ViewData["PageTitle"] = "Employee Details";

            //ViewBag.Employee = model;
            //ViewBag.PageTitle = "Employee Details"; b 
            return View(homeDetailsViewModel);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Employee newEmployee = _employeeRepository.Add(employee);
                //return RedirectToAction("Create ", new { id = newEmployee.Id });
                return RedirectToAction("Create");

            }
            return View();
        }

        [HttpGet]
        public IActionResult GetSubDepartments(Dept department)
        {
            var subDepartments = GetSubDepartmentsForDepartment(department);
            return Json(subDepartments);
        }

        private List<string> GetSubDepartmentsForDepartment(Dept department)
        {
            List<string> subDepartments = new List<string>();

            // Define sub-departments based on the selected department
            switch (department)
            {
                case Dept.HR:
                    subDepartments.Add(SubDept.SubDeptHR1.ToString());
                    subDepartments.Add(SubDept.SubDeptHR2.ToString());
                    break;
                case Dept.IT:
                    subDepartments.Add(SubDept.SubDeptIT1.ToString());
                    subDepartments.Add(SubDept.SubDeptIT2.ToString());
                    break;
                // Define sub-departments for other departments as needed
                default:
                    subDepartments.Add(SubDept.None.ToString());
                    break;
            }

            return subDepartments;
        }
    }
}
