using Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entity.Concrete
{
    public class Product:IEntity
    {
        [Key]
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public string ProductName { get; set; }
        public int UnitsInStock { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }

       
    }
}
