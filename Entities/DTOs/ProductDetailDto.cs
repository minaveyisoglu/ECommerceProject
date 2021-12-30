using Core.Entities;
using Entity.Concrete;
using System.Collections.Generic;

namespace Entity.DTOs
{
    public class ProductDetailDto:IDto
    {       
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public int UnitsInStock { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice{ get; set; }

        public List<ProductImage> ProductImages { get; set; }
        public string ImagePath { get; set; }
    }
}
