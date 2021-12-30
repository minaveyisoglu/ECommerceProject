using Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entity.Concrete
{
    public class OrderStatus:IEntity
    {
        [Key]
        public int OrderStatusId { get; set; }
        public string OrderStatusName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        

    }
}
