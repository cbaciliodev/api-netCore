using Modelo.Security.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Security.Business.Service
{
    public interface ICompanyService
    {

        List<tbl_company> ListCompany();

        tbl_company ListCompanyById(int id);

        bool DeleteCompany(int id);

        bool RegisterCompany(tbl_company entity);

        bool UpdateCompany(tbl_company entity);

    }
}
