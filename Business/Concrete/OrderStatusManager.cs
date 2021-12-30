using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using System.Collections.Generic;


namespace Business.Concrete
{
    public class OrderStatusManager : IOrderStatusService
    {
        IOrderStatusDal _orderStatusDal;

        public OrderStatusManager(IOrderStatusDal orderStatusDal)
        {
            _orderStatusDal = orderStatusDal;
        }
        public IDataResult<OrderStatus> GetById(int id)
        {
            return new SuccessDataResult<OrderStatus>(_orderStatusDal.Get(o => o.OrderStatusId == id));
        }

        public IDataResult<List<OrderStatus>> GetAll()
        {
            return new SuccessDataResult<List<OrderStatus>>(_orderStatusDal.GetAll());
        }

    }
}
