using Modelo.Security.DataAcces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo.Security.Business.Service
{
    public class UserService : IUserService
    {

        public DbSecurityContext _context;

        public UserService(DbSecurityContext context)
        {
            _context = context;
        }

        public bool ValidateUser(string username, string password)
        {

            var user = _context.tbl_user.Where(_user =>
            _user.Username == username && _user.Password == password)
                .FirstOrDefault();

            if (user != null)
            {
                return true;
            }

            return false;

        }
    }
}
