using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using System.Collections.Generic;


namespace Business.Abstract
{
    public interface IAddressService
    {
        IResult Add(Address address);
        IResult Delete(Address address);
        IResult Update(Address address);
        IDataResult<List<Address>> GetAll();
        IDataResult<Address>GetById(int id);
    }
}
