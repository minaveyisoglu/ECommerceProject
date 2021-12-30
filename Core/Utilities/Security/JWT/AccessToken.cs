using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    //Erişim anahtarı
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }//Token ne zamana kadar geçerli
    }
}

//Refresh Token