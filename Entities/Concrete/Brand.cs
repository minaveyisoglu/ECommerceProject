using Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entity.Concrete
{
    public class Brand : IEntity
    {
        [Key]
        public int BrandId { get; set; }
        public bool IsActive { get; set; }
        public string BrandName { get; set; }
        public DateTime CreateDate { get; set; }


    }
}
