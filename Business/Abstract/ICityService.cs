using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using System.Collections.Generic;


namespace Business.Abstract
{
    public interface ICityService
    {
        IResult Add(City city);
        IResult Delete(City city);
        IResult Update(City city);
        IDataResult<List<City>> GetAll();
        IDataResult<City> GetById(int id);
    }
}
