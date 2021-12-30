using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IProductService
    {
        IResult Add(Product product);
        IResult Delete(Product product);
        IResult Update(Product product);
        IDataResult<List<Product>> GetAll();
        IDataResult<Product> GetById(int id);
        IDataResult<List<ProductDetailDto>> GetProductDetails();


    }
}
