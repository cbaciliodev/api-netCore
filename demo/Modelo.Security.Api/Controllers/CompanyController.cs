using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Modelo.Security.Business.Service;
using Modelo.Security.Models;

namespace Modelo.Security.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<tbl_company>> Get()
        {
            return Ok(_companyService.ListCompany());
        }
    }
}