using Castle.DynamicProxy;
using System;


namespace Core.Utilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    //AllowMultiple = true hem veritabanına hem de dosyaya loglasın diyebiliriz.Farklı parametrelerle aynı attribute'i çağırabiliriz
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
