using Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entity.Concrete
{
    public class Order:IEntity
    {
        [Key]
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int OrderStatusId { get; set; }
        public int AddressId { get; set; }      
        public int Count { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        
    }
}
