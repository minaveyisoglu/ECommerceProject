using Core.DataAccess.EntityFramework;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductImageDal : EfEntityRepositoryBase<ProductImage, ECommerceContext>,IProductImageDal
    {
       
    }
}
