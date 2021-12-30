using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Helpers;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)//uygulamayı çalıştırdığımızda burası çalışacak
        {
            //Autofac de instance geliştirmenin yöntemi bu
            //SingleInstance() katmanlar arası geçişlerde kullanıyoruz ama örneğin iki Manager birbirini kullanıyorsa vermeyiz
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();
            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();
            builder.RegisterType<AddressManager>().As<IAddressService>().SingleInstance();
            builder.RegisterType<EfAddressDal>().As<IAddressDal>().SingleInstance();
            builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();
            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();
            builder.RegisterType<CityManager>().As<ICityService>().SingleInstance();
            builder.RegisterType<EfCityDal>().As<ICityDal>().SingleInstance();
            builder.RegisterType<OrderDetailManager>().As<IOrderDetailService>().SingleInstance();
            builder.RegisterType<EfOrderDetailDal>().As<IOrderDetailDal>().SingleInstance();
            builder.RegisterType<OrderManager>().As<IOrderService>().SingleInstance();
            builder.RegisterType<EfOrderDal>().As<IOrderDal>().SingleInstance();
            builder.RegisterType<OrderStatusManager>().As<IOrderStatusService>().SingleInstance();
            builder.RegisterType<EfOrderStatusDal>().As<IOrderStatusDal>().SingleInstance();
            builder.RegisterType<ProductImageManager>().As<IProductImageService>().SingleInstance();
            builder.RegisterType<EfProductImageDal>().As<IProductImageDal>().SingleInstance();
            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();//çalışan uygulama içerisinde implemente edilmiş interfaceleri bul onlar için AspectInterceptorSelector() çağır
            //Kısacası Autofac bütün sınıflar için önce AspectInterceptorSelector() çalıştırıyor

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
        //bu bir metot if ile şu veritabanında şunu yap gibi diyebiliriz.Bu bir metot buraya logic de koyabiliriz
    }
}
