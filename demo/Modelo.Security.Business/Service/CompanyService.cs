using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Modelo.Security.DataAcces;
using Modelo.Security.Models;

namespace Modelo.Security.Business.Service
{
   public  class CompanyService : ICompanyService
    {
        public DbSecurityContext _context;

        public CompanyService(DbSecurityContext context)
        {
            _context = context;
        }

        public bool DeleteCompany(int id)
        {
            var company = _context.tbl_company.Find(id);

            if(company == null)
            {
                return false;
            }

            _context.tbl_company.Remove(company);
            _context.SaveChanges();

            return true;
        }

        public List<tbl_company> ListCompany() => _context.tbl_company.ToList();

        public tbl_company ListCompanyById(int id) =>
            _context.tbl_company.Where(company => company.Id == id).FirstOrDefault();

        public bool RegisterCompany(tbl_company entity)
        {

            
            try
            {
                _context.tbl_company.Add(entity);
                _context.SaveChanges();
                return true;

            }
            catch (DbUpdateConcurrencyException)
            {

                return false;
            }
        }

        public bool UpdateCompany(tbl_company entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
                return true;

            }
            catch (DbUpdateConcurrencyException)
            {

                return false;
            }
        }
    }
}

