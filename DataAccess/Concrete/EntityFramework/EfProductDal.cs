using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System.Collections.Generic;
using System.Linq;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, ECommerceContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (ECommerceContext eCommerceContext = new ECommerceContext())
            {
                var result = from p in eCommerceContext.Products
                             join c in eCommerceContext.Categories
                             on p.CategoryId equals c.CategoryId

                             select new ProductDetailDto
                             {
                                 ProductId = p.ProductId,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName,
                                 UnitsInStock = p.UnitsInStock,
                                 UnitPrice=p.UnitPrice,
                                 Description=p.Description,
                                 ProductImages = new List<ProductImage>(),
                                 ImagePath = @"\images\default.jpg"
                             };
                return result.ToList();
            }
        }
    }
}
