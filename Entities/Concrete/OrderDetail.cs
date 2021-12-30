using Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entity.Concrete
{
    public class OrderDetail:IEntity
    {
        [Key]
        public int OrderDetailsId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public decimal SalePrice { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        


    }
}
