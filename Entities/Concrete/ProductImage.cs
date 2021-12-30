using Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entity.Concrete
{
    public class ProductImage:IEntity
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ImagePath { get; set; }
        public DateTime? Date { get; set; }

    }
}
