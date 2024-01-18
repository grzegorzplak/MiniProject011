using MiniProject011.Models;
using MiniProject011.ViewModels;

namespace MiniProject011.IRepositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        IEnumerable<CompanyVM> GetCompanies();
        Employee GetById(int employeeId);
        void Insert(Employee employee);
        void Update(Employee employee);
        void Delete(int employeeId);
        void Save();
    }
}
