using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using System.Collections.Generic;


namespace Business.Concrete
{
    public class OrderDetailManager : IOrderDetailService
    {
        IOrderDetailDal _orderDetail;
        public OrderDetailManager(IOrderDetailDal orderDetail)
        {
            _orderDetail = orderDetail;
        }

        public IDataResult<OrderDetail> GetById(int id)
        {
            return new SuccessDataResult<OrderDetail>( _orderDetail.Get(o => o.OrderId == id));
        }

        public IDataResult<List<OrderDetail>> GetAll()
        {
            return new SuccessDataResult<List<OrderDetail>>(_orderDetail.GetAll());
        }

    
    }
}
