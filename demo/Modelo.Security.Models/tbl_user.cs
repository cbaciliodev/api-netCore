using System;

namespace Modelo.Security.Models
{
    public class tbl_user
    {

        public tbl_user()
        {
        }
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
         public string PersonName { get; set; } 
        public bool IsActive { get; set; }
    }
}
