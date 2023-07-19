using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Entidades
{
    public class AutorizacionApi
    {

        public string email { get; set; }
        public string password { get; set; }
    }
    public class AutorizacionApiToken
    {
        public string Token { get; set; }
        public DateTime Expiracion { get; set; }
    }
}
