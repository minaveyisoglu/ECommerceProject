using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);
        object Get(string key);
        void Add(string key, object value, int duration);//duration:Cache de ne kadar duracak
        bool IsAdd(string key);//Cache de var mı
        void Remove(string key);//Cache den uçurma
        void RemoveByPattern(string pattern);
        //ismi Get ile başlayanları uçur
        //isminde Category olanları uçur
        //bir desen veriyoruz başı sonu önemli değil içinde Category olanı uçur örneğin


    }
}
