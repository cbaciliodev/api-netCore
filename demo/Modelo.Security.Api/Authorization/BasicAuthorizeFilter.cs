using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Modelo.Security.Business.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Security.Api.Authorization
{
    public class BasicAuthorizeFilter:IAuthorizationFilter
    {
        private string realm;
        private ICompanyService _companyService;

        public BasicAuthorizeFilter(ICompanyService companyService, string realm = null)
        {
            this.realm = realm;
            _companyService = companyService;
        }


        public bool IsAuthorized(string username, string password)
        {
            bool authorized = false;

            try
            {
                var company = _companyService.ListCompany()
                    .Where(x => x.Username == username & x.Password == password)
                    .FirstOrDefault();

                if(company != null)
                {
                    authorized = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("BasicAuthorizeFilter " + ex.Message);
                authorized = false;
            }

            return authorized;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {

            string authHeader = context
                .HttpContext
                .Request
                .Headers["Authorization"];

            if(authHeader != null && authHeader.StartsWith("Basic "))
            {
                var encodedUsernamePassword = authHeader
                    .Split(' ', 2, StringSplitOptions.RemoveEmptyEntries)
                    [1]?.Trim();
                var decodedUsernamePassword = Encoding.UTF8
                    .GetString(Convert.FromBase64String(encodedUsernamePassword));

                var username = decodedUsernamePassword.Split(':', 2)[0];
                var password = decodedUsernamePassword.Split(':', 2)[1];

                if (IsAuthorized(username, password))
                {
                    return;
                }
            }

            context.HttpContext.Response.Headers["WWW-Authenticate"] = "Basic";

            if (!string.IsNullOrWhiteSpace(realm))
            {
                context.HttpContext.Response.Headers["WWW-Authenticate"] += $" realm=\"{realm}\"";
            }

            context.Result = new UnauthorizedResult();
        }
    }
}
