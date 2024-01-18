using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MiniProject011.IRepositories;
using MiniProject011.Models;
using MiniProject011.Repositories;

namespace MiniProject011.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IActionResult Index()
        {
            var result = _employeeRepository.GetAll();
            return View(result);
        }

        // GET: Companies/Details/5
        public IActionResult Details(int? id)
        {
            id = (id == null) ? 0 : id;
            var employee = _employeeRepository.GetById(id.Value);
            return View(employee);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var companies = _employeeRepository.GetCompanies();
            ViewData["CompanyId"] = new SelectList(companies, "Id", "CompanyDetails");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,FirstName,LastName,PESEL,Phone,Email,CompanyId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.Insert(employee);
                _employeeRepository.Save();
                RedirectToAction("Index");
            }
            var companies = _employeeRepository.GetCompanies();
            ViewData["CompanyId"] = new SelectList(companies, "Id", "CompanyDetails");
            return View(employee);
        }

        public IActionResult Edit(int? id)
        {
            id = (id == null) ? 0 : id;
            Employee employee = _employeeRepository.GetById(id.Value);
            var companies = _employeeRepository.GetCompanies();
            ViewData["CompanyId"] = new SelectList(companies, "Id", "CompanyDetails");
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,FirstName,LastName,PESEL,Phone,Email,CompanyId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.Update(employee);
                _employeeRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var companies = _employeeRepository.GetCompanies();
                ViewData["CompanyId"] = new SelectList(companies, "Id", "CompanyDetails");
                return View(employee);
            }
        }
        
        public IActionResult Delete(int? id)
        {
            id = (id == null) ? 0 : id;
            Employee employee = _employeeRepository.GetById(id.Value);
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            id = (id == null) ? 0 : id;
            _employeeRepository.Delete(id.Value);
            _employeeRepository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
