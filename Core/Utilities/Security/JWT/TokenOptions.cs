using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public class TokenOptions
    {
        public string Audience { get; set; }//Token'ın kullanıcı kitlesi
        public string Issuer { get; set; }//İmzalayan
        public int AccessTokenExpiration { get; set; }
        public string SecurityKey { get; set; }
    }
}
//İleride yeni datalar da eklenebilir.Bu Token Optionları appsettings.json içinde tutucaz.Nesne olarak map edip daha sonra o nesne üzerinden kullanıcaz