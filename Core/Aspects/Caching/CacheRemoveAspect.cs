using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using Castle.DynamicProxy;

namespace Core.Aspects.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
        //CacheRemoveAspect:Data bzoulduğu zaman çalışır,data ekleme,data silme,data güncelleme
        //metod başarılı olursa git ekle
        //Manager da cache yönetimi yapıyorsak veriyi manipüle eden metotlarına CacheRemoveAspect  uygularız
        //OnSuccess :success olduğu zaman git ekle 
        //patterna göre silme işlemi yapıyoruz
    }
}
