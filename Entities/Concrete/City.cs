using Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entity.Concrete
{
    public class City:IEntity
    {
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        

    }
}
