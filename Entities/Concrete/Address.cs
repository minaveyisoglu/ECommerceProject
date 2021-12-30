using Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entity.Concrete
{
    public class Address : IEntity
    {
        [Key]
        public int AddressId { get; set; }
        public int UserId { get; set; }
        public int CityId { get; set; }
        public string AddressDetail { get; set; }
        public int PostalCode { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }


    }
}
