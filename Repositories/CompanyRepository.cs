using Microsoft.EntityFrameworkCore;
using MiniProject011.IRepositories;
using MiniProject011.Models;

namespace MiniProject011.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly Context _context;

        public CompanyRepository(Context context) 
        {
            _context = context;
        }

        public IEnumerable<Company> GetAll()
        {
            var result = _context.Companies.ToList();
            return result;
        }

        public Company GetById(int companyId)
        {
            Company result = _context.Companies.FirstOrDefault(x => x.Id == companyId);
            return result;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Insert(Company company)
        {
            _context.Companies.Add(company);
        }

        public void Update(Company company)
        {
            _context.Entry(company).State = EntityState.Modified;
        }

        public void Delete(int companyId)
        {
            Company company = _context.Companies.Find(companyId);
            if (company != null)
            {
                _context.Companies.Remove(company);
            }
        }
    }
}
