using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ECommerceContext>, IUserDal
    {
        //OperationClaim ile UserOperationClaim leri join edicez.
        public List<OperationClaim> GetClaims(User user)
        {
            using (var ECommerceContext = new ECommerceContext())
            {
                var result = from operationClaim in ECommerceContext.OperationClaims
                             join userOperationClaim in ECommerceContext.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim
                             {
                                 Id = operationClaim.Id,
                                 Name = operationClaim.Name
                             };

                return result.ToList();//result IQueryable döner.Liste istediğimiz için ToList() kullandık.
            }
        }
    }
}
