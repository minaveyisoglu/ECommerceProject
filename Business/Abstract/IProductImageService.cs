using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IProductImageService
    {
        IResult Add(ProductImage productImage);
        IResult Delete(ProductImage productImage);
        IResult Update(ProductImage productImage);
        IDataResult<List<ProductImage>> GetAll();
        IDataResult<List<ProductImage>> GetProductImageById(int id);

    }
}