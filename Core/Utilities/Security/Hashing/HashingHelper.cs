using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        //void yerine Password ve Hash'i beraber bulunduran bir model de yapabiliriz
        //out byte[] gönderilen değer boş bile olsa doldurup geri döndürmeye yarıyor.Referans yapılar için kullanabileceğimiz bir durum
        public static void CreatePasswordHash(string password, out byte[] passwordHash,out byte[] passwordSalt )
            //bir password vericez ve dışarıya passwordHash ve passwordSalt çıkarıcak yapıyı tasarlıcaz
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())//hmac Cryptography sınıfında kullandığımız classa karşılık geliyor
            {
                passwordSalt = hmac.Key;//Salt olarak Key kullandık
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        public static bool VerifyPasswordHash(string password,byte[] passwordHash,byte[] passwordSalt) //password kullanıcının sisteme tekrar girdiğinde yazdığı password
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for(int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }   
                }
                return true;
            }
        }

      
    }
}
