using Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using System.Text.RegularExpressions;

namespace Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        //Adapter Pattern
        IMemoryCache _memoryCache;
        //Microsoft kendi kütüphanesini kullanıyoruz
        //IMemoryCache constructor da enjekte etsek çalışmaz

        public MemoryCacheManager()
        {
            _memoryCache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();
        }

        public void Add(string key, object value, int duration)
        {
            _memoryCache.Set(key, value, TimeSpan.FromMinutes(duration));
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public object Get(string key)
        {
            return _memoryCache.Get(key);
        }

        public bool IsAdd(string key)
        {
            return _memoryCache.TryGetValue(key, out _);
        }//TryGetValue böyle bir değer bellekte var mı yok mu
        // out _ :bir şey döndürmek istemiyorsak
        //data istemiyoruz sadece bellekte böyle bir alan var mı yok mu onu istiyoruz

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_memoryCache) as dynamic;
            List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

            foreach (var cacheItem in cacheEntriesCollection)
            {
                ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                cacheCollectionValues.Add(cacheItemValue);
            }

            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();

            foreach (var key in keysToRemove)
            {
                _memoryCache.Remove(key);
            }
        }
        //RemoveByPattern:çalışma anında bellekten silmeye yarıyor.
        //bellekte sınıfın instance ı var ve çalışma anında müdahele etmek istiyoruz
        //bunu reflection ile yapıyoruz.reflection ile çalışma anında elimizde bulunan nesnelere
        //ve olmayanları da yeniden oluşturmak gibi kullaabileceğimiz bir yapı
        //kodu çalışma anında çalıştırma oluşturma:reflection

        //EntriesCollection:Microsoft cache datalarını bunun içine atıyor
        //her bir cache elemanın gez ve 
        //  var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();
        //bu kurala uyanları  keysToRemove içine atıcak foreach ile gezip uyan key leri buluyoruz
        //sonra bellekten uçuruyoruz

    }
}
