using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modelo.Security.Api.viewObject
{
    public class JsonWebTokenVO
    {

        public string Token_type { get; set; } = "bearer";

        public string Expires_in { get; set; }

        public string Refresh_Token { get; set; }

    }
}
