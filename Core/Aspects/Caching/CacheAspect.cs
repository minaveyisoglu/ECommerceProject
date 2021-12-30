using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)//süre vermezsek veri 60 dk cache de durucak sonra uçucak
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            if (_cacheManager.IsAdd(key))
            {
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }
            invocation.Proceed();
            _cacheManager.Add(key, invocation.ReturnValue, _duration);
        }
        //invocation.Method.ReflectedType.FullName:namespace+class ismi
        //invocation:method ReflectedType:namespaceini al(Business.Abstract.IProductService)
        //{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}:key oluşturmaya çalışıyoruz
        //ÖRNEK:Northwind.Business.IProductService.GetAll
        //var arguments = invocation.Arguments.ToList();:metodun parametresi varsa listeye çevir
        // var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})":
        //metodun parametresi varsa GetAll içine ekle.Parametre yoksa null geç orayı
        // if (_cacheManager.IsAdd(key)) :Daha önce cache de anahtar var mı
        //invocation.ReturnValue:metodu çalıştırmadan geri dön.Manuel return oluşturduk
        //_cacheManager.Get(key):ReturnValue

        //invocation.Proceed():Cache de yoksa invocationı çalıştır.Metodu devam ettir.Veritabanından datayı getirdi
        //_cacheManager.Add(key, invocation.ReturnValue, _duration):Cache ekle

    }
}
