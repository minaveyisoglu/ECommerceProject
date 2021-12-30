using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using System.Collections.Generic;


namespace Business.Abstract
{
    public interface IOrderStatusService
    {
        IDataResult<List<OrderStatus>> GetAll();
        IDataResult<OrderStatus> GetById(int id);

    }
}
