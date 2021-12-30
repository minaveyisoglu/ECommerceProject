using Core.Entities.Concrete;
using Entity.Concrete;
using System.Collections.Generic;


namespace Core.Utilities.Security.JWT
{
    //Token Üretimi
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
        //User bilgisine göre token üreticek.Kullanıcının rollerini veriyoruz çünkü token a eklemek istiyoruz.
    }
}
