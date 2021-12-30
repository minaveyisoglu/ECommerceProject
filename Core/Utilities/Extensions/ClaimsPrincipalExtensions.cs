using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        //ClaimsPrincipal:mevcut kullanıcımız
        //ClaimsPrincipalExtensions da başka claimlere ve rollere erişebilmeliyiz
        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
        {//ClaimsPrincipal extend ettik.hangi claimType için filtreleme yapıyoruz
            var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
            //claimsPrincipal? var mı(örneğin sisteme login olmuş olmayabilir)
            return result;
        }

        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }
    }
}
