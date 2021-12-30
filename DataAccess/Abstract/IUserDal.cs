using Core.DataAccess;
using Core.Entities.Concrete;
using Entity.Concrete;
using Entity.DTOs;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
