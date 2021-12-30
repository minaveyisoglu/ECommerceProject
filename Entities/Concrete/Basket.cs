using Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entity.Concrete
{
    public class Basket:IEntity
    {
        [Key]
        public int BasketId { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int Count { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
