using Microsoft.EntityFrameworkCore;
using MiniProject011.IRepositories;
using MiniProject011.Models;
using MiniProject011.ViewModels;
using System.ComponentModel.Design;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MiniProject011.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Context _context;

        public EmployeeRepository(Context context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAll()
        {
            var result = _context.Employees.Include(x => x.Company);
            return result;
        }

        public IEnumerable<CompanyVM> GetCompanies()
        {
            var companies = _context.Companies;
            var result = new List<CompanyVM>();
            foreach (var item in companies)
            {
                result.Add(new CompanyVM() { 
                    Id = item.Id,
                    CompanyDetails = item.CompanyName + ", " + item.AddressLine + ", " + item.City
                });
            }
            return result;
        }

        public Employee GetById(int employeeId)
        {
            Employee result = _context.Employees.Include(x => x.Company).FirstOrDefault(x => x.Id == employeeId);
            return result;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Insert(Employee employee)
        {
            _context.Employees.Add(employee);
        }

        public void Update(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
        }

        public void Delete(int employeeId)
        {
            Employee employee = _context.Employees.Find(employeeId);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
            }
        }
    }
}
