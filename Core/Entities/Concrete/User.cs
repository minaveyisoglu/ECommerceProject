using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entity.Concrete
{
    public class User:IEntity
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public byte[] PasswordSalt { get; set; }
        //Kullanıcının girdiği parolayı biraz daha güçlendiriyoruz.
        //Tekniğini bildiğimiz için geri alabiliyoruz.
        public byte[] PasswordHash { get; set; }
        //Veri hashlendikten sonra geri getirilemiyor.
        //Veriyi hashlemiyoruz.Veriye göre hash algoritmaları ile bir data oluşuyor.Data kullanıcının girdiği password değil!!

    }
}
