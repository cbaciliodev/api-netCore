using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Security.Models
{
    public class tbl_company
    {
        public tbl_company()
        {

        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string BusinessName { get; set; }
        public bool IsActive { get; set; }
    }
}
