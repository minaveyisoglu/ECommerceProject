using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using System.Collections.Generic;


namespace Business.Abstract
{
    public interface ICategoryService
    {
        IResult Add(Category category);
        IResult Delete(Category category);
        IResult Update(Category category);
        IDataResult<Category> GetById(int id);
        IDataResult<List<Category>> GetAll();

    }
}
