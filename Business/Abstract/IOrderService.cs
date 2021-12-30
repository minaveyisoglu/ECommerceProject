using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IOrderService
    {
        IDataResult<List<Order>> GetAll();
        IDataResult<Order> GetById(int id);
    }
}
