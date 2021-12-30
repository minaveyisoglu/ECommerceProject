using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers
           (this IServiceCollection serviceCollection, ICoreModule[] modules)
    {
        foreach (var module in modules)
        {
            module.Load(serviceCollection);
        }

        return ServiceTool.Create(serviceCollection);
    }
}
}
//IServiceCollection Api de servis bağımlılıkları eklediğimiz veya araya girmesini istediğimiz
//servisleri eklediğimiz koleksiyon

//genişetmek istediğimiz this ile veriyoruz
//this IServiceCollection serviceCollection this parametre değil neyi genişletmek istediğimiz
//anlamına geliyor

//ICoreModule[] modules:PARAMETRE

//genel olarak Core katmanı da dahil olmak üzere ekleyeceğimiz bütün injectionları
//toplayabileceğimiz bir yapıya dönüştü.