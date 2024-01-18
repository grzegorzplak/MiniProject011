using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MiniProject011.IRepositories;
using MiniProject011.Models;
using MiniProject011.Repositories;

namespace MiniProject011.Controllers
{
    public class CompaniesController : Controller
    {
        private ICompanyRepository _companyRepository;

        public CompaniesController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        // GET: Companies
        public IActionResult Index()
        {
            var result = _companyRepository.GetAll();
            return View(result);
        }

        // GET: Companies/Details/5
        public IActionResult Details(int? id)
        {
            id = (id == null) ? 0 : id;
            var company = _companyRepository.GetById(id.Value);
            return View(company);
        }
        
        // GET: Companies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,CompanyName,AddressLine,City,PostalCode")] Company company)
        {
            if (ModelState.IsValid)
            {
                _companyRepository.Insert(company);
                _companyRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        

        // GET: Companies/Edit/5
        public IActionResult Edit(int? id)
        {
            id = (id == null) ? 0 : id;
            Company company = _companyRepository.GetById(id.Value);
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,CompanyName,AddressLine,City,PostalCode")] Company company)
        {
            if (ModelState.IsValid)
            {
                _companyRepository.Update(company);
                _companyRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            else
            { 
                return View(company);
            }
        }
        
        // GET: Companies/Delete/5
        public IActionResult Delete(int? id)
        {
            id = (id == null) ? 0 : id;
            Company company = _companyRepository.GetById(id.Value);
            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            id = (id == null) ? 0 : id;
            _companyRepository.Delete(id.Value);
            _companyRepository.Save();
            return RedirectToAction(nameof(Index));
        }
/*
        private bool CompanyExists(int id)
        {
            return _context.Companies.Any(e => e.Id == id);
        }
        */
    }
}
