using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Security.Business.Service
{
    public interface IUserService
    {

        bool ValidateUser(string username, string password);
    }
}
