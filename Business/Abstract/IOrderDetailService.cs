using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using System.Collections.Generic;


namespace Business.Abstract
{
    public interface IOrderDetailService
    {
        IDataResult<List<OrderDetail>> GetAll();
        IDataResult<OrderDetail> GetById(int id);
    }
}
