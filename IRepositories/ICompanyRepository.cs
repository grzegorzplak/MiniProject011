using MiniProject011.Models;

namespace MiniProject011.IRepositories
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetAll();
        Company GetById(int companyId);
        void Insert(Company company);
        void Update(Company company);
        void Delete(int companyId);
        void Save();
    }
}
